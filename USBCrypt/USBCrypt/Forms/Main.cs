using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using USBCrypt.Codes;

namespace USBCrypt
{
    public partial class Main : Form
    {

        Thread connectionThread = null;
        Thread watcherThread = null;

        public Main()
        {
            InitializeComponent();
            Autorun.Disable_Autorun(); // 저장장치의 자동실행을 방지함

            connectionThread = new Thread(USBConnectionProcess);
            connectionThread.Start();

            watcherThread = new Thread(USBWatcherProcess);
            watcherThread.Start();
        }


        List<string> files = new List<string>() { }; // 파일 시스템 내부 파일명들이 저장될 리스트
        string password = "AQA*zNCMnd8BFdERjHoAwE/Cl+sBAAAAH2"; // AES 256bit 암호체계의 비밀번호
        string driveName = null;

        bool running = false; // 쓰레드 자체 알고리즘 중복실행 방지
        public static bool working = false; // 파일이 암/복화 중인경우 중복실행 방지

        bool mode = false; // 사용자가 업무 수행모드를 선택했는지 확인할 논리형 변수
        bool connection = false; // USB 연결상태
        public static bool deny = false; // 해당 프로그램에 의해 네트워크를 차단하였는지 확인

        public static Form warning_form = null; // 네트워크 연결 알림폼

        private void USBConnectionProcess() // USB 연결관리 쓰레드가 수행할 기능
        {
            CheckForIllegalCrossThreadCalls = false; // 크로스 쓰레드 문제발생을 해결

            while (true) // 무한루프를 통한 지속점검
            {
                if (running == false)
                {
                    running = true;

                    driveName = USB.USB_Connection_Check(); // USB 연결여부를 가져옴
                    if (!String.IsNullOrEmpty(driveName)) // USB가 하나라도 연결된 경우
                    {
                        connection = true; // USB 연결이 감지됨
                        this.Opacity = 1.0; // 폼을 보이도록 함

                        if (NetworkInterface.GetIsNetworkAvailable())
                        {
                            Network.Disable_Network(); // 네트워크를 연결해지함

                            if (warning_form == null)
                            {
                                warning_form = new Forms.Network_Warning();
                                warning_form.ShowDialog();
                            }
                            
                        }

                        if (!working) // 파일 암/복호화 동작중이 아닌경우
                            files = Files.Get_Files(driveName); // 연결된 USB의 모든 파일리스트를 가져옴 (파일현황 주기적 갱신)

                        if (!mode) // 파일 보관모드인경우에만 암호화 처리
                            Files.Encrypt(files, password); // 비동기방식으로 연결된 USB의 모든 파일을 암호화함
                    }
                    else // USB 연결이 제거된 경우
                    {
                        if (!NetworkInterface.GetIsNetworkAvailable()) // 네트워크 연결이 되지 않는 경우
                        {
                            if (deny) // 해당 프로그램에 의해 네트워크를 차단한 경우
                                Network.Enable_Network(); // 네트워크를 다시 연결함
                        }

                        this.Opacity = 0; // 폼을 숨김
                        connection = false; // USB 연결이 제거됨
                        working = false; // 프로그램을 파일 보관모드로 변경
                    }

                    running = false;
                    Thread.Sleep(2000); // 무한루프 중 부하방지를 위해 쓰레드에 일시 휴식 부여
                }
            }
        }

    
        private void USBWatcherProcess() // USB 내부 파일시스템을 감시하는 기능
        {
            while (true)
            {
                if (driveName != null)
                {
                    Watcher.FileSystem_Scanning(driveName);

                }
                Thread.Sleep(5000);
            }

        }

        private void Encrypt_Btn_Click(object sender, EventArgs e)
        {
            if (connection) // USB가 연결중인 경우에만 동작
            {
                if (!working) // 암/복호화 동작중이 아닌 경우
                {
                    mode = false; // 파일 보관모드 진입
                    Files.Encrypt(files, password); // 비동기방식으로 연결된 USB의 모든 파일을 암호화함

                    this.BackgroundImage = Properties.Resources.encrypted; // 암호화 이미지로 변경함
                    status_lb.Text = "USB 암호화 동작중";

                    Decrypt_Btn.Enabled = true;
                    Encrypt_Btn.Enabled = false;
                }
                else
                {
                    MessageBox.Show("암/복호화가 진행중에 있습니다. 잠시 후 다시 시도 바랍니다.", "USBCrypt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("연결된 USB 장치가 없습니다.", "USBCrypt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Decrypt_Btn_Click(object sender, EventArgs e)
        {
            if (connection) // USB가 연결중인 경우에만 동작
            {
                if (!working) // 암/복호화 동작중이 아닌 경우
                {
                    mode = true; // 파일 작업모드 진입
                    Files.Decrypt(files, password); // 비동기방식으로 연결된 USB의 모든 파일을 복호화함

                    this.BackgroundImage = Properties.Resources.decrypted; // 복호화 이미지로 변경함
                    status_lb.Text = "USB 파일 작업모드 동작중";

                    Decrypt_Btn.Enabled = false;
                    Encrypt_Btn.Enabled = true;
                }
                else
                {
                    MessageBox.Show("암/복호화가 진행중에 있습니다. 잠시 후 다시 시도 바랍니다.", "USBCrypt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("연결된 USB 장치가 없습니다.", "USBCrypt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connectionThread != null)
            {
                if (connectionThread.IsAlive)
                {
                    connectionThread.Abort();
                }
            }

            if (watcherThread != null)
            {
                if (watcherThread.IsAlive)
                {
                    watcherThread.Abort();
                }
            }
        }
    }
}

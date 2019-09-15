using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace USBCrypt.Codes
{
    class Network
    {
        public static void Enable_Network()
        {
            foreach (string interfaceName in Interfaces)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = "netsh";
                    psi.Arguments = "interface set interface \"" + interfaceName + "\" admin=enabled";

                    psi.CreateNoWindow = true;
                    psi.UseShellExecute = true;
                    psi.WindowStyle = ProcessWindowStyle.Hidden;
                    //psi.WindowStyle = ProcessWindowStyle.Minimized;

                    Process p = new Process();
                    p.StartInfo = psi;
                    p.Start();
                }
                catch
                {
                    // 네트워크 중 오류가 발생하는 경우
                }
            }
            Main.deny = false; // 해당 프로그램에 의해 차단이 해지됨을 알림
        }

        static List<string> Interfaces = new List<string>() { };
        public static void Disable_Network()
        {
            var networks = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface network in networks)
            {
                try
                {
                    string interfaceName = network.Name;
                    Interfaces.Add(interfaceName);

                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = "netsh";
                    psi.Arguments = "interface set interface \"" + interfaceName + "\" admin=disabled";
                    psi.CreateNoWindow = true;
                    psi.UseShellExecute = true;
                    psi.WindowStyle = ProcessWindowStyle.Hidden;
                    //psi.WindowStyle = ProcessWindowStyle.Minimized;

                    Process p = new Process();
                    p.StartInfo = psi;
                    p.Start();
                }
                catch
                {
                    // 네트워크 연결해지 중 오류가 발생하는 경우
                }
            }
            Main.deny = true; // 해당 프로그램에 의해 차단되었음을 알림
        }

    }
}

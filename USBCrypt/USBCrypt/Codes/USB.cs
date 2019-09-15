using System.IO;

namespace USBCrypt.Codes
{
    class USB
    {
        public static string USB_Connection_Check() // USB 연결여부를 반환하는 함수
        {
            DriveInfo[] diArray = DriveInfo.GetDrives();

            foreach (DriveInfo di in diArray)
            {
                if (di.IsReady == true && di.DriveType == DriveType.Removable)
                {
                    return di.Name; // 드라이브 이름을 반환
                }
            }
            return null;
        }
    }
}

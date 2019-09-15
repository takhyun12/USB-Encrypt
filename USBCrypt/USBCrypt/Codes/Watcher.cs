using System;
using System.IO;

namespace USBCrypt.Codes
{
    class Watcher
    {
        public static void FileSystem_Scanning(string drivename)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = drivename;

            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Changed += new FileSystemEventHandler(Changed);
            watcher.Created += new FileSystemEventHandler(Changed);
            watcher.Deleted += new FileSystemEventHandler(Changed);
            watcher.Renamed += new RenamedEventHandler(Renamed);
            watcher.EnableRaisingEvents = true;
        }

        public static void Changed(object source, FileSystemEventArgs e)
        {
            try
            {
                string msg = "File: " + e.FullPath + ", Change : " + e.ChangeType;
                string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                string log = "[" + time + "] " + msg;

                Loging(log);
            }
            catch
            {

            }
        }

        public static void Renamed(object source, RenamedEventArgs e)
        {
            try
            {
                string msg = "File: " + e.OldFullPath + " renamed to " + e.FullPath;
                string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                string log = "[" + time + "] " + msg;

                Loging(log);
            }
            catch
            {

            }
        }

        static void Loging(string log)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\USBCrypt";
            string log_path = path + @"\USB_Watcher.log";
       
            if (!Directory.Exists(path)) // 폴더가 존재하지 않는 경우
            {
                Directory.CreateDirectory(path); // 폴더를 생성함
            }

            try
            {
                StreamWriter file = new StreamWriter(log_path, true);
                file.WriteLine(log);
                file.Close();
            }
            catch
            {
                // 로깅 중 오류가 발생하는 경우의 예외처리
            }
        }

    }
}

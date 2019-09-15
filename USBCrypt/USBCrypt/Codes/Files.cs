using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace USBCrypt.Codes
{
    class Files
    {
        public static List<string> Get_Files(string driveName)
        {
            List<string> files = new List<string>() { };

            try
            {
                string[] root_files = Directory.GetFiles(driveName, "*");

                foreach (string filename in root_files)
                {
                    files.Add(filename);
                }
            }
            catch
            {
                // 드라이브 루트경로의 파일 리스트를 가져오는 중 오류가 나는 경우
            }

            foreach (string directory in Directory.GetDirectories(driveName)) // 지정된 폴더의 하위 모든 폴더명을 가져옴
            {
                try // 파일을 가져오는 중에 오류가 발생하는 경우의 예외처리
                {
                    foreach (string filename in Directory.GetFiles(directory, "*", SearchOption.AllDirectories)) // 하위 모든 파일을 가져옴
                    {
                        files.Add(filename);
                    }
                }
                catch
                {
                    continue;
                }
            }

            return files;
        }

        public static void Encrypt(List<string> files, string password)
        {
            Main.working = true; // 파일 암호화가 동작중임을 표시
            foreach (string file in files) // USB 내 저장된 파일을 순차적으로 가져옴
            {
                if (File.Exists(file) && Path.GetExtension(file) != ".rokaf") // 암호화 되지 않은 모든 파일들을 가져옴
                {
                    try
                    {
                        file.EncryptFileAsync(password); // 파일을 비동기식으로 암호화함
                        File.Delete(file); // 파일을 삭제함
                    }
                    catch
                    {
                        continue; // 오류가 발생하는 경우 반복문을 다음으로 넘김
                    }
                }
            }
            Main.working = false;
        }

        public static void Decrypt(List<string> files, string password)
        {
            Main.working = true; // 파일 암호화가 동작중임을 표시

            foreach (string file in files) // USB 내 저장된 파일을 순차적으로 가져옴
            {
                if (File.Exists(file) && Path.GetExtension(file) == ".rokaf") // 암호화된 파일들만 가져옴
                {
                    try
                    {
                        file.DecryptFileAsync(password); // 파일을 비동기식으로 복호화함
                        File.Delete(file); // 파일을 삭제함
                    }
                    catch
                    {
                        continue; // 오류가 발생하는 경우 반복문을 다음으로 넘김
                    }
                }
            }
            Main.working = false;
        }
    }

    
    public static class Files_Helper
    { 
        public static void EncryptFileAsync(this string path, string password)
        {
            SharpAESCrypt.SharpAESCrypt.Encrypt(password, path, path + ".rokaf");
        }
        public static void EncryptFilesAsync(this IEnumerable<string> paths, string password)
        {
            foreach (var path in paths)
            {
                path.EncryptFileAsync(password);
            }
        }

        public static void DecryptFileAsync(this string path, string password)
        {
            var outputpath = path.RemoveExtension();
            SharpAESCrypt.SharpAESCrypt.Decrypt(password, path, outputpath);
        }

        public static string RemoveExtension(this string path)
        {
            var outputpath = Path.ChangeExtension(path, "").TrimEnd(new char[] { '.' });
            return outputpath;
        }

        public static void DecryptFilesAsync(this IEnumerable<string> paths, string password)
        {
            foreach (var path in paths)
            {
                path.DecryptFileAsync(password);
            }
        }


        public static IEnumerable<string> GetFolderFilesPaths(this string folder, bool followSubDirs = true)
        {
            var paths = new List<string>();
            if (!Directory.Exists(folder))
                return paths;
            if (followSubDirs)
            {
                var subFolders = Directory.GetDirectories(folder);
                if (subFolders != null)
                {

                    foreach (var path in subFolders)
                    {
                        paths.AddRange(GetFolderFilesPaths(path));

                    }

                }
            }
            var subFiles = Directory.GetFiles(folder);
            if (subFiles != null)
            {
                paths.AddRange(subFiles);
            }


            return paths;
        }

        public static IEnumerable<string> ParseExtensions(this string extentions)
        {
            var exts = new List<string>();
            var type = Regex.Match(extentions, @"\(.+\)").Value;
            if (!String.IsNullOrEmpty(type))
                extentions = extentions.Replace(type, String.Empty);

            var matches = Regex.Matches(extentions, @"\b(\w+)\b");

            foreach (var ext in matches)
            {
                exts.Add("." + ext.ToString());

            }

            return exts;
        }


        public static bool CheckExtension(this string path, IEnumerable<string> extensions)
        {
            if (extensions == null)
                return true;
            if (extensions.Count() == 0)
                return true;

            foreach (var ext in extensions)
            {
                if (path.ToLower().EndsWith(ext.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }


    }
}

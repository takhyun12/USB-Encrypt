using Microsoft.Win32;

namespace USBCrypt.Codes
{
    class Autorun
    {
        public static void Disable_Autorun()
        {
            string rKey = "AutoRun";
            int rVal = 0;

            RegistryKey reg = Registry.LocalMachine;
            reg = reg.CreateSubKey(@"SYSTEM\ControlSet001\Services\cdrom", RegistryKeyPermissionCheck.ReadWriteSubTree);
            reg.SetValue(rKey, rVal);
            reg.Close();

            reg = Registry.LocalMachine;
            reg = reg.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\cdrom", RegistryKeyPermissionCheck.ReadWriteSubTree);
            reg.SetValue(rKey, rVal);
            reg.Close();

            reg = Registry.CurrentUser;
            reg = reg.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", RegistryKeyPermissionCheck.ReadWriteSubTree);
            reg.SetValue("NoDriveAutoRun", 67108859, RegistryValueKind.DWord);
            reg.SetValue("NoDriveTypeAutoRun", 255, RegistryValueKind.DWord);
            reg.Close();

            reg = Registry.LocalMachine;
            reg = reg.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\IniFileMapping\Autorun.inf", RegistryKeyPermissionCheck.ReadWriteSubTree);
            reg.SetValue("", "@SYS:idiot");
            reg.Close();
        }
    }
}

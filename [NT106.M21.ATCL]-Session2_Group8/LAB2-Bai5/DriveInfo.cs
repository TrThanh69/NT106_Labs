using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileDirectoryTutorial
{
    class DriveInfoDemo
    {
        static void Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives(); 
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine(" ============================== "); 
                // Tên của ổ đĩa (C, D, ..)
                Console.WriteLine("Drive {0}", drive.Name);

                // Loại ổ đĩa (Removable,..)
                Console.WriteLine("  Drive type: {0}", drive.DriveType);

                // Nếu ổ đĩa sẵn sàng.
                if (drive.IsReady)
                {
                    Console.WriteLine("  Volume label: {0}", drive.VolumeLabel);
                    Console.WriteLine("  File system: {0}", drive.DriveFormat);
                    Console.WriteLine(
                        "  Available space to current user:{0, 15} bytes",
                        drive.AvailableFreeSpace);

                    Console.WriteLine(
                        "  Total available space:          {0, 15} bytes",
                        drive.TotalFreeSpace);

                    Console.WriteLine(
                        "  Total size of drive:            {0, 15} bytes ",
                        drive.TotalSize);
                }
            } 
            Console.Read();
        }
    } 
}
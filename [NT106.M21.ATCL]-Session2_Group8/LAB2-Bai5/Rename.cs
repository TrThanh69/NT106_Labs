using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileDirectoryTutorial
{
    class RenameFileDemo
    {
        public static void Main(string[] args)
        {
            String filePath = "C:/test/test.txt";

            if (File.Exists(filePath))
            {
                Console.WriteLine(filePath + " exist");  
                Console.WriteLine("Please enter a new name for this file:");
                
                // Một String mà người dùng nhập vào.
                // Ví dụ: C:/test/test2.txt
                string newFilename = Console.ReadLine(); 
                if (newFilename != String.Empty)
                {
                    // Đổi tên file:
                    // Có thể bao gồm, chuyển file tới một thư mục cha khác, và đổi tên file. 
                    // Phải đảm bảo rằng thư mục cha mới tồn tại.
                    // (nếu không ngoại lệ DirectoryNotFoundException sẽ được ném ra).
                    File.Move(filePath, newFilename);

                    if (File.Exists(newFilename))
                    {
                        Console.WriteLine("The file was renamed to " + newFilename); 
                    }
                }
            }
            else
            {
                Console.WriteLine("Path " + filePath + " does not exist.");
            } 
            Console.ReadLine();
        }
    } 
}
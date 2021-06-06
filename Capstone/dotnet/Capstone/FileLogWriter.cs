using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    class FileLogWriter
    {
        private string whereToWrite = "";
        public FileLogWriter()
        {
            string currentDirectory = Environment.CurrentDirectory;
            whereToWrite = Path.Combine(currentDirectory, "VendingMachineLog.txt");
        }
        public void WriteLogMessage(string whatToWrite)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(whereToWrite, true))
                {
                    sw.WriteLine(whatToWrite);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("The file to write to was not found" + e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

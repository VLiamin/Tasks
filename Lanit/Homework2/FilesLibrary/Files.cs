using System;
using System.IO;
using System.Text;
using LocalConsole = PrintAndReadLibrary.Console;

namespace FilesLibrary
{
    /// <summary>
    /// A class that works with files.
    /// </summary>
    public class Files
    {
        private static Encoding encoding = Encoding.UTF8;
        private LocalConsole localConsole = new LocalConsole();

        /// <summary>
        /// Method that creates file
        /// </summary>
        /// <param name="path"> Path to the file </param>
        public void CreateFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    using (File.Create(path))
                    {
                    }
                } 
            } 
            catch (Exception e)
            {
                localConsole.PrintError(e.Message);
            }
        }

        /// <summary>
        /// Method that writes text to the file
        /// </summary>
        /// <param name="path"> Path to the file </param>
        public void WriteText(string path)
        {
            try
            {
                localConsole.PrintQuestion("Write text: ");
                string strings = localConsole.ReadAnswer();
                File.AppendAllText(path, strings);
            }
            catch (Exception e)
            {
                localConsole.PrintError(e.Message);
            }
        }

        /// <summary>
        /// Method that reads text from the file
        /// </summary>
        /// <param name="path"> Path to the file </param>
        public void ReadFile(string path)
        {            
            try
            {
                Byte[] bytes = File.ReadAllBytes(path);
                
                localConsole.PrintQuestion("1 - Read from the beginning of the file\n2 - Read from the middle of the file\nNumber: ");
                string number = localConsole.ReadAnswer();
                int index = 0;

                if (number.Equals("2"))
                {
                    index = bytes.Length / 2;
                } else if (!number.Equals("1"))
                {
                    localConsole.PrintError("You wrote incorrect value");
                }

                localConsole.PrintQuestion("Write the block size: ");
                int size = Int32.Parse(localConsole.ReadAnswer());

                while (index < bytes.Length)
                {
                    if (index + size - 1 < bytes.Length) {
                        localConsole.PrintResult(encoding.GetString(bytes, index, size));
                    } else
                    {
                        localConsole.PrintResult(encoding.GetString(bytes, index, bytes.Length - index));
                    }

                    index += size;
                    localConsole.PrintQuestion("1 - Write next block\n2 - The end\nNumber: ");
                    string value = localConsole.ReadAnswer();

                    if (!value.Equals("1")) {
                        return;
                    }
                }
            }
            catch (FormatException e1)
            {
                localConsole.PrintError("It is not a number");
            }
            catch (Exception e2)
            {
                localConsole.PrintError(e2.Message);
            }
        }
    }
}

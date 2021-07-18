using ParsingLibrary;
using FilesLibrary;
using System;
using LocalConsole = PrintAndReadLibrary.Console;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Parsing parsing = new Parsing();
            Files files = new Files();
            LocalConsole localConsole = new LocalConsole();

            while (true) {
                localConsole.PrintQuestion("1 - Parse the site\n2 - Work with files\nNumber: ");
                string number = localConsole.ReadAnswer();

                if (number.Equals("1")) {
                    parsing.ParseTheSite();
                } else if (number.Equals("2"))
                {
                    localConsole.PrintQuestion("1 - Create file\n2 - Write in the file\n3 - Read the file\nNumber: ");
                    number = localConsole.ReadAnswer();

                    localConsole.PrintQuestion("Print path: ");
                    string path = localConsole.ReadAnswer();

                    switch (number)
                    {
                        case "1":
                            files.CreateFile(path);
                            break;
                        case "2":
                            files.WriteText(path);
                            break;
                        case "3":
                            files.ReadFile(path);
                            break;
                        default:
                            break;
                    }
                }

                localConsole.PrintQuestion("1 - Exit\n2 - Next iteration\nNumber: ");
                if (localConsole.ReadAnswer().Equals("1"))
                {
                    break;
                }
            }
        }
    }
}

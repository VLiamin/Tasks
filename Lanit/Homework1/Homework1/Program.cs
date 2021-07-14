using System;
using System.Collections.Generic;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            Files files = new Files();
            MathematicOperations mathematicOperations = new MathematicOperations();
            Strings strings = new Strings();
            while (true)
            {
                Console.WriteLine("1 - Work with strings \n2 - " +
                    "Work with numbers \n3 - Work with files");

                Console.Write("Write number: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        WorkWithStrings(strings);
                        break;
                    case "2":
                        try
                        {
                            WorkWithNumbers(mathematicOperations);
                        } catch (FormatException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("It is not a number");
                            Console.ResetColor();
                        }
                        break;
                    case "3":
                        WorkWithFiles(files);
                        break;
                    default:
                        break;

                }

                Console.WriteLine("\n0 - Exit \n1 - " +
                    "Next iteration");
                Console.Write("Write number: ");
                if (Console.ReadLine().Equals("0"))
                {
                    return;
                } else
                {
                    Console.WriteLine("\n\n-------------------\n\n");
                }
            }
        }

        private static void WorkWithStrings(Strings strings)
        {
            Console.Write("Write string: ");
            String line = Console.ReadLine();

            Console.WriteLine("1 - To upper \n2 - " +
            "To lower");

            Console.Write("Write number: ");
            String number = Console.ReadLine();

            if (number.Equals("1"))
            {
                Console.WriteLine("Result: " + strings.ToUpper(line));
            }
            else
            {
                Console.WriteLine("Result: " + strings.ToLower(line));
            }
        }

        private static void WorkWithNumbers(MathematicOperations mathematicOperations)
        {
            Console.Write("Write first number: ");
            double firstNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Write second number: ");
            double secondNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("1 - Multiply numbers \n2 - " +
            "Subtract numbers \n3 - Sum numbers \n4 - Divide numbers"
            + " \n5 - To pow");

            Console.Write("Write number: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Result: " + mathematicOperations.Multiply(firstNumber, secondNumber));
                    break;
                case "2":
                    Console.WriteLine("Result: " + mathematicOperations.Subtract(firstNumber, secondNumber));
                    break;
                case "3":
                    Console.WriteLine("Result: " + mathematicOperations.Summarize(firstNumber, secondNumber));
                    break;
                case "4":
                    try
                    {
                        Console.WriteLine("Result: " + mathematicOperations.Divide(firstNumber, secondNumber));
                    } catch (DivideByZeroException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("It is impossible to divide by zero");
                        Console.ResetColor();
                    }
                    break;
                case "5":
                    Console.WriteLine("Result: " + mathematicOperations.ToPow(firstNumber, secondNumber));
                    break;
            }
        }

        private static void WorkWithFiles(Files files)
        {
            Console.Write("Write path: ");
            String path = Console.ReadLine();

            Console.WriteLine("1 - Create new file \n2 - Read from file");
            Console.Write("Write number: ");

            if (Console.ReadLine().Equals("1"))
            {
                List<String> lines = new List<string>();
                while (true)
                {
                    Console.WriteLine("1 - Next line of the file \n2 - " +
                    "End of the file");

                    Console.Write("Write number: ");
                    if (Console.ReadLine().Equals("1"))
                    {
                        Console.Write("Write line: ");
                        lines.Add(Console.ReadLine());
                    }
                    else
                    {
                        break;
                    }
                }
                files.CreateFile(path, lines);
            }
            else
            {
                try
                {
                    List<String> lines = files.ReadFile(path);
                    Console.WriteLine("Result:");
                    foreach (String str in lines)
                    {
                        Console.WriteLine(str);
                    }
                } catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I can not find this file");
                    Console.ResetColor();
                }
                
            }
        }
    }
}

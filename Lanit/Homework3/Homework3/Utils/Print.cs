using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3.Utils
{
    /// <summary>
    /// Class that print text to the console
    /// </summary>
    public class Print
    {

        /// <summary>
        /// Method that print information to the console
        /// </summary>
        /// <param name="message"> Information about system </param>
        public void PrintInformation(string information)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            PrintText(information + Environment.NewLine);
        }
        /// <summary>
        /// Method that print error to the console
        /// </summary>
        /// <param name="message"> Information about error </param>
        public void PrintError(string message)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            PrintText(message + Environment.NewLine);
        }

        /// <summary>
        /// Method that print question to the console
        /// </summary>
        /// <param name="question">Question to user</param>
        public void PrintQuestion(string question)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintText(question);
        }

        /// <summary>
        /// Method that print result to the console
        /// </summary>
        /// <param name="result">Result of user request execution</param>
        public void PrintResult(string result)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintText(result);
        }

        private void PrintText(string result)
        {
            Console.Write(result);
            Console.ResetColor();
        }

        /// <summary>
        ///  Method that read user's answer
        /// </summary>
        /// <returns> User's answer</returns>
        public string ReadAnswer()
        {
            return Console.ReadLine();
        }
    }
}

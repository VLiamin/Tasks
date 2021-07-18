using System;

namespace PrintAndReadLibrary
{

    /// <summary>
    /// Class that print text to the console
    /// </summary>
    public class Console
    {

        /// <summary>
        /// Method that print error to the console
        /// </summary>
        /// <param name="message"> Information about error </param>
        public void PrintError(string message)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(message);
            System.Console.ResetColor();
        }

        /// <summary>
        /// Method that print question to the console
        /// </summary>
        /// <param name="question">Question to user</param>
        public void PrintQuestion(string question)
        {
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.Write(question);
            System.Console.ResetColor();
        }

        /// <summary>
        /// Method that print result to the console
        /// </summary>
        /// <param name="result">Result of user request execution</param>
        public void PrintResult(string result)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(result);
            System.Console.ResetColor();
        }

        /// <summary>
        ///  Method that read user's answer
        /// </summary>
        /// <returns> User's answer</returns>
        public string ReadAnswer()
        {
            return System.Console.ReadLine();
        }
    }
}

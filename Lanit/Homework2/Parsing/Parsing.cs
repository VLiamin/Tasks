using System;
using System.Net.Http;
using LocalConsole = PrintAndReadLibrary.Console;

namespace ParsingLibrary
{
    /// <summary>
    /// Class that parses site
    /// </summary>
    public class Parsing
    {
        public static LocalConsole localConsole = new LocalConsole();

        /// <summary>
        /// Method that parses site
        /// </summary>
        public void ParseTheSite()
        {
            
            string url;
            try
            {
                localConsole.PrintQuestion("1 - Parse \"https://yandex.ru\"\n2 - Parse another site\nNumber: ");
                String value = localConsole.ReadAnswer();
                if (value.Equals("1"))
                {
                    url = "https://yandex.ru/";
                } else if (value.Equals("2"))
                {
                    localConsole.PrintQuestion("Write path: ");
                    url = localConsole.ReadAnswer();
                } else
                {
                    return;
                }

                using (HttpClientHandler httpClientHandler = new HttpClientHandler())
                {
                    using (HttpClient httpClient = new HttpClient(httpClientHandler))
                    {
                        using (HttpResponseMessage httpResponseMessage = httpClient.GetAsync(url).Result)
                        {
                            var html = httpResponseMessage.Content.ReadAsStringAsync().Result;
                            localConsole.PrintResult(html);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                localConsole.PrintError(e.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    public class Files
    {
        public List<String> ReadFile(String path)
        {
            List<String> strings = new List<String>();

            try
            {
                using (StreamReader str = new StreamReader(path))
                {
                    String line;
                    while ((line = str.ReadLine()) != null)
                    {
                        strings.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return strings;
        }

        public void CreateFile(String path, List<String> strings)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    foreach (String line in strings) {
                        sw.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
    }
}

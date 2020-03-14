using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace cw2
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var odpowiedz = await httpClient.GetStringAsync(args[0]);
            var odpWstringu = odpowiedz.ToString();
            Console.WriteLine(odpWstringu+ "/n");
            String pattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]+\\b";
            Regex regex = new Regex(pattern);
            MatchCollection email = regex.Matches(odpowiedz);
            HashSet<String> set = new HashSet<string>();
            foreach (Match e in email)
            {
                set.Add(e.Value.ToUpper());
            }
            foreach(String s in set)
            {
                Console.WriteLine(s);
            }

        }
    }
}

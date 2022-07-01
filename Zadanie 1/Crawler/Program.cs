using System.Text.RegularExpressions;

namespace Crawler
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentNullException();
            }

            var url = args[0];
            
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                throw new ArgumentException();
            }

            try
            {
                using var client = new HttpClient();

                var response = await client.GetAsync(url);
                
                var content = await response.Content.ReadAsStringAsync();
                
                var regex = new Regex(@"[\w-\.]+@([\w-]+\.)+[\w-]{2,4}");

                var matches = regex
                    .Matches(content)
                    .Select(m => m.Groups[0].Value)
                    .ToList();
                
                if (matches.Count == 0)
                {
                    Console.WriteLine("Nie znaleziono adresów email");
                }

                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Błąd w czasie pobierania strony");
            }
        }
    }
}

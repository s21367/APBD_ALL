using System;
using System.IO;

namespace mp
{
    internal class Loger
    {
        private string path;
        public Loger(string path)
        {
            this.path = path;
        }


        public void log(string message)
        {
            using (StreamWriter writer = new(path, true))
            {
                DateTime now = DateTime.Now;
                writer.WriteLine(now.ToString() + " : " + "Błąd danych studenta: " + message);
            }
        }
    }
}

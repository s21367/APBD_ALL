using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace mp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var logger = new Loger("log.txt");
            
            try
            {
                if (args.Length < 3)
                {
                    throw new ArgumentException("Błąd danych wejściowych. Oczekuje: Adres pliku CSV, Adres ścieżki docelowej, Format danych");
                }

                var sourcePath = args[0];
                var resultFormat = args[2];
                var resultPath = args[1] + @"\result." + resultFormat;

                if (!File.Exists(@sourcePath))
                {
                    throw new FileNotFoundException("Plik nazwa nie istnieje: " + @sourcePath);
                }

                if (!Directory.Exists(@args[1]))
                {
                    throw new ArgumentException("Podana ścieżka jest niepoprawna: " + @args[1]);
                }

                var students = new HashSet<Student>(new StudentComparer());
                var studies = new HashSet<Studia>(new StudiaComparer());

                using var stream = new StreamReader(sourcePath);

                while (!stream.EndOfStream)
                {
                    var line = stream.ReadLine();
                    var data = line.Split(',');

                    try
                    {
                        var student = new Student(data);
                        
                        students.Add(student);
                    }
                    catch (Exception)
                    {
                        logger.log("Błąd danych studenta: " + line);
                    }
                }

                foreach (var s in students)
                {
                    var grade = s.studies;

                    grade.ForEach(k =>
                        studies.Add(new Studia(k.name))
                    );
                }

                var jArrayStudenci = new JArray();
                var jArrayStudia = new JArray();

                foreach (Student s in students)
                {
                    jArrayStudenci.Add(s.toJson());
                }

                foreach (Studia s in studies)
                {
                    jArrayStudia.Add(s.toJson());
                }

                JObject result = new(
                    new JObject(
                        new JProperty("uczelnia",
                            new JObject(
                                new JProperty("createdAt", DateTime.Today.ToString("dd.MM.yyyy")),
                                new JProperty("author", "Zachariasz Szymala"),
                                new JProperty("studenci", jArrayStudenci),
                                new JProperty("activeStudies", jArrayStudia)
                            )
                        )
                    )
                );

                File.WriteAllText(@resultPath, result.ToString());
            }
            catch (Exception e)
            {
                logger.log($"Błąd danych studenta: {e.Message}");
                throw;
            }
        }
    }
}



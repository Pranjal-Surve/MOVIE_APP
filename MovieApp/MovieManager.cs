using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MovieApp;
using static MovieApp.MovieException;

namespace MovieApp
{
    public class MovieManager
    {
        public void AddMovie(List<Movie> movies)
        {
            Console.WriteLine("Enter Movie Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Movie Genre: ");
            string genre = Console.ReadLine();

            Console.WriteLine("Enter Release Date (year): ");
            int releaseDate = int.Parse(Console.ReadLine());

            // Generates unique ID
            string id = GenerateUniqueId(name, genre, releaseDate, movies);

            movies.Add(new Movie(id, name, genre, releaseDate));

            SerializeDeserialize.SerializeData(movies);

            Console.WriteLine();
            Console.WriteLine("Movie Added Successfully!!");
        }

        private string GenerateUniqueId(string name, string genre, int releaseDate, List<Movie> movies)
        {
            // Extracts the first two characters of each attribute and the last two digits of the year
            string namePart = name.Length >= 2 ? name.Substring(0, 2) : name.PadRight(2, 'X');
            string genrePart = genre.Length >= 2 ? genre.Substring(0, 2) : genre.PadRight(2, 'X');
            string yearPart = releaseDate.ToString("00").Substring(2, 2);

            // Combine the parts to form the ID
            string baseId = $"{namePart}{genrePart}{yearPart}";

            // Ensure the ID is unique
            int counter = 1;
            string uniqueId = baseId;

            while (movies.Any(movie => movie.Id == uniqueId))
            {
                uniqueId = $"{baseId}{counter++}";
            }

            return uniqueId;
        }

        public void DeleteMovie(List<Movie> movies, string id)
        {
            bool flag = false;
            for (int i = 0; i < movies.Count; i++)
            {
                if (movies[i].Id == id)
                {
                    movies.RemoveAt(i);
                    flag = true;

                }
            }
            SerializeDeserialize.SerializeData(movies);
            if (flag)
            {
                Console.WriteLine();
                Console.WriteLine("Movie Deleted Successfully!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Movie doesn't exist!");
                Console.WriteLine();
            }
        }
        public static void PrintAllMovies(List<Movie> movies)
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"| {"ID",-15} | {"Name",-15} | {"Genre",-10} | {"Release Date",-12} |");
            Console.WriteLine("-----------------------------------------------------------------");

            foreach (var movie in movies)
            {
                Console.WriteLine($"| {movie.Id,-15} | {movie.Name,-15} | {movie.Genre,-10} | {movie.ReleaseDate,-12} |");
            }

            Console.WriteLine("-----------------------------------------------------------------");
        }       

    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using MovieApp;
using Newtonsoft.Json;

namespace MovieApp
{
    public class SerializeDeserialize
    {
        public static void SerializeData(List<Movie> movies)
        {
            File.WriteAllText("Moviesdata.json", JsonConvert.SerializeObject(movies));
        }
        public static List<Movie> DeserializeData()
        {
            List<Movie> movies = new List<Movie>();
            string filename = "MoviesData.json";
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
            else
            {
                File.WriteAllText("Accountdata.json", JsonConvert.SerializeObject(movies));

            }
            return movies;
        }
    }
}

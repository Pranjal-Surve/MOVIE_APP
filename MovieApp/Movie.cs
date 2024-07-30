using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using MovieApp;

namespace MovieApp
{
    public class Movie
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int ReleaseDate { get; set; }

        public Movie()
        {

        }
        public Movie(string id, string name, string genre, int releaseDate)
        {
            Name = name;
            Id = id;
            Genre = genre;
            ReleaseDate = releaseDate;
        }       
    }
}

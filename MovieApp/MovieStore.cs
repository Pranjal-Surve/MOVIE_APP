using System;
using System.Collections;
using System.Collections.Generic;
using static MovieApp.MovieException;

namespace MovieApp
{
    public class MovieStore
    {
        public static void CallMainMenu()
        {
            MovieManager movieManager = new MovieManager();
            List<Movie> movies = new List<Movie>();
            movies = SerializeDeserialize.DeserializeData(); //Deserialize data
            Console.WriteLine("---------------------------------------------------------Welcome--------------------------------------------------------");

            int operation = 0;
            while (operation != 4)
            {
                Console.WriteLine();
                Console.WriteLine("Enter 1 to add movie: ");
                Console.WriteLine();
                Console.WriteLine("Enter 2 to Delete movie:  ");
                Console.WriteLine();
                Console.WriteLine("Enter 3 to Display Movie:");


                operation = Convert.ToInt16(Console.ReadLine());

                switch (operation)
                {
                    case 1:
                        if (movies.Count != 5)
                        {
                            movieManager.AddMovie(movies);
                        }
                        else
                        {
                            Console.WriteLine("Cannot add Movies more than 5!");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter your Movie ID: ");
                        string moviNumberToBeDeleted = Console.ReadLine();
                        movieManager.DeleteMovie(movies, moviNumberToBeDeleted);
                        break;

                    case 3:
                        if (movies.Count == 0)
                        {
                            throw new MovieStoreEmptyException();
                        }
                        else
                        {
                            MovieManager.PrintAllMovies(movies);
                        }
                        break;

                    case 4:
                    default:
                        Console.WriteLine("Enter valid number");
                        break;

                }
                Console.WriteLine();
                Console.WriteLine("Do you want to continue? (y/n)");
                string continueInput = Console.ReadLine().Trim().ToLower();

                if (continueInput != "y")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
            }
        }
    }
}
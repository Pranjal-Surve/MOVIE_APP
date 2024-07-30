
namespace MovieApp
{
    public class MovieException
    {
        public class MovieStoreEmptyException : Exception
        {
            public MovieStoreEmptyException() : base("Movie store is empty!") { }

        }
    }
}

namespace RobotsParser.Exceptions
{
    public class InvalidGridException : Exception
    {
        public InvalidGridException()
            : base()
        {

        }

        public InvalidGridException(string message)
            : base(message) 
        {

        }

        public InvalidGridException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}

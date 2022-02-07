namespace RobotsParser.Exceptions
{
    public class InvalidGridException : InvalidInputException
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

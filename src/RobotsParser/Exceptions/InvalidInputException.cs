namespace RobotsParser.Exceptions
{
    public abstract class InvalidInputException : Exception
    {
        protected InvalidInputException()
            : base()
        {

        }

        protected InvalidInputException(string message)
            : base(message)
        {

        }

        protected InvalidInputException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}

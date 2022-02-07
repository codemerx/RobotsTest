namespace RobotsParser.Exceptions
{
    public class InvalidOrientationException : InvalidInputException
    {
        public InvalidOrientationException()
            : base()
        {

        }

        public InvalidOrientationException(string message)
            : base(message)
        {

        }

        public InvalidOrientationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}

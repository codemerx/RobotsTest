namespace RobotsParser.Exceptions
{
    public class InvalidInstructionException : InvalidInputException
    {
        public InvalidInstructionException()
            : base()
        {

        }

        public InvalidInstructionException(string message)
            : base(message)
        {

        }

        public InvalidInstructionException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}

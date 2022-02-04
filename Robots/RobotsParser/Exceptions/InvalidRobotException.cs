namespace RobotsParser.Exceptions
{
    public class InvalidRobotException : Exception
    {
        public InvalidRobotException()
            : base()
        {

        }

        public InvalidRobotException(string message)
            : base(message)
        {

        }

        public InvalidRobotException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}

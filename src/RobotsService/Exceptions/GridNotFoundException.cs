namespace RobotsService.Exceptions
{
    public class GridNotFoundException : Exception
    {
        public GridNotFoundException()
            : base()
        {

        }

        public GridNotFoundException(string message)
            : base(message)
        {

        }

        public GridNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}

namespace OnlineRadioDatabase
{
    public class InvalidSongLengthException : InvalidSongException
    {
        public InvalidSongLengthException()
            : base()
        {
        }

        public InvalidSongLengthException(string message)
            : base(message)
        {
        }

        public override string Message => "Invalid song length.";
    }
}

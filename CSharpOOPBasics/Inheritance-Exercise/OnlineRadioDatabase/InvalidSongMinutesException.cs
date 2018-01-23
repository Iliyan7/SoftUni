namespace OnlineRadioDatabase
{
    public class InvalidSongMinutesException : InvalidSongLengthException
    {
        public InvalidSongMinutesException()
            : base()
        {
        }

        public InvalidSongMinutesException(string message)
            : base(message)
        {
        }

        public override string Message => "Song minutes should be between 0 and 14.";
    }
}

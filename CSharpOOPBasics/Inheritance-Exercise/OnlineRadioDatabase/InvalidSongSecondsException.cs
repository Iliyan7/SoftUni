namespace OnlineRadioDatabase
{
    public class InvalidSongSecondsException : InvalidSongLengthException
    {
        public InvalidSongSecondsException()
            : base()
        {
        }

        public InvalidSongSecondsException(string message)
            : base(message)
        {
        }

        public override string Message => "Song seconds should be between 0 and 59.";
    }
}

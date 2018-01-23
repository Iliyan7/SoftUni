namespace OnlineRadioDatabase
{
    public class InvalidSongNameException : InvalidSongException
    {
        public InvalidSongNameException()
            : base()
        {
        }

        public InvalidSongNameException(string message)
            : base(message)
        {
        }

        public override string Message => "Song name should be between 3 and 20 symbols.";
    }
}

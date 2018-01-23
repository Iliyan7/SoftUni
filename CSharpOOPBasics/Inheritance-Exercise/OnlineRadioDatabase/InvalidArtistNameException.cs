namespace OnlineRadioDatabase
{
    public class InvalidArtistNameException : InvalidSongException
    {
        public InvalidArtistNameException()
            : base()
        {
        }

        public InvalidArtistNameException(string message)
            : base(message)
        {
        }

        public override string Message => "Artist name should be between 3 and 20 symbols.";
    }
}

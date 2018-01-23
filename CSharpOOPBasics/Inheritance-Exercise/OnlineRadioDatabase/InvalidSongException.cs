using System;

namespace OnlineRadioDatabase
{
    public class InvalidSongException : Exception
    {
        public InvalidSongException()
            : base()
        {
        }

        public InvalidSongException(string message)
            : base(message)
        {
        }

        public override string Message => "Invalid song.";
    }
}

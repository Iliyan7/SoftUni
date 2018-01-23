namespace OnlineRadioDatabase
{
    public class Song
    {
        private string artistName;
        private string songName;
        private string songLength;

        public Song(string artistName, string songName, string songLength)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.SongLength = songLength;
        }

        public string ArtistName
        {
            get { return this.artistName; }
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }

                this.artistName = value;
            }
        }

        public string SongName
        {
            get { return this.songName; }
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidSongNameException();
                }

                this.songName = value;
            }
        }

        public string SongLength
        {
            get { return this.songLength; }
            private set
            {
                var lenArg = value
                    .Split(':');

                var minutes = 0;
                var seconds = 0;

                if(!int.TryParse(lenArg[0], out minutes) || !int.TryParse(lenArg[1], out seconds))
                {
                    throw new InvalidSongLengthException();
                }

                if (minutes < 0 || minutes > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                if (seconds < 0 || seconds > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                this.songLength = value;
            }
        }

        public int Minutes()
        {
            return int.Parse(this.songLength.Split(':')[0]);
        }

        public int Seconds()
        {
            return int.Parse(this.songLength.Split(':')[1]);
        }
    }
}
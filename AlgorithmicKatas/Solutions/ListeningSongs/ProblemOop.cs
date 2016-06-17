using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.ListeningSongs
{
    /// <remarks>
    /// Test cases generated with 
    /// ({[^}]+})\r\n({[^}]+})\r\n(\d+)\r\n(\d+)\r\nReturns: (-?\d+)
    /// to
    /// [TestCase(new []$1, new []$2, $3, $4, $5)]
    /// </remarks>
    public class ProblemOop
    {
        /// <summary>
        /// For TopCoder, scored at 248.01
        /// </summary>
        public int listen(int[] durations1, int[] durations2, int minutes, int T)
        {
            return GetMaxSongs(durations1, durations2, minutes, T);
        }

        public static int GetMaxSongs(int[] durations1, int[] durations2, int minutes, int T)
        {
            var seconds = minutes * 60;

            var album1 = new Album(durations1.OrderBy(o => o));
            var album2 = new Album(durations2.OrderBy(o => o));

            var albums = new[] { album1, album2 };

            var mandatoryAlbumPlaylist = new MandatorySongPlayer(albums);

            for (var mandatoryIndex = 0; mandatoryIndex < T; ++mandatoryIndex)
            {
                int secondsPlayed;
                if (mandatoryAlbumPlaylist.TryPlaySong(seconds, out secondsPlayed))
                {
                    seconds -= secondsPlayed;
                }
                else
                {
                    return -1;
                }
            }

            var optionalAlbumPlaylist = new ShortestSongPlayer(albums);

            int optionalSecondsPlayed;
            while (optionalAlbumPlaylist.TryPlaySong(seconds, out optionalSecondsPlayed))
            {
                seconds -= optionalSecondsPlayed;
            }

            return albums.Sum(o => o.SongsPlayed);
        }

        private class Album
        {
            public int SongsPlayed { get; private set; }

            private readonly int[] _songDurations;
            private int _songIndex;

            public Album(IEnumerable<int> songDurations)
            {
                _songDurations = songDurations.ToArray();
            }

            public bool HasSongsToPlay
            {
                get { return _songIndex < _songDurations.Length; }
            }

            public int NextSongLength
            {
                get { return _songDurations[_songIndex]; }
            }

            public bool TryPlaySong(int secondsAvailable, out int secondsPlayed)
            {
                if (HasSongsToPlay)
                {
                    var songDuration = _songDurations[_songIndex];
                    if (songDuration <= secondsAvailable)
                    {
                        secondsPlayed = songDuration;
                        SongsPlayed += 1;
                        _songIndex += 1;

                        return true;
                    }
                }

                secondsPlayed = 0;
                return false;
            }
        }

        private class MandatorySongPlayer
        {
            private readonly IEnumerable<Album> _albumPlaylists;

            public MandatorySongPlayer(IEnumerable<Album> albumPlaylists)
            {
                _albumPlaylists = albumPlaylists;
            }

            public bool TryPlaySong(int secondsAvailable, out int totalSecondsPlayed)
            {
                totalSecondsPlayed = 0;

                foreach (var albumPlaylist in _albumPlaylists)
                {
                    int secondsPlayed;
                    if (!albumPlaylist.TryPlaySong(secondsAvailable, out secondsPlayed))
                    {
                        return false;
                    }

                    secondsAvailable -= secondsPlayed;
                    totalSecondsPlayed += secondsPlayed;
                }

                return true;
            }
        }

        private class ShortestSongPlayer
        {
            private readonly IEnumerable<Album> _albumPlaylists;

            public ShortestSongPlayer(IEnumerable<Album> albumPlaylists)
            {
                _albumPlaylists = albumPlaylists;
            }

            public bool TryPlaySong(int secondsAvailable, out int totalSecondsPlayed)
            {
                totalSecondsPlayed = 0;

                int secondsPlayed;
                while (TryPlayNextSong(secondsAvailable, out secondsPlayed))
                {
                    secondsAvailable -= secondsPlayed;
                    totalSecondsPlayed += secondsPlayed;
                }

                return totalSecondsPlayed > 0;
            }

            private bool TryPlayNextSong(int secondsAvailable, out int secondsPlayed)
            {
                var albumPlaylistsWithSongs = _albumPlaylists.Where(o => o.HasSongsToPlay).ToArray();
                if (albumPlaylistsWithSongs.Any())
                {
                    var nextAlbum = albumPlaylistsWithSongs.Min(o => o.NextSongLength);
                    var nextPlayList = albumPlaylistsWithSongs.First(o => o.NextSongLength == nextAlbum);
                    return nextPlayList.TryPlaySong(secondsAvailable, out secondsPlayed);
                }

                secondsPlayed = 0;
                return false;
            }
        }
    }
}

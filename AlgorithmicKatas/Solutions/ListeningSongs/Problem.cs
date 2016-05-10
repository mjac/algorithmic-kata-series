using System;

namespace Solutions.ListeningSongs
{
    public static class Problem
    {
        public static int GetMaxSongs(int[] durations1, int[] durations2, int minutes, int T)
        {
            var seconds = minutes * 60;

            if (durations1.Length < T || durations2.Length < T)
            {
                return -1;
            }

            Array.Sort(durations1);
            int albumIndex1 = 0;

            Array.Sort(durations2);
            int albumIndex2 = 0;

            int totalSongs = 0;

            for (int mandatoryIndex = 0; mandatoryIndex < T; ++mandatoryIndex)
            {
                var songDuration1 = durations1[albumIndex1];
                if (songDuration1 > seconds)
                {
                    return -1;
                }

                totalSongs += 1;
                seconds -= songDuration1;
                albumIndex1 += 1;

                var songDuration2 = durations2[albumIndex2];
                if (songDuration2 > seconds)
                {
                    return -1;
                }

                totalSongs += 1;
                seconds -= songDuration2;
                albumIndex2 += 1;
            }

            while (albumIndex1 < durations1.Length || albumIndex2 < durations2.Length)
            {
                if (albumIndex1 < durations1.Length && albumIndex2 < durations2.Length)
                {
                    var songDuration1 = durations1[albumIndex1];
                    var songDuration2 = durations2[albumIndex2];

                    if (songDuration1 < songDuration2)
                    {
                        if (songDuration1 > seconds)
                        {
                            return totalSongs;
                        }

                        totalSongs += 1;
                        seconds -= songDuration1;
                        albumIndex1 += 1;
                    }
                    else
                    {
                        if (songDuration2 > seconds)
                        {
                            return totalSongs;
                        }

                        totalSongs += 1;
                        seconds -= songDuration2;
                        albumIndex2 += 1;
                    }
                }
                else if (albumIndex1 < durations1.Length)
                {
                    var songDuration1 = durations1[albumIndex1];
                    if (songDuration1 > seconds)
                    {
                        return totalSongs;
                    }

                    totalSongs += 1;
                    seconds -= songDuration1;
                    albumIndex1 += 1;
                }
                else
                {
                    var songDuration2 = durations2[albumIndex2];
                    if (songDuration2 > seconds)
                    {
                        return totalSongs;
                    }

                    totalSongs += 1;
                    seconds -= songDuration2;
                    albumIndex2 += 1;
                }
            }

            return totalSongs;
        }
    }
}
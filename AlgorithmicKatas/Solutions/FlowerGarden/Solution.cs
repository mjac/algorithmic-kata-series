using System.Collections.Generic;
using System.Linq;

namespace Solutions.FlowerGarden
{
    public class Solution
    {
        public static int[] getOrdering(int[] height, int[] bloom, int[] wilt)
        {
            var flowers = height.Select((o, i) => new Flower
            {
                Height = o,
                Bloom = bloom[i],
                Wilt = wilt[i],
            }).ToArray();

            foreach (var f1 in flowers)
            {
                foreach (var f2 in flowers)
                {
                    if (f1 != f2 && f1.IsBlockedBy(f2))
                    {
                        f1.BlockedBy.Add(f2);
                        f2.Blocks.Add(f1);
                    }
                }
            }

            var orderedFlowers = new List<Flower>();

            var flowersToPlace = flowers.ToList();
            while (flowersToPlace.Any())
            {
                var min = flowersToPlace.OrderByDescending(o => o.Height).First(o => !o.IsBlocking);
                foreach (var blockedFlower in min.BlockedBy)
                {
                    blockedFlower.Blocks.Remove(min);
                }
                min.BlockedBy.Clear();

                flowersToPlace.Remove(min);
                orderedFlowers.Add(min);
            }

            return orderedFlowers.Select(o => o.Height).ToArray();
        }

        private class Flower
        {
            public Flower()
            {
                Blocks = new List<Flower>();
                BlockedBy = new List<Flower>();
            }

            public int Height { get; set; }
            public int Bloom { get; set; }
            public int Wilt { get; set; }

            public List<Flower> Blocks { get; set; }
            public List<Flower> BlockedBy { get; set; }

            public bool IsBlocking => Blocks.Any();

            public bool IsBlockedBy(Flower f2)
            {
                if (Height > f2.Height)
                {
                    return false;
                }

                if (Bloom > f2.Wilt)
                {
                    return false;
                }

                if (Wilt < f2.Bloom)
                {
                    return false;
                }

                return true;
            }
        }
    }
}

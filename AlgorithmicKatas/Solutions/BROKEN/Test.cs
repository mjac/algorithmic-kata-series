using System;
using System.Collections.Generic;

namespace Solutions.BROKEN
{
    public class Test
    {
        public static void Main()
        {
            string keysStillWorkingLine;
            while ((keysStillWorkingLine = Console.ReadLine()) != null)
            {
                int keysStillWorking;
                if (int.TryParse(keysStillWorkingLine, out keysStillWorking))
                {
                    if (keysStillWorking == 0)
                    {
                        return;
                    }

                    var textToType = Console.ReadLine();
                    var writeText = GetLargestSubstringLength(keysStillWorking, textToType);
                    Console.WriteLine(writeText);
                }
            }
        }

        public static int GetLargestSubstringLength(int keysStillWorking, string textToType)
        {
            if (keysStillWorking <= 0)
            {
                return 0;
            }

            int maxLength = 0;

            var x = new CharacterStore(keysStillWorking);

            var substringStartIndex = 0;
            for (int overallTextIndex = 0; overallTextIndex < textToType.Length; ++overallTextIndex)
            {
                var character = textToType[overallTextIndex];

                while (!x.CanAddCharacter(character))
                {
                    var previousCharacter = textToType[substringStartIndex];
                    x.RemoveCharacter(previousCharacter);
                    substringStartIndex++;

                    if (substringStartIndex >= textToType.Length || substringStartIndex > overallTextIndex)
                    {
                        throw new Exception("Possible infinite loop due to substringStartIndex");
                    }
                }

                x.AddCharacter(character);

                if (x.CurrentLength > maxLength)
                {
                    maxLength = x.CurrentLength;
                }
            }

            return maxLength;
        }

        private class CharacterStore
        {
            private readonly int _keysStillWorking;
            private readonly Dictionary<char, int> _keyToCountMap = new Dictionary<char, int>();

            public int CurrentLength { get; private set; } = 0;

            public CharacterStore(int keysStillWorking)
            {
                _keysStillWorking = keysStillWorking;
            }

            public bool CanAddCharacter(char character)
            {
                if (_keyToCountMap.Count < _keysStillWorking)
                    return true;

                return _keyToCountMap.ContainsKey(character);
            }

            public void AddCharacter(char character)
            {
                if (!_keyToCountMap.ContainsKey(character))
                {
                    _keyToCountMap[character] = 0;
                }

                _keyToCountMap[character]++;
                CurrentLength++;
            }

            public void RemoveCharacter(char character)
            {
                _keyToCountMap[character]--;
                CurrentLength--;

                if (_keyToCountMap[character] == 0)
                {
                    _keyToCountMap.Remove(character);
                }
            }
        }
    }
}

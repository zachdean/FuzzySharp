using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzySharp.Extensions
{
    internal static class ReadOnlySpanExtensions
    {
        public static List<string> SplitLetterOnlyWords(this ReadOnlySpan<char> input)
        {
            var words = new List<string>();
            var sb = new StringBuilder(input.Length);
            bool hasNonletter = false;
            foreach (var c in input)
            {
                if (c == ' ')
                {
                    if (!hasNonletter)
                    {
                        words.Add(sb.ToString());
                    }

                    hasNonletter = false;
                    sb.Clear();
                    continue;
                }

                if (!char.IsLetter(c))
                {
                    hasNonletter = true;
                }

                sb.Append(c);
            }

            return words;
        }

        public static List<string> SplitWhiteSpace(this ReadOnlySpan<char> input)
        {
            var words = new List<string>();
            var sb = new StringBuilder(input.Length);
            string word;
            foreach (var c in input)
            {
                if (c == ' ')
                {
                    word = sb.ToString();
                    if (word.Length > 0)
                    {
                        words.Add(word);
                    }

                    sb.Clear();
                    continue;
                }

                sb.Append(c);
            }

            word = sb.ToString();
            if (word.Length > 0)
            {
                words.Add(word);
            }

            return words;
        }
    }
}
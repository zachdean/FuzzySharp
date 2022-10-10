using System;
using System.Text;

namespace FuzzySharp.PreProcess
{
    public delegate ReadOnlySpan<char> StringProcessorDelegate(ReadOnlySpan<char> input);

    internal class StringPreprocessorFactory
    {
        private static ReadOnlySpan<char> Default(ReadOnlySpan<char> input)
        {
            var trimmedInput = input.Trim();
            var output = new char[trimmedInput.Length];

            for (var i = 0; i < trimmedInput.Length; i++)
            {
                var c = trimmedInput[i];
                if (char.IsLetterOrDigit(c) || c == ' ')
                {
                    output[i] = char.ToLower(c);
                }
                else
                {
                    output[i] = ' ';
                }
            }

            return output;
        }

        internal static string Default(string input)
        {
            var trimmedInput = input.Trim();
            var output = new StringBuilder(trimmedInput.Length);

            foreach (var c in trimmedInput)
            {
                if (char.IsLetterOrDigit(c) || c == ' ')
                {
                    output.Append(char.ToLower(c));
                }
                else
                {
                    output.Append(' ');
                }
            }

            return output.ToString();
        }

        public static StringProcessorDelegate GetPreprocessor(PreprocessMode mode)
        {
            switch (mode)
            {
                case PreprocessMode.Full:
                    return Default;
                case PreprocessMode.None:
                    return s => s;
                default:
                    throw new InvalidOperationException($"Invalid string preprocessor mode: {mode}");
            }
        }
    }
}

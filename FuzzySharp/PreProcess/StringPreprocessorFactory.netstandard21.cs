using System;
using System.Text;

namespace FuzzySharp.PreProcess
{
    internal class StringPreprocessorFactory
    {
        private static string Default(string input)
        {
            var trimmedInput = input.AsSpan().Trim();
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

        public static Func<string, string> GetPreprocessor(PreprocessMode mode)
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

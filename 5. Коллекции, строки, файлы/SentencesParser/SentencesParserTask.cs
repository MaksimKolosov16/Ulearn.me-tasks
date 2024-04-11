using System.Text;

namespace TextAnalysis;

static class SentencesParserTask
{
    private static readonly char[] separators = new[] { '.', '!', '?', ';', ':', '(', ')' };

    public static List<List<string>> ParseSentences(string text)
    {
        var result = GetParsedSentences(text);

        return result;
    }

    public static List<List<string>> GetParsedSentences(string text)
    {
        var sentences = text.Split(separators);

        return sentences.Select(ParseSentenceToWords).ToList();
    }

    public static List<string> ParseSentenceToWords(string sentence)
    {
        var words = new List<string>();

        var word = new StringBuilder();

        for (int i = 0; i < sentence.Length; i++)
        {
            var symbol = sentence[i];

            if (char.IsLetter(symbol) || symbol == '\'')
                word.Append(symbol);
            else
            {
                if (symbol == '\\')
                    i++; // skip next letter, because it is an escape sequence

                words.Add(word.ToString().ToLower());
                word.Clear();
            }
        }

        words.Add(word.ToString().ToLower());

        return words.Where(w => w.Length > 0).ToList();
    }
}
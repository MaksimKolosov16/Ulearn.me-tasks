using System.Text;

namespace TextAnalysis;

static class SentencesParserTask
{
    private static readonly char[] separators = new[] { '.', '!', '?', ';', ':', '(', ')' };

    public static List<List<string>> ParseSentences(string text)
    {
        return GetNotEmptyParsedSentences(text);
    }

    private static List<List<string>> GetNotEmptyParsedSentences(string text)
    {
        var result = new List<List<string>>();

        var sentences = text.Split(separators);

        foreach (var sentence in sentences)
        {
            var splitedToWords = sentence.ToWordsInLowerCase();

            var withoutEmptyWords = splitedToWords.Where(w => w.Any());

            if (withoutEmptyWords.Any())
                result.Add(withoutEmptyWords.ToList());
        }

        return result;
    }

    private static IEnumerable<string> ToWordsInLowerCase(this string sentence)
    {
        var word = new StringBuilder();

        for (var i = 0; i < sentence.Length; i++)
        {
            var symbol = sentence[i];

            if (char.IsLetter(symbol) || symbol == '\'')
                word.Append(char.ToLower(symbol));
            else
            {
                yield return word.ToString();
                word.Clear();
            }
        }

        yield return word.ToString().ToLower();
    }
}
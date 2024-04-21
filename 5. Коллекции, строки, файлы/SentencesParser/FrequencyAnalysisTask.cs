using System.ComponentModel.DataAnnotations;

namespace TextAnalysis;

static class FrequencyAnalysisTask
{
    public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
    {
        var result = new Dictionary<string, string>();

        var dictionaryOfFrequency = new Dictionary<string, Dictionary<string, int>>();

        foreach (var sentence in text)
        {
            AddBigrams(sentence, dictionaryOfFrequency, result);
            AddTrigrams(sentence, dictionaryOfFrequency, result);
        }

        return result;
    }
    public static void AddBigrams(
        List<string> sentence, 
        Dictionary<string, Dictionary<string, int>> nextWordFrequency, 
        Dictionary<string, string> nGrams)
    {
        for (var i = 0; i < sentence.Count - 1; i++)
        {
            var word = sentence[i];
            var nextWord = sentence[i + 1];

            if (nextWordFrequency.ContainsKey(word) is false)
                nextWordFrequency.Add(word, new Dictionary<string, int>());

            var nextWords = nextWordFrequency[word];

            if (nextWords.ContainsKey(nextWord) is false)
                nextWords.Add(nextWord, 0);

            nextWords[nextWord]++;

            if (nGrams.ContainsKey(word) is false)
                nGrams.Add(word, nextWord);
            else 
            {
                var currentNextWord = nGrams[word];

                var newNextWordCount = nextWordFrequency[word][nextWord];
                if (newNextWordCount > nextWordFrequency[word][currentNextWord]
                    || newNextWordCount == nextWordFrequency[word][currentNextWord] && string.CompareOrdinal(nextWord, currentNextWord) < 0)
                    nGrams[word] = nextWord;
            }
        }
    }

    public static void AddTrigrams(
        List<string> sentence,
        Dictionary<string, Dictionary<string, int>> nextWordFrequency,
        Dictionary<string, string> nGrams)
    {
        for (var i = 0; i < sentence.Count - 2; i++)
        {
            string word = string.Format("{0} {1}", sentence[i], sentence[i + 1]);
            var nextWord = sentence[i + 2];

            if (nextWordFrequency.ContainsKey(word) is false)
                nextWordFrequency.Add(word, new Dictionary<string, int>());

            var nextWords = nextWordFrequency[word];

            if (nextWords.ContainsKey(nextWord) is false)
                nextWords.Add(nextWord, 0);

            nextWords[nextWord]++;

            if (nGrams.ContainsKey(word) is false)
                nGrams.Add(word, nextWord);
            else
            {
                var currentNextWord = nGrams[word];

                var newNextWordCount = nextWordFrequency[word][nextWord];
                if (newNextWordCount > nextWordFrequency[word][currentNextWord]
                    || newNextWordCount == nextWordFrequency[word][currentNextWord] && string.CompareOrdinal(nextWord, currentNextWord) < 0)
                    nGrams[word] = nextWord;
            }
        }
    }
}
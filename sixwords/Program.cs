using System;
using System.IO;

string fileName = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
        
IDictionary<int, IList<string>> wordsByLength = new Dictionary<int, IList<string>>();

using (StreamReader reader = new StreamReader(fileName)) {
    string word;
    while ((word = reader.ReadLine()) != null) {
        int wordLength = word.Length;

        if (!wordsByLength.ContainsKey(wordLength)) {
            wordsByLength[wordLength] = new List<string>();
        }

        wordsByLength[wordLength].Add(word);

    }
}


IList<string> targetWords = wordsByLength[6];

BuildWord("", new List<string>());


void BuildWord(string currentWord, IList<string> usedParts) {
    int remainingLengths = 6 - currentWord.Length;
    Console.WriteLine(currentWord);
    if (remainingLengths == 0) {
        if (targetWords.Contains(currentWord)) {
            Console.WriteLine(string.Join(" + ", usedParts) + " = " + currentWord);
        }
    } else {
        for (int i = 1; i <= remainingLengths && i < 6; i ++) {
            IList<string> wordsOfLengthI = wordsByLength[i];
            foreach(string word in wordsOfLengthI) {
                if (!usedParts.Contains(word)) {
                    IList<string> newUsedParts = new List<string>(usedParts);
                    newUsedParts.Add(word);
                    BuildWord(currentWord + word, newUsedParts);
                }
            }
        }
    }
}

using System;
using System.IO;

string fileName = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
        
ISet<string> maxLetterWords = new HashSet<string>();
ISet<string> availableStrings = new HashSet<string>();

using (StreamReader reader = new StreamReader(fileName)) {
    string word;
    while ((word = reader.ReadLine()) != null) {
        if (word.Length == 6) {
            maxLetterWords.Add(word);
        } else {
            availableStrings.Add(word);
        }

    }
}
foreach (string maxLetterWord in maxLetterWords) {
    BuildWord(maxLetterWord, "", new List<string>(), availableStrings);
}

void BuildWord(string targetWord, string currentWord, IList<string> usedStrings, ISet<string> remainingStrings) {
    if (currentWord.Length == 6) {
        Console.WriteLine($"{string.Join('+', usedStrings)} = {targetWord}");
    } else if (targetWord.Length > currentWord.Length) {
        int remainingLength = targetWord.Length - currentWord.Length;
        foreach (string part in remainingStrings) {
            if ( ( (part.Length <= remainingLength) && targetWord.Contains(currentWord+part) && !usedStrings.Contains(part) )) {
                //Console.WriteLine(currentWord);
                // Console.WriteLine(remainingLength);
                // Console.WriteLine(string.Join("+",usedStrings));
                List<string> newUsedStrings = new List<string>(usedStrings);
                HashSet<string> newRemainingStrings = new HashSet<string>(remainingStrings);
                newRemainingStrings.Remove(part);
                newUsedStrings.Add(part);
                BuildWord(targetWord, currentWord + part, newUsedStrings , newRemainingStrings);
            }
        }
    }
}


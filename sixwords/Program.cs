using System;
using System.IO;

string fileName = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
        
ISet<string> maxLetterWords = new HashSet<string>();
ISet<string> availableStrings = new HashSet<string>();

// TODO: make this dynamic
int maxLength = 6;

// read words line by line
using (StreamReader reader = new StreamReader(fileName)) {
    string word;
    while ((word = reader.ReadLine()) != null) {
        if (word.Length == maxLength) {
            maxLetterWords.Add(word);
        } else {
            availableStrings.Add(word);
        }

    }
}

// error handling
if (maxLetterWords.Count == 0 || availableStrings.Count == 0) {
    throw new InvalidDataException($"No {maxLength} letter words or no parts smaller than {maxLength} found");
}

// for each 6 letter word we try to find their combinations
foreach (string maxLetterWord in maxLetterWords) {
    BuildWord(maxLetterWord, "", new List<string>(), availableStrings);
}

// recursive function
void BuildWord(string targetWord, string currentWord, IList<string> usedStrings, ISet<string> remainingStrings) {
    // edge case
    if (currentWord.Length == maxLength) {
        Console.WriteLine($"{string.Join('+', usedStrings)} = {targetWord}");
    } else if (targetWord.Length > currentWord.Length) {
        int remainingLength = targetWord.Length - currentWord.Length;
        // try building on the current word
        foreach (string part in remainingStrings) {
            if ( ( (part.Length <= remainingLength) && targetWord.Contains(currentWord+part) && !usedStrings.Contains(part) )) {
                List<string> newUsedStrings = new List<string>(usedStrings);
                HashSet<string> newRemainingStrings = new HashSet<string>(remainingStrings);
                newRemainingStrings.Remove(part);
                newUsedStrings.Add(part);
                // recursive step
                BuildWord(targetWord, currentWord + part, newUsedStrings , newRemainingStrings);
            }
        }
    }
}


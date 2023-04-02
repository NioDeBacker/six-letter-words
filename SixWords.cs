using System;

using System.Collections.Generic;
using System.IO;

public class SixWords {
    public static void Main() {
        string fileName = Path.Combine(Directory.GetCurrentDirectory(), "\\input.txt");
        
 
        IEnumerable<string> lines = File.ReadLines(fileName);
        Console.WriteLine(String.Join(Environment.NewLine, lines));
    }
}
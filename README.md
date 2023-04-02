# 6 letter words

Coding challenge for Kenze.

To run the code, copy the repository and execute following commands

```bash
cd sixwords
dotnet run
```

## Notes on solution

- Not sure if relative path to get file is Windows proof (only tested on Mac)
- The problem could be seen as a directional graph where each shorter part points to a larger string it e.g "a" {"ab", "ake"}. Possibly this could shorten the runtime if we build this graph while reading the lines. I decided not to pursue this option because of the time constraints.

## Original challenge description

There's a file in the root of the repository, input.txt, that contains words of varying lengths (1 to 6 characters).

Your objective is to show all combinations of those words that together form a word of 6 characters. That combination must also be present in input.txt
E.g.:

```bash
foobar  
fo  
obar  
```

should result in the ouput:  

```bash
fo+obar=foobar
```

You can start by only supporting combinations of two words and improve the algorithm at the end of the exercise to support any combinations.

Treat this exercise as if you were writing production code; think unit tests, SOLID, clean code and avoid primitive obsession. Be mindful of changing requirements like a different maximum combination length, or a different source of the input data.

The solution must be stored in a git repo. After the repo is cloned, the application should be able to run with one command / script.

Don't spend too much time on this.

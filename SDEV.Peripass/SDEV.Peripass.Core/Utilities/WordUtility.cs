using System.Linq;

namespace SDEV.Peripass.Core.Utilities
{
    public class WordUtility
    {
        public static List<string> FindCombinations(string potentialOutcome, List<string> snippets)
        {
            List<string> result = new List<string>();

            // Get all snippets that can be the beginning of the outcome string
            var startSnippets = snippets.Where((s) => potentialOutcome.StartsWith(s)).ToList();
            Console.WriteLine("Creating combo for outcome {0}", potentialOutcome);

            foreach (var snippet in startSnippets)
            {
                var allMatches = FindMatches(potentialOutcome, potentialOutcome.Substring(snippet.Length), snippets, new List<string> { snippet }, new List<List<string>>());
                foreach (var match in allMatches)
                {
                    if (string.Concat(match) == potentialOutcome)
                    {
                        var resultString = string.Concat(string.Join('+', match), "=", potentialOutcome);
                        result.Add(resultString);
                        Console.WriteLine(resultString);
                    }
                }
            }

            return result;
        }

        public static List<List<string>> FindMatches(string originalOutcome, string outcomeSnippet, List<string> snippets, List<string> currentCombinations, List<List<string>> allMatches)
        {
            if (string.Concat(currentCombinations) == originalOutcome)
            {
                // Create new currentCombinations List so the Backtrack has no influence on this
                allMatches.Add(new List<string>(currentCombinations));
            }
            var nextSnippets = snippets.Where((s) => outcomeSnippet.StartsWith(s)).ToList();
            foreach (var snippet in nextSnippets)
            {
                currentCombinations.Add(snippet);
                var leftOverOutcomeSnippet = outcomeSnippet.Substring(snippet.Length);
                // Keep recursively finding matching until outcome has been reached
                FindMatches(originalOutcome, leftOverOutcomeSnippet, snippets, currentCombinations, allMatches);
                currentCombinations.RemoveAt(currentCombinations.Count - 1); // Backtrack: Remove last adition to continue with other potential matches
            }
            return allMatches;
        }

    }
}

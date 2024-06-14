using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SDEV.Peripass.Core.Utilities;
using SDEV.Peripass.Services.Contracts;
using SDEV.Peripass.WordExcercise.Models;

namespace SDEV.Peripass.WordExcercise
{
    class InputAnalysis
    {
        private readonly ILogger<InputAnalysis> _logger;
        private readonly IFileService _fileService;

        public InputAnalysis(ILogger<InputAnalysis> logger, IFileService fileService)
        {
            _logger = logger;
            _fileService = fileService;
        }

        public void Start(ScriptOptions options)
        {
            try
            {   // Retrieve file content
                _logger.LogInformation("Retrieving file content from location {0}", options.InputFileLocation);
                var words = _fileService.RetrieveFileContent(options.InputFileLocation);
                var distrinctWords = words.Distinct().ToList();
                _logger.LogInformation("Found {0} distrinct words in the input file", distrinctWords.Count);

                ProcessWords(options.CharacterCount, distrinctWords);
            } catch (Exception ex)
            {
                _logger.LogError("Something went wrong processing the input file: {0}", ex.Message);
            }
        }

        public void ProcessWords(int characterCount, List<string> words)
        {

            // Filter out all word options for the outcomes
            var potentialOutcomes = words.Where((word) => word.Length == characterCount).ToList();
            // Filter out all partial word snippets to use for combinations
            var wordSnippets = words.Where((word) => word.Length < characterCount).ToList();
            
            foreach (var word in potentialOutcomes)
            {
                WordUtility.FindCombinations(word, wordSnippets);
            }
        }
    }
}

using CommandLine;

namespace SDEV.Peripass.WordExcercise.Models
{
    public class ScriptOptions
    {
        [Option('i', "inputFile", Required = true, HelpText = "The location of the input file containing the word combinations")]
        public string InputFileLocation { get; set; }

        [Option('c', "characterCount", Required = true, HelpText = "The amount of characters in the words to form")]
        public string CharacterCount { get; set; }

        public static ScriptOptions RunOptionsAndReturnExitCode(ScriptOptions options)
        {
            return options;
        }

        public static ScriptOptions HandleParseError(IEnumerable<Error> errs)
        {
            return null;
        }
    }
}

using Microsoft.Extensions.Logging;
using SDEV.Peripass.WordExcercise.Models;

namespace SDEV.Peripass.WordExcercise
{
    class InputAnalysis
    {
        private readonly ILogger<InputAnalysis> _logger;

        public InputAnalysis(ILogger<InputAnalysis> logger)
        {
            _logger = logger;
        }

        public async Task Start(ScriptOptions options)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

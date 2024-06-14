using SDEV.Peripass.Services.Contracts;

namespace SDEV.Peripass.Services
{
    public class FileService : IFileService
    {

        public List<string> RetrieveFileContent(string filePath)
        {
            var words = File.ReadAllLines(filePath).ToList();
            return words;
        }
    }
}

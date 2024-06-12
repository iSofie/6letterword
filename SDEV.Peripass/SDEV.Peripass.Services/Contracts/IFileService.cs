namespace SDEV.Peripass.Services.Contracts
{
    public interface IFileService
    {
        List<string> RetrieveFileContent(string filePath);
    }
}

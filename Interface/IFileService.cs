namespace ConsoleAppTDD.Interface;

public interface IFileService
{
    bool SaveToFile(string filePath, string content);
    string GetContentFromFile(string filePath);
}

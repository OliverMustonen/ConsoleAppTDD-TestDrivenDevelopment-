﻿using ConsoleAppTDD.Interface;
using System.Diagnostics;

namespace ConsoleAppTDD.Services;

public class FileService : IFileService
{
    public string GetContentFromFile(string filePath)
    {
        try
        {
            if(File.Exists(filePath))
            {
                using var sr = new StreamReader(filePath);
                return sr.ReadToEnd();
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool SaveToFile(string filePath, string content)
    {
        try
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(content);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}

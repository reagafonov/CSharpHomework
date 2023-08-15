using System;
using System.IO;

namespace DZ17.Files;

public class ScanFileSystem
{
    public event EventHandler<FileNameEventArgs> OnFileNameFound;
    public bool Scan(string directory)
    {
        string[] fileNames = Array.Empty<string>();
        try
        {
            fileNames = Directory.GetFiles(directory);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        foreach (var fileName in fileNames)
        {
            if (FileNameFound(fileName))
                return true;
        }

        string[] subDirectories = Array.Empty<string>();
        try
        {
            subDirectories = Directory.GetDirectories(directory);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }

        foreach (var subDirectory in subDirectories)
        {
            if (Scan(subDirectory))
                return true;
        }

        return false;
    }

    private bool FileNameFound(string fileName)
    {
        var fileNameEventArgs = new FileNameEventArgs(fileName);
        OnFileNameFound?.Invoke(this, fileNameEventArgs);
        return fileNameEventArgs.CancelSearch;
    }
}
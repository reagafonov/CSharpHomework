using System;

namespace DZ17.Files;

public class FileNameEventArgs:EventArgs
{
    public string FileName { get; }

    public bool CancelSearch { get; set; } = false;
    
    public FileNameEventArgs(string fileName)
    {
        FileName = fileName;
    }
    
}
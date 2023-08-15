using System;
using DZ17.Files;

namespace DZ17;

public class FileSearcherToConsole: IDisposable
{
    private readonly ScanFileSystem _scanFileSystem;
    private readonly int _maxFileCount;
    private int _count = 0;
    private readonly string _prefix;
    
    public FileSearcherToConsole(int maxFileCount, ScanFileSystem scanFileSystem, string prefix)
    {
        this._maxFileCount = maxFileCount;
        _scanFileSystem = scanFileSystem;
        _prefix = prefix;
        _scanFileSystem.OnFileNameFound += OnFileNameFound;
    }

    private void OnFileNameFound(object? sender, FileNameEventArgs e)
    {
        Console.WriteLine($"{_prefix} {e.FileName}");
        _count++;
        if (_count == _maxFileCount)
            e.CancelSearch = true;
    }

    public void Dispose()
    {
        _scanFileSystem.OnFileNameFound -= OnFileNameFound;
    }
}
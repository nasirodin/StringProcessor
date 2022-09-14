namespace StringProcessor.IO;

public class CsvOutput : ICsvOutput
{
    private readonly string _fileName;

    public CsvOutput()
    {
        _fileName = "result.csv";
    }

    public CsvOutput(string fileName)
    {
        _fileName = fileName;
    }

    public void WriteToCsv(IEnumerable<string> data)
    {
        if (File.Exists(_fileName))
            File.Delete(_fileName);

        var columns = string.Join(",", data);
        File.WriteAllText(_fileName, columns);
    }
}
namespace StringProcessor.IO;

public interface ICsvOutput
{
    void WriteToCsv(IEnumerable<string> data);
}
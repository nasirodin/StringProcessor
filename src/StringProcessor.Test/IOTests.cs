using FluentAssertions;
using StringProcessor.IO;

namespace StringProcessor.Test;

public class IOTests
{
    [Fact]
    public void CreateCsvFileTest()
    {
        var fileName = Path.GetRandomFileName();
        var data = new[] { "1", "2", "3" };
        
        var csvOutput = new CsvOutput(fileName);
        csvOutput.WriteToCsv(data);

        File.Exists(fileName).Should().BeTrue();
        
        var fileContent = File.ReadAllText(fileName);
        fileContent.Should().NotBeEmpty();
        fileContent.Should().Be(string.Join(",", data));
        
        File.Delete(fileName);
    }
}
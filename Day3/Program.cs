using System;
using System.Text.RegularExpressions;

string fileName = "day3.txt";
string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", fileName);

if (!File.Exists(filePath))
{
    Console.WriteLine($"Error: File '{fileName}' not found at '{Path.GetFullPath(filePath)}'");
    return;
}

string readFile = await File.ReadAllTextAsync(filePath);

var pattern = MyRegex();
var matches = pattern.Matches(readFile);
long sum = 0;
bool active = true;

foreach (Match match in matches)
{
    string each = match.Value;
    if (match.Groups[1].Success)
    {
        if (active)
        {
            int each1 = int.Parse(match.Groups[1].Value);
            int each2 = int.Parse(match.Groups[2].Value);
            long multipEach = each1 * each2;
            sum += multipEach;

            Console.WriteLine($"A:{each} g1:{each1} g2:{each2} T:{multipEach} ACC:{sum}");
        }
    }
    else
    {
        active = "do()".Equals(match.Value);
    }
}

Console.WriteLine($"Final: {sum}");

static partial class Program
{
    [GeneratedRegex(@"mul\(([0-9]{1,3}),([0-9]{1,3})\)|do\(\)|don't\(\)")]
    private static partial Regex MyRegex();
}
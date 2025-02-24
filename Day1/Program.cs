string fileName = "day1.txt";
string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", fileName);

List<string> readFile = [.. (await File.ReadAllLinesAsync(filePath))];
Console.WriteLine(string.Join(", ", readFile));

List<int> left = [];
List<int> right = [];

foreach (var line in readFile)
{
    var parts = line.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length >= 2)
    {
        left.Add(int.Parse(parts[0]));
        right.Add(int.Parse(parts[1]));
    }
}

Console.WriteLine($"Left: {string.Join(", ", left)}");
Console.WriteLine($"Right: {string.Join(", ", right)}");

left.Sort();
right.Sort();

Console.WriteLine($"Sorted Left: {string.Join(", ", left)}");
Console.WriteLine($"Sorted Right: {string.Join(", ", right)}");

List<int> diff = [];
int total = 0;

for (int i = 0; i < left.Count; i++)
{
    int difference = Math.Abs(left[i] - right[i]);
    diff.Add(difference);
    total += difference;
}

Console.WriteLine($"Differences: {string.Join(", ", diff)}");
Console.WriteLine($"Total Difference: {total}");

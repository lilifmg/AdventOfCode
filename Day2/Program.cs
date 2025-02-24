string fileName = "day2.txt";
string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", fileName);

if (!File.Exists(filePath))
{
    Console.WriteLine($"Error: File '{fileName}' not found at '{Path.GetFullPath(filePath)}'");
    return;
}

List<string> readFile = [.. (await File.ReadAllLinesAsync(filePath))];
Console.WriteLine("File contents:");
Console.WriteLine(string.Join("\n", readFile));

List<List<int>> lista = [];
List<int> results = [];

foreach (var line in readFile)
{
    List<int> elem = line.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries)
                         .Select(int.Parse)
                         .ToList();

    int lineIsSafe = IsSafe(elem);

    if (lineIsSafe == 1)
    {
        results.Add(lineIsSafe);
        lista.Add(elem);
        continue;
    }
    else
    {
        for (int j = 0; j < elem.Count; j++)
        {
            List<int> modifiedLevels = new(elem);
            modifiedLevels.RemoveAt(j);
            lineIsSafe = IsSafe(modifiedLevels);
            if (lineIsSafe == 1)
            {
                break;
            }
        }
    }

    results.Add(lineIsSafe);
    lista.Add(elem);
}

Console.WriteLine("Processed Lists:");
foreach (var list in lista)
{
    Console.WriteLine(string.Join(", ", list));
}

Console.WriteLine($"Results count: {results.Count}");
int sum = results.Sum();
Console.WriteLine($"Total sum: {sum}");

static int IsSafe(List<int> level)
{
    bool isIncreasing = true;
    bool isDecreasing = true;

    for (int j = 0; j < level.Count - 1; j++)
    {
        int diff = level[j + 1] - level[j];
        if (diff == 0 || Math.Abs(diff) > 3)
        {
            return 0;
        }
        if (diff < 0)
        {
            isIncreasing = false;
        }
        if (diff > 0)
        {
            isDecreasing = false;
        }
    }

    return (isIncreasing || isDecreasing) ? 1 : 0;
}
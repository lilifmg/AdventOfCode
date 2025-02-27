string fileName = "day5.txt";
string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", fileName);

if (!File.Exists(filePath))
{
    Console.WriteLine($"Error: File '{fileName}' not found at '{Path.GetFullPath(filePath)}'");
    return;
}

var lines = await File.ReadAllLinesAsync(filePath);
var order = new List<string>();
var toAnalyze = new List<string>();

bool foundEmptyLine = false;

foreach (var line in lines)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        foundEmptyLine = true;
        continue;
    }

    if (!foundEmptyLine)
        order.Add(line);
    else
        toAnalyze.Add(line);
}

int sum = toAnalyze
    .Where(line => !IsCorrectOrder(line, order)) 
    .Select(line => FixOrder(line, order))    
    .Select(line => GetMiddleValue(line))  
    .Sum();         

Console.WriteLine($"Soma: {sum}");

static bool IsCorrectOrder(string line, List<string> order)
{
    var elements = line.Split(',');

    foreach (var rule in order)
    {
        var ruleParts = rule.Split('|');
        if (ruleParts.Length < 2) continue;

        string first = ruleParts[0], second = ruleParts[1];

        int firstIndex = Array.IndexOf(elements, first);
        int secondIndex = Array.IndexOf(elements, second);

        if (firstIndex != -1 && secondIndex != -1 && secondIndex < firstIndex)
            return false;
    }

    return true;
}

static string FixOrder(string line, List<string> order)
{
    var elements = line.Split(',').ToList();

    elements.Sort((a, b) => CompareByRules(a, b, order));

    return string.Join(",", elements);
}

static int CompareByRules(string a, string b, List<string> order)
{
    foreach (var rule in order)
    {
        var ruleParts = rule.Split('|');
        if (ruleParts.Length < 2) continue;

        string first = ruleParts[0], second = ruleParts[1];

        if (a == first && b == second) return -1;

        if (a == second && b == first) return 1;
    }

    return 0;
}


static int GetMiddleValue(string line)
{
    var elements = line.Split(',');
    int middleIndex = elements.Length / 2;
    return int.TryParse(elements[middleIndex], out int value) ? value : 0;
}

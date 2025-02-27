string fileName = "day6.txt";
string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", fileName);

if (!File.Exists(filePath))
{
    Console.WriteLine($"Error: File '{fileName}' not found at '{Path.GetFullPath(filePath)}'");
    return;
}

string[] lines = await File.ReadAllLinesAsync(filePath);

int rowCount = lines.Length;
int colCount = lines[0].Length;

// Create matrix
char[,] matriz = new char[rowCount, colCount];

var location = (0, 0);

List<string> order = ["UP", "RIGHT", "DOWN", "LEFT"];
var positions = new List<(int, int)>();

// Populate matrix
for (int i = 0; i < rowCount; i++)
{
    for (int j = 0; j < colCount; j++)
    {
        matriz[i, j] = lines[i][j];
        if (lines[i][j] == '^')
        {
            location = (i, j);
            positions.Add((i, j));
        }
    }
}

var currentStep = "UP";
while (WinningCondition(currentStep))
{

    switch (currentStep)
    {
        case "UP":
            do
            {
                location = (location.Item1 - 1, location.Item2);
                if (!positions.Contains(location))
                {
                    positions.Add(location);
                }
            }
            while (WinningCondition(currentStep) && ChangeDirectionCondition(currentStep));
            break;
        case "RIGHT":
            do
            {
                location = (location.Item1, location.Item2 + 1);
                if (!positions.Contains(location))
                {
                    positions.Add(location);
                }
            }
            while (WinningCondition(currentStep) && ChangeDirectionCondition(currentStep));
            break;
        case "DOWN":
            do
            {
                location = (location.Item1 + 1, location.Item2);
                if (!positions.Contains(location))
                {
                    positions.Add(location);
                }
            }
            while (WinningCondition(currentStep) && ChangeDirectionCondition(currentStep));
            break;
        case "LEFT":
            do
            {
                location = (location.Item1, location.Item2 - 1);
                if (!positions.Contains(location))
                {
                    positions.Add(location);
                }
            }
            while (WinningCondition(currentStep) && ChangeDirectionCondition(currentStep));
            break;
    }

    if (!ChangeDirectionCondition(currentStep))
    {
        currentStep = CalculateNextStep(order, currentStep);
    }
    else
    {
        positions.Add(location);
        break;
    }
}

Console.WriteLine("Sum: " + positions.Count);

static string CalculateNextStep(List<string> steps, string currentStep)
{
    if (currentStep == steps[steps.Count - 1])
    {
        return steps[0];
    }

    return steps[steps.IndexOf(currentStep) + 1];
}

bool WinningCondition(string dir)
{
    switch (dir)
    {
        case "UP":
            return location.Item1 - 1 != 0;

        case "RIGHT":
            return location.Item2 + 1 != 0;

        case "DOWN":
            return location.Item1 + 1 != rowCount-1;

        case "LEFT":
            return location.Item2 - 1 != colCount-1;
        default:
            break;
    }

    return false;
}

bool ChangeDirectionCondition(string dir)
{
    switch (dir)
    {
        case "UP":
            return matriz[location.Item1-1, location.Item2] != '#';

        case "RIGHT":
            return matriz[location.Item1, location.Item2 +1] != '#';

        case "DOWN":
            return matriz[location.Item1 + 1, location.Item2] != '#';

        case "LEFT":
            return matriz[location.Item1, location.Item2-1] != '#';
        default:
            break;
    }

    return false;
}
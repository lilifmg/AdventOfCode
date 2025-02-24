string fileName = "day4.txt";
string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", fileName);

if (!File.Exists(filePath))
{
    Console.WriteLine($"Error: File '{fileName}' not found at '{Path.GetFullPath(filePath)}'");
    return;
}

string[] linhas = await File.ReadAllLinesAsync(filePath);

int rowCount = linhas.Length;
int colCount = linhas[0].Length;

// Create matrix
char[,] matriz = new char[rowCount, colCount];

// Populate matrix
for (int i = 0; i < rowCount; i++)
{
    for (int j = 0; j < colCount; j++)
    {
        matriz[i, j] = linhas[i][j];
    }
}

// Display the matrix
Console.WriteLine("Matriz lida do ficheiro:");
for (int i = 0; i < rowCount; i++)
{
    for (int j = 0; j < colCount; j++)
    {
        Console.Write(matriz[i, j] + " ");
    }
    Console.WriteLine();
}

int counter = 0;
int counterX = 0;

for (int y = 1; y < rowCount -1; y++)
{
    for (int x = 1; x < colCount-1; x++)
    {
        if (matriz[y, x] == 'A')
        {
            counterX++;
            Console.WriteLine($"x: {x} y: {y} Matriz size: {colCount}");

            if ((matriz[y - 1, x - 1] == 'M' && matriz[y + 1, x + 1] == 'S' ||
            matriz[y - 1, x - 1] == 'S' && matriz[y + 1, x + 1] == 'M') &&
           (matriz[y - 1, x + 1] == 'M' && matriz[y + 1, x - 1] == 'S' ||
            matriz[y - 1, x + 1] == 'S' && matriz[y + 1, x - 1] == 'M'))
            {
                counter++;
            }
        }
    }
}

Console.WriteLine(counter);
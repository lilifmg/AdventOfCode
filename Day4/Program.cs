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

for (int y = 0; y < rowCount; y++)
{
    for (int x = 0; x < colCount; x++)
    {
        if (matriz[y, x] == 'X')
        {
            counterX++;
            Console.WriteLine($"x: {x} y: {y} Matriz size: {colCount}");

            // vertical north
            if (y - 3 >= 0 && matriz[y - 1, x] == 'M' && matriz[y - 2, x] == 'A' && matriz[y - 3, x] == 'S')
            {
                counter++;
            }

            // diagonal NW
            if (y - 3 >= 0 && x + 3 < colCount && matriz[y - 1, x + 1] == 'M' && matriz[y - 2, x + 2] == 'A' && matriz[y - 3, x + 3] == 'S')
            {
                counter++;
            }

            // horizontal east
            if (x + 3 < colCount && matriz[y, x + 1] == 'M' && matriz[y, x + 2] == 'A' && matriz[y, x + 3] == 'S')
            {
                counter++;
            }

            // diagonal SE
            if (y + 3 < rowCount && x + 3 < colCount && matriz[y + 1, x + 1] == 'M' && matriz[y + 2, x + 2] == 'A' && matriz[y + 3, x + 3] == 'S')
            {
                counter++;
            }

            // vertical south
            if (y + 3 < rowCount && matriz[y + 1, x] == 'M' && matriz[y + 2, x] == 'A' && matriz[y + 3, x] == 'S')
            {
                counter++;
            }

            // diagonal SW
            if (y + 3 < rowCount && x - 3 >= 0 && matriz[y + 1, x - 1] == 'M' && matriz[y + 2, x - 2] == 'A' && matriz[y + 3, x - 3] == 'S')
            {
                counter++;
            }

            // horizontal west
            if (x - 3 >= 0 && matriz[y, x - 1] == 'M' && matriz[y, x - 2] == 'A' && matriz[y, x - 3] == 'S')
            {
                counter++;
            }

            // diagonal NE
            if (y - 3 >= 0 && x - 3 >= 0 && matriz[y - 1, x - 1] == 'M' && matriz[y - 2, x - 2] == 'A' && matriz[y - 3, x - 3] == 'S')
            {
                counter++;
            }
        }
    }
}

Console.WriteLine(counter);
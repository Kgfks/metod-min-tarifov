using static System.Console;

Write("Введите количество строк: ");
int rows = int.Parse(ReadLine());
Write("Введите количество столбцов: ");
int cols = int.Parse(ReadLine());

int[,] table = new int[rows, cols];
int[] zap = new int[rows];
int[] potr = new int[cols];

for (int a = 0; a < rows; a++)
{
    for (int b = 0; b < cols; b++)
    {
        Write($"введите элемент таблицы: [A{a}, B{b}]: ");
        while (true)
        {
            try
            {
                table[a, b] = int.Parse(ReadLine());
                break;
            }
            catch (FormatException)
            {
                Write("Неверный формат, попробуйте снова: ");
            }
        }
    }
}

for (int A = 0; A < rows; A++)
{
    Write($"введите запасы: A{A}: ");
    while (true)
    {
        try
        {
            zap[A] = int.Parse(ReadLine());
            break;
        }
        catch (FormatException)
        {
            Write("Неверный формат, попробуйте снова: ");
        }
    }
}

for (int B = 0; B < cols; B++)
{
    Write($"введите потребности: B{B}: ");
    while (true)
    {
        try
        {
            potr[B] = int.Parse(ReadLine());
            break;
        }
        catch (FormatException)
        {
            Write("Неверный формат, попробуйте снова: ");
        }
    }
}

Write("           |");
for (int b = 0; b < cols; b++)
{
    Write($" B{b + 1} |");
}
WriteLine(" Запасы");
for (int a = 0; a < rows; a++)
{
    Write($"     A{a + 1}    |");
    for (int b = 0; b < cols; b++)
    {
        Write($" {table[a, b],2} |");
    }
    Write($"  {zap[a]}");
    WriteLine();
}
WriteLine(new string('-', 50));
Write("Потребности|");
for (int b = 0; b < cols; b++)
{
    Write($" {potr[b]} |");
}
WriteLine();

int vse = 0;

while (true)
{
    int min = int.MaxValue;
    int minRows = -1;
    int minCols = -1;
    for (int a = 0; a < rows; a++)
    {
        for (int b = 0; b < cols; b++)
        {
            if (zap[a] > 0 && potr[b] > 0 && table[a, b] < min)
            {
                min = table[a, b];
                minRows = a;
                minCols = b;
            }
        }
    }
    if (minRows == -1 || minCols == -1) break;

    int minZap = zap[minRows];
    int minPotr = potr[minCols];
    int min1 = Math.Min(minZap, minPotr);
    WriteLine($"\nминимальное: {min}");
    WriteLine($"\nминимальное среди запасов и потребностей минимального эл-та: {min1}");

    zap[minRows] -= min1;
    potr[minCols] -= min1;
    vse += min * min1;

    WriteLine("\nОбновленная таблица:");
    Write("           |");
    for (int b = 0; b < cols; b++)
    {
        Write($" B{b + 1} |");
    }
    WriteLine(" Запасы");
    for (int a = 0; a < rows; a++)
    {
        Write($"     A{a + 1}    |");
        for (int b = 0; b < cols; b++)
        {
            Write($" {table[a, b],2} |");
        }
        Write($"  {zap[a]}");
        WriteLine();
    }
    WriteLine(new string('-', 50));
    Write("Потребности| ");
    for (int b = 0; b < cols; b++)
    {
        Write($" {potr[b]} |");
    }
    WriteLine();
    Write($"Затраты: {min * min1}");
}
WriteLine($"\n Общие затраты: {vse}");
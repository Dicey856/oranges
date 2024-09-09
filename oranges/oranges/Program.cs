using System.Data;





Console.Write("Enter the width and rows of the orange garden and the amount of rotten oranges, separated by a space: ");
string[] inputs = Console.ReadLine().Split();

if (inputs.Length != 3)
{
    Console.WriteLine("Invalid input. Please enter three integers separated by a space.");
    return;
}

int width = int.Parse(inputs[0]);
int rows = int.Parse(inputs[1]);
int rotAmount = int.Parse(inputs[2]);

if (width <= 0 || rows <= 0 || rotAmount <= 0)
{
    Console.WriteLine("Invalid input. Please enter positive integers.");
    return;
}

int[,] matrix = new int[rows, width];


PrintOranges(matrix);

Console.WriteLine($"Matrix: {rows}x{width}");


for (int i = 0; i < rotAmount; i++)
{
    Console.Write($"Enter the coordinates for rotten orange {i + 1} (x y): ");
    string[] coordinates = Console.ReadLine().Split();

    if (coordinates.Length != 2)
    {
        Console.WriteLine("Please enter only two integers");
        i--; 
        continue;
    }
    int x = int.Parse(coordinates[0]) - 1;
    int y = int.Parse(coordinates[1]) - 1;
    if(x < 0 || y < 0 || x >= rows || y >= width)
    {
        Console.WriteLine("Invalid coordinates. Please enter valid x and y coordinates.");
        i--;
        continue;
    }

    
    matrix[x, y] = 1;
}

Console.WriteLine("Orange garden contents:");
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < width; j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}

Console.Write("The numbers of days to pass: ");
int days = int.Parse(Console.ReadLine());
if(days < 0)
{
    Console.WriteLine("Please enter a positive integer value.");
}


int passeddays = 0;
while(passeddays != days)
{
    matrix = UpdateOranges(matrix);
    Console.WriteLine($"Oragne garden after {passeddays+1} days:");
    PrintOranges(matrix);
    passeddays++;
}
    


int amountofrot = 0;
int amountofhealth = 0;

Console.WriteLine("Final result");
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < width; j++)
    {
        Console.Write(matrix[i, j] + " ");
        if (matrix[i, j] == 1)
        {
            amountofrot++;
        }
        else
        {
            amountofhealth++;
        }
    }
    Console.WriteLine();
}

Console.WriteLine($"Amount of rotten oranges after the days is: {amountofrot}");
Console.WriteLine($"Amount of healthy oranges after the days is: {amountofhealth}");
int[,] UpdateOranges(int[,] currmatrix)
{
    int[,] newmatrix = (int[,])currmatrix.Clone();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < width; j++)
        {
            if (currmatrix[i, j] == 1)
            {
                if (i > 0) newmatrix[i - 1, j] = 1; //Left
                if (i < rows - 1) newmatrix[i + 1, j] = 1;  //Right
                if (j > 0) newmatrix[i, j - 1] = 1; //Up
                if (j < width - 1) newmatrix[i, j + 1] = 1; //Down
            }
        }

    }
    return newmatrix;
};


void PrintOranges(int[,] currmatrix)
{
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < width; j++)
        {
            Console.Write(currmatrix[i, j] + " ");
        }
        Console.WriteLine();
    }
    
}

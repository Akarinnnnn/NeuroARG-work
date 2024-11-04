//  column transform at 'v'
//               v             
//   2 5 2 5 2 5 2 4 3 2 1 0 1
// ^ identical transform amount ^
int[] key1 = [
	145298,2369,
	// 145298,2369,
	145298,
	18562541,1245722,5316280,7184691,28916312,769015,521670,15316621
];

Console.WriteLine("Grid1");
var grid1 = CreateGrid1();
PrintGird(grid1);

Console.WriteLine("Decrypting Grid1");
ReverseGrid(grid1, key1);
Console.WriteLine("Result:");
PrintGird(grid1);






static char[,] CreateGrid1()
{
	// char[,] grid = new char[6, 6];
	char[,] grid = {
			{ 'c', 'x', '6', '8', 'v', '1' },
			{ '7', 'j', 'f', '4', 'b', '0' },
			{ 'z', 'k', 'j', 'l'/* 1? */, 'r', '3' },
			{ 'y', 'p', 'q', 'f', '9', 'u' },
			{ 'r', 'g', 'w', 'd', 'h', 'e' },
			{ 'a', 'b', '2', '8', '9', 'c' },

		};
	// string alphabet = "abcdefghijqlmnopqrstuvwxyz1234567890";
	// int index = 0;

	// for (int row = 0; row < 6; row++)
	// {
	//     for (int col = 0; col < 6; col++)
	//     {
	//         grid[row, col] = alphabet[index];
	//         index++;
	//     }
	// }

	return grid;
}

static void PrintGird(char[,] grid)
{
	for (int row = 0; row < 6; row++)
	{
		for (int col = 0; col < 6; col++)
		{
			Console.Write(grid[row, col] + " ");
		}
		Console.WriteLine();
	}
}

static void RotateGrid(char[,] grid, int[] keyNumbers)
{
	for (int i = 0; i < keyNumbers.Length; i++)
	{
		int rotationAmount = keyNumbers[i];
		if (i < 6)
		{
			RotateRow(grid, i % 6, rotationAmount);
		}
		else
		{
			RotateColumn(grid, (i - 6) % 6, rotationAmount);
		}
	}
}

static void ReverseGrid(char[,] grid, int[] key)
{
for (int i = 0; i < key.Length; i++)
	{
		int rotationAmount = key[i];
		if (i < 6)
		{
			ReverseRow(grid, i % 6, rotationAmount);
		}
		else
		{
			ReverseColumn(grid, (i - 6) % 6, rotationAmount);
		}
	}
}

static void RotateRow(char[,] grid, int row, int amount)
{

	amount %= 6;
	char[] temp = new char[6];

	for (int col = 0; col < 6; col++)
	{
		temp[col] = grid[row, col];
	}

	for (int col = 0; col < 6; col++)
	{
		// 1 2 3 4 5 6 (2)
		grid[row, col] = temp[(col - amount + 6) % 6];
		// 5 6 1 2 3 4
	}
}

static void ReverseRow(char[,] grid, int row, int amount)
{
	char[] temp = new char[6];
	for (int col = 0; col < 6; col++)
	{
		// no ez way to copy
		temp[col] = grid[row, col];
	}

	// normalize amount
	amount %= 6;

	// column 6 to 1 (5 to 0 in index order)
	for (int col = 5; col > -1; col--)
	{
		// 5 6 1 2 3 4 (2)
		grid[row, col] = temp[(col + 6 + amount) % 6];
		// 1 2 3 4 5 6
	}
}

static void RotateColumn(char[,] grid, int col, int amount)
{
	amount %= 6;
	char[] temp = new char[6];

	for (int row = 0; row < 6; row++)
	{
		temp[row] = grid[row, col];
	}

	for (int row = 0; row < 6; row++)
	{
		grid[row, col] = temp[(row - amount + 6) % 6];
	}
}

static void ReverseColumn(char[,] grid, int col, int amount)
{
	char[] temp = new char[6];
	for (int row = 0; row < 6; row++)
	{
		// no ez way to copy
		temp[row] = grid[row, col];
	}

	// normalize amount again
	amount %= 6;

	// column 6 to 1 (5 to 0 in index order)
	for (int row = 5; col > -1; col--)
	{
		// 5 6 1 2 3 4 (2)
		grid[row, col] = temp[(row + 6 + amount) % 6];
		// 1 2 3 4 5 6
	}
}


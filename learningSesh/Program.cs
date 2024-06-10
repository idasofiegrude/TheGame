const int gridSize = 10;
var grid = new char[gridSize, gridSize];
var playerX = 1;
var playerY = 1;


SetupGrid();
SetStartPosition();
PrintGrid();
StartGameLoop();
return; // end of program

void StartGameLoop()
{
    while (true)
    {
        ConsoleKeyInfo keyPress = Console.ReadKey();

        if (keyPress.Key == ConsoleKey.Escape) 
        {
            break;
        }

        HandleKeyPress(keyPress.Key);
    }
}

void HandleKeyPress(ConsoleKey key)
{
    var isMoved = false;
    
    
    switch (key)
    {
        case ConsoleKey.UpArrow:
            isMoved = MovePlayer(0, -1); 
            break;
        case ConsoleKey.DownArrow:
            isMoved = MovePlayer(0, 1);
            break;
        case ConsoleKey.LeftArrow:
            isMoved = MovePlayer(-1, 0);
            break;
        case ConsoleKey.RightArrow:
            isMoved = MovePlayer(1, 0);
            break;
    }

    PrintGrid();

    if (!isMoved)
    {
        PrintMessage("You can't move there!");
    }
}

bool MovePlayer(int changeX, int changeY)
{
    var newPlayerX = playerX + changeX;
    var newPlayerY = playerY + changeY;

    if (IsWall(newPlayerX, newPlayerY))
    {
        return false;
    }

    grid[playerX, playerY] = ' ';
    grid[newPlayerX, newPlayerY] = '@';
    playerX = newPlayerX;
    playerY = newPlayerY;

    return true;
}

void PrintGrid()
{ Console.Clear();
    for (int y = 0; y < gridSize; y++)
    {
        for (int x = 0; x < gridSize; x++)
        {
            Console.Write(grid[x,y]);
        }
        Console.WriteLine();
    }
}

void SetStartPosition()
{
    grid[playerX, playerY] = '@';
}

void SetupGrid()
{
    for (var x = 0; x < gridSize; x++)
    {
        for (var y = 0; y < gridSize; y++)
        {
            if (x == 0 || x == gridSize - 1 || y == 0 || y == gridSize - 1)
            {
                grid[x, y] = 'x';
            }
            else
            {
                grid[x, y] = ' ';
            }
        }
    }
}

void PrintMessage(string message)
{
    Console.SetCursorPosition(0, gridSize);
    Console.WriteLine(message);
}

bool IsWall(int x, int y)
{
    return grid[x,y] == 'x';
}

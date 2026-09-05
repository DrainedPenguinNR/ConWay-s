using Raylib_cs;

namespace GlobalVariables;

public class Grid
{
    int rows;
    int cols;
    bool[,] grid;

    public Grid()
    {
        this.rows = gVar.screenHeight / gVar.cellSize;
        this.cols = gVar.screenWidth / gVar.cellSize;
        this.grid = new bool[rows, cols];
        DrawGrid();
    }

    public void DrawGrid()
    {
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < cols; y++)
            {
                if (grid[x, y])
                {
                    Raylib.DrawRectangle(x * gVar.cellSize, y * gVar.cellSize, gVar.cellSize -1, gVar.cellSize -1, gCol.Green);
                }
                else
                {
                    Raylib.DrawRectangle(x * gVar.cellSize, y * gVar.cellSize, gVar.cellSize -1, gVar.cellSize -1, gCol.Gray);
                }
            }
        }
    }

    public void SetCellValue(int x, int y, bool value)
    {
        if (x >= 0 && x < rows && y >= 0 && y < cols)
        {
            grid[x, y] = value;
        }
    }

    public bool GetCellValue(int x, int y)
    {
        if (isWithinBounds(x, y))
        {
            return grid[x, y];
        }
        return false;
    }

    public bool isWithinBounds(int x, int y)
    {
        return x >= 0 && x < rows && y >= 0 && y < cols;
    }

    public int GetRows()
    {
        return rows;
    }

    public int GetCols()
    {
        return cols;
    }

    public void FillRandomly()
    {
        Random rand = new Random();
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < cols; y++)
            {
                grid[x, y] = rand.Next(2) == 0;
            }
        }
    }

}
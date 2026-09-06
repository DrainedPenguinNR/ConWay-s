using Raylib_cs;

namespace GlobalVariables;

/*
    This file contains the Grid class, which is responsible for managing the grid of cells in the Game of Life simulation.
    The grid is represented as a 2D array of boolean values, where true represents a live cell and false represents a dead cell.
    The class provides methods to draw the grid, set and get cell values, fill the grid randomly, clear the grid, and toggle cell values.

*/

public class Grid
{
    int rows;
    int cols;
    bool[,] grid;

    // Constructor
    public Grid()
    {
        this.rows = gVar.screenHeight / gVar.cellSize;
        this.cols = gVar.screenWidth / gVar.cellSize;
        this.grid = new bool[rows, cols];
        DrawGrid();
    }

    // Draws the grid on the screen
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

    // Sets the value of a cell at the specified coordinates
    public void SetCellValue(int x, int y, bool value)
    {
        if (isWithinBounds(x, y))
        {
            grid[x, y] = value;
        }
    }


    // Gets the value of a cell at the specified coordinates
    public bool GetCellValue(int x, int y)
    {
        if (isWithinBounds(x, y))
        {
            return grid[x, y];
        }
        return false;
    }

    // Checks if the specified coordinates are within the bounds of the grid
    public bool isWithinBounds(int x, int y)
    {
        return x >= 0 && x < rows && y >= 0 && y < cols;
    }

    // Returns the number of rows in the grid
    public int GetRows()
    {
        return rows;
    }

    // Returns the number of columns in the grid
    public int GetCols()
    {
        return cols;
    }

    // Fills the grid randomly with live and dead cells
    public void FillRandomly()
    {
        Random rand = new Random();
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < cols; y++)
            {
                grid[x, y] = rand.Next(gSim.randomFill) == 0;
            }
        }
    }

    // Clears the grid by setting all cells to dead
    public void ClearGrid()
    {
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < cols; y++)
            {
                grid[x, y] = false;
            }
        }
    }

    // Toggles the value of a cell at the specified coordinates
    public void ToggleCellValue(int x, int y)
    {
        if (isWithinBounds(x, y))
        {
            grid[x, y] = !grid[x, y];
        }
    }
}
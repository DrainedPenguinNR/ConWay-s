using Raylib_cs;

namespace GlobalVariables;

/*
    This file contains the Simulation class, which is responsible for managing the simulation of the Game of Life.
    The class uses two instances of the Grid class to represent the current state and the next state of the grid.
    It provides methods to start and stop the simulation, update the grid based on the rules of the Game of Life, and draw the grid on the screen.
*/


public class Simulation
{
    Grid grid = new Grid();
    Grid tempGrid = new Grid();

    bool run = false;

    // Constructor (Empty LOL)
    public Simulation()
    {
    }

    // Starts the simulation
    public void Start()
    {
        run = true;
    }

    // Stops the simulation
    public void Stop()
    {
        run = false;
    }

    // Returns whether the simulation is running
    public bool IsRunning()
    {
        return run;
    }

    // Draws the grid on the screen
    public void Draw()
    {
        grid.DrawGrid();
    }

    // Sets the value of a cell at the specified coordinates
    public void SetCellValue(int x, int y, bool value)
    {
        grid.SetCellValue(x, y, value);
    }

    // NeighborCount method calculates the number of live neighbors for a cell at the specified coordinates (x, y).
    public int NeighborCount(int x, int y)
    {
        int count = 0;

        // Iterate through the offsets defined in gSim to check each neighboring cell
        for(int i = 0; i < gSim.offsets.GetLength(0); i++)
        {
            // Calculate the coordinates of the neighboring cell, wrapping around the grid if necessary
            int neighborX = (x + gSim.offsets[i, 0] + grid.GetRows()) % grid.GetRows();
            int neighborY = (y + gSim.offsets[i, 1] + grid.GetCols()) % grid.GetCols();

            // Increment the count if the neighboring cell is alive
            count += grid.GetCellValue(neighborX, neighborY) ? 1 : 0;
        }
        return count;
    }

    // Update method applies the rules of the Game of Life to update the grid for the next generation.
    public void Update()
    {
        if (IsRunning())
        {
            for(int x = 0; x < grid.GetRows(); x++)
            {
                for(int y = 0; y < grid.GetCols(); y++)
                {
                    // Calculate the number of live neighbors and the current cell value
                    int liveNeighbors = NeighborCount(x, y);
                    bool cellValue = grid.GetCellValue(x, y);

                    // Apply the rules of the Game of Life to determine the next state of the cell
                    if (cellValue)
                    {
                        if(liveNeighbors < gSim.minNeighbors || liveNeighbors > gSim.maxNeighbors)
                        {
                            tempGrid.SetCellValue(x, y, false);
                        }
                        else
                        {
                            tempGrid.SetCellValue(x, y, true);
                        }
                    }
                    else
                    {
                        if(liveNeighbors == gSim.maxNeighbors)
                        {
                            tempGrid.SetCellValue(x, y, true);
                        }
                        else
                        {
                            tempGrid.SetCellValue(x, y, false);
                        }
                    }
                }
            }
            Grid oldGrid = grid;
            grid = tempGrid;
            tempGrid = oldGrid;
        }

    }

    // Clears the grid by setting all cells to dead
    public void Clear()
    {
        if (!IsRunning())
        {
            grid.ClearGrid();
        }
    }
    
    // Fills the grid randomly with live and dead cells
    public void FillRandomly()
    {
        if (!IsRunning())
        {
            grid.FillRandomly();
        }
    }

    // Toggles the value of a cell at the specified coordinates
    public void ToggleCellValue(int x, int y)
    {
        if (!IsRunning())
        {
            grid.ToggleCellValue(x, y);
        }
    }
}
using Raylib_cs;

namespace GlobalVariables;

public class Simulation
{
    Grid grid = new Grid();
    Grid tempGrid = new Grid();

    bool run = false;

    public Simulation()
    {
        grid.FillRandomly();
    }

    public void Start()
    {
        run = true;
    }

    public void Stop()
    {
        run = false;
    }

    public bool IsRunning()
    {
        return run;
    }

    public void Draw()
    {
        grid.DrawGrid();
    }

    public void SetCellValue(int x, int y, bool value)
    {
        grid.SetCellValue(x, y, value);
    }

    public int NeighborCount(int x, int y)
    {
        int count = 0;
        
        for(int i = 0; i < gSim.offsets.GetLength(0); i++)
        {
            int neighborX = (x + gSim.offsets[i, 0] + grid.GetRows()) % grid.GetRows();
            int neighborY = (y + gSim.offsets[i, 1] + grid.GetCols()) % grid.GetCols();

            count += grid.GetCellValue(neighborX, neighborY) ? 1 : 0;
        }
        return count;
    }

    public void Update()
    {
        if (IsRunning())
        {
            for(int x = 0; x < grid.GetRows(); x++)
            {
                for(int y = 0; y < grid.GetCols(); y++)
                {
                    int liveNeighbors = NeighborCount(x, y);
                    bool cellValue = grid.GetCellValue(x, y);

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
    
}
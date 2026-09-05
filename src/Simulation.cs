using Raylib_cs;

namespace GlobalVariables;

public class Simulation
{

    Grid grid = new Grid();
    public static void RunSim(int width, int height, int cellSize)
    {
        
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
        
    }
}
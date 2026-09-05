using Raylib_cs;

namespace GlobalVariables;

public class Program
{
    public static void Main()
    {
        Raylib.InitWindow(gVar.screenWidth, gVar.screenHeight, "Game Of Life in C#");
        Raylib.SetTargetFPS(gVar.fps);

        //Initialize Simulator
        Simulation sim = new Simulation();

        sim.SetCellValue(5, 5, true);


        while (!Raylib.WindowShouldClose())
        {
            //Main Loop
            //1. EventHandling

            //2. Update
            sim.Update();

            //3. Draw
            Raylib.BeginDrawing();
            
            //Draw the grid
            Raylib.ClearBackground(Color.Black);

            sim.Draw();

            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}   
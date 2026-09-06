using Raylib_cs;

namespace GlobalVariables;

public class Program
{
    public static void Main()
    {
        int fps = gVar.fps;
        Raylib.InitWindow(gVar.screenWidth, gVar.screenHeight, "Game Of Life in C#");
        Raylib.SetTargetFPS(gVar.fps);

        //Initialize Simulator
        Simulation sim = new Simulation();


        while (!Raylib.WindowShouldClose())
        {
            //Main Loop
            //1. EventHandling
            if(Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                int mouseX = Raylib.GetMouseX();
                int mouseY = Raylib.GetMouseY();

                int cellX = mouseX / gVar.cellSize;
                int cellY = mouseY / gVar.cellSize;

                sim.ToggleCellValue(cellX, cellY);
            }

            if(Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                if(sim.IsRunning())
                {
                    sim.Stop();
                    Raylib.SetWindowTitle("Game Of Life in C# - Paused");
                }
                else
                {
                    sim.Start();
                    Raylib.SetWindowTitle("Game Of Life in C# - Running...");
                }
            }
            else if(Raylib.IsKeyPressed(KeyboardKey.F))
            {
                fps += 2;
                Raylib.SetTargetFPS(fps);
            }
            else if(Raylib.IsKeyPressed(KeyboardKey.S))
            {
                if (fps > gVar.MinFPS)
                {
                    fps -= 2;
                    Raylib.SetTargetFPS(fps);
                }
            }
            else if(Raylib.IsKeyPressed(KeyboardKey.R))
            {
                if(!sim.IsRunning())
                {
                    sim.Clear();
                    sim.FillRandomly();
                }
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.C))
            {
                if (!sim.IsRunning())
                {
                    sim.Clear();
                }
            }
            

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
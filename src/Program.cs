using Raylib_cs;

namespace GlobalVariables;

/*
    This file contains the Program , which is the entry point of the application.
    It initializes the Raylib window, sets up the simulation, and handles user input and rendering in a loop.
    The class uses the Simulation class to manage the Game of Life simulation and provides controls for starting, stopping, and modifying the simulation.
*/

public class Program
{
    public static void Main()
    {
        // Initialize Raylib window and set target FPS
        int fps = gVar.fps;
        bool clickedThisFrame = false;
        Raylib.InitWindow(gVar.screenWidth, gVar.screenHeight, "Game Of Life in C#");
        Raylib.SetTargetFPS(gVar.fps);

        //Initialize Simulator
        Simulation sim = new Simulation();

        while (!Raylib.WindowShouldClose())
        {
            //Main Loop
            //1. EventHandling

            // Handle mouse input for toggling cell values
            if(Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                int mouseX = Raylib.GetMouseX();
                int mouseY = Raylib.GetMouseY();

                int cellX = mouseX / gVar.cellSize;
                int cellY = mouseY / gVar.cellSize;

                sim.ToggleCellValue(cellX, cellY);

                clickedThisFrame = true;
            }
            
            // BugFix: Prevents multiple toggles in a single click by resetting the clickedThisFrame flag when the mouse button is released.
            if(clickedThisFrame && Raylib.IsMouseButtonUp(MouseButton.Left))
            {
                clickedThisFrame = false;
            }

            // Handle keyboard input for controlling the simulation
            /*
                Space: Start/Stop the simulation
                F: Increase FPS
                S: Decrease FPS (not below MinFPS)
                R: Fill the grid randomly (only when simulation is stopped)
                C: Clear the grid (only when simulation is stopped)
            */

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
using Raylib_cs;
namespace GlobalVariables

/*
    This file contains all the global variables used in the program.
    It is a good practice to keep all the global variables in one place, so that they can be easily modified.
    The variables are grouped into classes based on their purpose.
    The classes are static, so that they can be accessed without creating an instance of the class.
*/

{

    //General Variables
    public static class gVar
    {
        public static int screenWidth = 1080;
        public static int screenHeight = 1080;
        public static int fps = 12;
        public static int MinFPS = 5;

        public static int cellSize = 10;
    }


    //Color Variables
    public static class gCol
    {
        public static Color Gray = new Color(55, 55, 55, 255);
        public static Color Green = new Color(0, 255, 0, 255);
    }

    //Simulation Variables
    public static class gSim
    {
        public static int[,] offsets =
        {
            {-1, -1}, {-1, 0}, {-1, 1},
            {0, -1},           {0, 1},
            {1, -1}, {1, 0}, {1, 1}
        };

        public static int minNeighbors = 2;
        public static int maxNeighbors = 3;
        public static int randomFill = 4;
    }
}
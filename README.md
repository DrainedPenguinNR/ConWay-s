# Conway's Game of Life (C# / Raylib)

A C# implementation of Conway's Game of Life, built as a first project in learning **cellular automata**.

## Why this project exists

This was my entry point into cellular automata. Instead of following a C# tutorial and copying it along, I watched a **C++ tutorial** and translated the concepts to C# myself — forcing actual understanding of the logic (grid representation, neighbor counting, update rules) rather than pattern-matching syntax from a video. No AI was used in writing this project.

I also kept a running **dev log** (`conways-game-of-life-devlog.pdf`) using a predict-then-verify format for each step:
- **Pre-Research** — what I expected the solution to look like before digging in
- **Post-Research** — what it actually turned out to be, and what I got right or wrong

## How it works

- The grid is a 2D array of booleans (`true` = alive, `false` = dead), rendered as colored rectangles with Raylib.
- Each generation, every cell's live neighbors are counted (8-directional, **wraps around the edges** — a toroidal grid) and the standard Game of Life rules are applied:
  - A live cell with 2–3 live neighbors survives.
  - A dead cell with exactly 3 live neighbors becomes alive.
  - Every other cell dies or stays dead.
- Two `Grid` instances (current + next state) are swapped each update so the simulation never mutates the grid it's currently reading from.

## Controls

| Key / Input | Action |
|---|---|
| Left Click | Toggle a cell alive/dead |
| `Space` | Start / stop the simulation |
| `F` | Increase simulation speed (FPS) |
| `S` | Decrease simulation speed (FPS, down to a minimum) |
| `R` | Clear and randomly fill the grid (only while stopped) |
| `C` | Clear the grid (only while stopped) |

## Tech stack

- **.NET 10** (C#)
- **[Raylib-cs](https://github.com/ChrisDill/Raylib-cs)** for window creation, input, and rendering

## Running it

```bash
dotnet run
```

Or open `ConWay's.csproj` in Visual Studio / your IDE of choice and run from there.

## Project structure

```
src/
├── Program.cs          # Entry point — window setup, input handling, main loop
├── Simulation.cs        # Game of Life rules, neighbor counting, generation updates
├── Grid.cs               # Grid state — get/set/toggle cells, fill, clear, draw
└── GlobalVariables.cs    # Config: screen size, cell size, FPS, colors, neighbor rules
```

## What's next

This is the first step into cellular automata generally — future goals include exploring other CA rule sets beyond Conway's classic rules.

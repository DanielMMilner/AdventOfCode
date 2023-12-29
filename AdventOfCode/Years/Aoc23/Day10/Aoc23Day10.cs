namespace AdventOfCode.Years.Aoc23.Day10;

public class Aoc23Day10 : Aoc
{
    protected override long SolvePart1(List<string> lines)
    {
        var (_, startingCell) = CreateGrid(lines);

        return TraversePipeLoop(startingCell) / 2;
    }

    protected override long SolvePart2(List<string> lines)
    {
        var (grid, startingCell) = CreateGrid(lines);
        TraversePipeLoop(startingCell);

        var count = 0;
        var insideLoop = false;
        Cell? cellLoopEntry = null;
        //Count the number of cells that are not visited and are inside a loop
        foreach (var cell in grid.SelectMany(t => t))
        {
            if (!cell.Visited)
            {
                if (insideLoop)
                {
                    count++;
                }
            }
            else
            {
                switch (cell.Pipe)
                {
                    case '|':
                        //Cross over a pipe so we must be entering or exiting the loop
                        insideLoop = !insideLoop;
                        break;
                    case 'F' or 'L':
                        //Cross over a rightward loop cell. Need to remember this cell to determine if we leave the loop later
                        cellLoopEntry = cell;
                        break;
                    case 'J':
                    {
                        if (cellLoopEntry?.Pipe is 'F')
                        {
                            //Cross a J when we entered with an F means we must have left the loop
                            insideLoop = !insideLoop;
                        }

                        cellLoopEntry = null;
                        break;
                    }
                    case '7':
                    {
                        if (cellLoopEntry?.Pipe is 'L')
                        {
                            //Cross a 7 when we entered with an L means we must have left the loop
                            insideLoop = !insideLoop;
                        }

                        cellLoopEntry = null;
                        break;
                    }
                }
            }
        }

        return count;
    }

    private static (List<List<Cell>>, Cell) CreateGrid(List<string> lines)
    {
        var grid = lines.Select(line => line.Select(character => new Cell { Pipe = character }).ToList()).ToList();
        var startingCell = grid[0][0];

        for (var i = 0; i < grid.Count; i++)
        {
            for (var j = 0; j < grid[i].Count; j++)
            {
                var cell = grid[i][j];
                switch (cell.Pipe)
                {
                    case '|':
                        cell.North = North(i, j);
                        cell.South = South(i, j);
                        break;
                    case '-':
                        cell.East = East(i, j);
                        cell.West = West(i, j);
                        break;
                    case 'L':
                        cell.North = North(i, j);
                        cell.East = East(i, j);
                        break;
                    case 'J':
                        cell.North = North(i, j);
                        cell.West = West(i, j);
                        break;
                    case '7':
                        cell.West = West(i, j);
                        cell.South = South(i, j);
                        break;
                    case 'F':
                        cell.East = East(i, j);
                        cell.South = South(i, j);
                        break;
                    case 'S':
                    {
                        var north = North(i, j);
                        var south = South(i, j);
                        var east = East(i, j);
                        var west = West(i, j);
                        if (north?.Pipe is '7' or 'F' or '|')
                        {
                            cell.North = north;
                        }

                        if (south?.Pipe is 'L' or 'J' or '|')
                        {
                            cell.South = south;
                        }

                        if (east?.Pipe is 'J' or '7' or '-')
                        {
                            cell.East = east;
                        }

                        if (west?.Pipe is 'L' or 'F' or '-')
                        {
                            cell.West = west;
                        }

                        startingCell = cell;
                        break;
                    }
                }
            }
        }

        return (grid, startingCell);

        Cell? North(int i, int j) => i - 1 < 0 ? null : grid[i - 1][j];
        Cell? South(int i, int j) => i + 1 >= grid.Count ? null : grid[i + 1][j];
        Cell? East(int i, int j) => j + 1 >= grid[i].Count ? null : grid[i][j + 1];
        Cell? West(int i, int j) => j - 1 < 0 ? null : grid[i][j - 1];
    }

    private static int TraversePipeLoop(Cell startingCell)
    {
        var count = 0;
        var completed = false;
        var currentCell = startingCell;
        while (!completed)
        {
            currentCell.Visited = true;
            count++;

            Cell nextCell;
            if (currentCell.North is { Visited: false })
            {
                nextCell = currentCell.North;
            }
            else if (currentCell.South is { Visited: false })
            {
                nextCell = currentCell.South;
            }
            else if (currentCell.East is { Visited: false })
            {
                nextCell = currentCell.East;
            }
            else if (currentCell.West is { Visited: false })
            {
                nextCell = currentCell.West;
            }
            else
            {
                break;
            }

            currentCell = nextCell;

            if (currentCell.Pipe == 'S')
            {
                completed = true;
            }
        }

        return count;
    }

    private class Cell
    {
        public Cell? North { get; set; }
        public Cell? South { get; set; }
        public Cell? East { get; set; }
        public Cell? West { get; set; }
        public bool Visited { get; set; }
        public char Pipe { get; init; } = '.';
    }
}
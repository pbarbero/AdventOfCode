using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class ConwayCubes
    {
        public static int GetActiveCubes(string[] lines)
        {
            var grid = GetInitialGrid(lines);

            for(var i = 0; i < 6; i++)
                grid = ApplyRules(grid);

            return grid.Count(c => c.Value);
        }

        private static Dictionary<int[], bool> ApplyRules(Dictionary<int[],bool> grid)
        {
            for(var i = 0; i < grid.Keys.Count(); i++)
            {
                var cubeKey = grid.Keys.ToArray()[i];
                var activeNeighbors = cubeKey.GetNeighbors(grid).Count(x => x.Value);

                if(grid[cubeKey] && (activeNeighbors < 2 || activeNeighbors > 3))
                    grid[cubeKey] = false;
                else if(activeNeighbors == 3)
                    grid[cubeKey] = true;
            }

            return grid;
        }

        private static Dictionary<int[],bool> GetInitialGrid(string[] lines)
        {
            var cubes = new Dictionary<int[],bool>();

            for(var i = 0; i < lines.Length; i++)
                for(var j = 0; j < lines[i].Length; j++)
                    cubes.Add(new int[3]{i,j,0}, lines[i][j] == '#');;

            return cubes;
        }

        private static Dictionary<int[], bool> GetNeighbors(this int[] cube, Dictionary<int[], bool> grid)
        {
            //Get all possible neigbors
            var possibleNeighbors = GetPermutations(cube);
            var permutations = possibleNeighbors.Where(x => !x.Equal(cube));
            var emptyGrid = permutations.ToDictionary(x => x, y => false);

            //Intersect with initial grid
            foreach(var key in emptyGrid.Keys)
                if(grid.ContainsKey(key))
                    emptyGrid[key] = grid[key];

            return emptyGrid;
        }

        private static HashSet<int[]> GetPermutations(int[] cube)
        {
            var permutations = new HashSet<int[]>();

            for(var dim = 0; dim < cube.Length; dim++)
                GetVariations(cube, ref permutations, dim);

            return permutations;
        }

        private static void GetVariations(int[] cube, ref HashSet<int[]> permutations, int dim)
        {
            for (var variation = cube[dim] - 1; variation <= cube[dim] + 1; variation++)
            {
                var neighbor = new int[cube.Length];
                Array.Copy(cube, neighbor, cube.Length);

                neighbor[dim] = variation;

                if (!permutations.Contains(neighbor))
                    permutations.Add(neighbor);
            }
        }

        private static bool Equal(this int[] cube1, int[] cube2)
        {
            if(cube1.Length != cube2.Length) throw new Exception($"Cannot compare cubes with different coordinates length.");

            for(var i = 0; i < cube1.Length; i++)
                if(cube1[i] != cube2[i]) return false;

            return true;
        }
    }
}
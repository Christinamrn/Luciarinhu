using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sudoku_Randomizer : MonoBehaviour
{
    static List<List<int>> static_grid = new List<List<int>>()
    {
        new List<int>(){8,1,3,9,2,5,7,4,6},
        new List<int>(){9,5,6,8,4,7,3,1,2},
        new List<int>(){4,7,2,3,6,1,8,9,5},
        new List<int>(){6,2,4,7,1,9,5,3,8},
        new List<int>(){7,9,5,6,3,8,4,2,1},
        new List<int>(){3,8,1,4,5,2,9,6,7},
        new List<int>(){2,3,8,1,7,4,6,5,9},
        new List<int>(){5,4,9,2,8,6,1,7,3},
        new List<int>(){1,6,7,5,9,3,2,8,4},
    };
    public static List<List<int>> Randomize()
    {
        List<List<int>> grid = new List<List<int>>(static_grid);
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
        for(int k = 0; k<9; k++)
        {
            int i = (int)UnityEngine.Random.Range(0, 9);
            int j = (int)UnityEngine.Random.Range(0, 9);
            grid[i][j] = 0;
        }
        return grid;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sudoku_Manager : MonoBehaviour
{
    List<List<int>> static_grid = new List<List<int>>()
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
    public DigitController digit;

    public List<Sprite> sprites;
    public Sprite red_sprite;
    List<List<int>> grid;
    List<DigitController> modifiables;
    float increment;

    bool isCompleted;

    void Start()
    {
        grid = Sudoku_Randomizer.Randomize();
        increment = transform.localScale.x * 0.80f;
        Vector3 init_pos = new Vector3(-3.23f, 3.23f,-0.01f);
        modifiables = new List<DigitController>();
        for(int i = 0; i<9; i++)
        {
            for(int j = 0; j<9; j++)
            {
                Vector3 pos = init_pos + new Vector3(j*increment, -i*increment, 0.0f);
                DigitController d = Instantiate(digit,new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                d.transform.parent = transform;
                d.transform.position = pos;
                d.isChanged = false;
                d.index = new Vector2((float)i,(float)j);
                if(grid[i][j] == 0)
                {
                    d.isModifiable = true;
                    d.GetComponent<SpriteRenderer>().sprite = red_sprite;
                    d.m_value = 1;
                    modifiables.Add(d);
                }else
                {
                    d.isModifiable = false;
                    d.m_value = grid[i][j];
                    d.GetComponent<SpriteRenderer>().sprite = sprites[d.m_value-1];
                }
            }
        }
        isCompleted = true;
    }

    bool Check(DigitController d)
    {
        
        return (d.m_value == static_grid[(int)d.index.x][(int)d.index.y]);
    }

    void Update()
    {
        if(isCompleted) return;
        foreach(DigitController d in modifiables)
        {
            if(!Check(d)) return;
        }
        isCompleted = true;
        if(isCompleted) Debug.Log("Completed");
    }

}

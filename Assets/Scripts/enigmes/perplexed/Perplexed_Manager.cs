using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Perplexed_Manager : MonoBehaviour
{
    /* Sprites of expected digit*/
    public List<Sprite> sprites_gold;

    /* Sprite of results digits*/
    public List<Sprite> sprites_normal;

    /*Expected results in this order : DH, DB, BG, BD*/
    List<int> expected;

    /*Game matrix*/
    List<List<int>> matrix;

    public SpriteRenderer result_DH_centaine;
    public SpriteRenderer result_DH_dizaine;
    public SpriteRenderer result_DH_unite;
    public SpriteRenderer result_DB_centaine;
    public SpriteRenderer result_DB_dizaine;
    public SpriteRenderer result_DB_unite;
    public SpriteRenderer result_BG_centaine;
    public SpriteRenderer result_BG_dizaine;
    public SpriteRenderer result_BG_unite;
    public SpriteRenderer result_BD_centaine;
    public SpriteRenderer result_BD_dizaine;
    public SpriteRenderer result_BD_unite;

    public List<SpriteRenderer> expected_sprites;

    bool isCompleted = false;
    // Start is called before the first frame update
    void Start()
    {
        expected = Perplexed_Randomizer.Randomize();
        expected = new List<int>{3,7,4,6};
        int index = 0;
        foreach(int number in expected)
        {
            List<int> decomposed = Decompose(number);
            foreach(int digit in decomposed)
            {
                expected_sprites[index].sprite = sprites_gold[digit];
                index++;
            }
        }
        matrix = new List<List<int>>();
        matrix.Add(new List<int>{0,0,0});
        matrix.Add(new List<int>{0,0,0});
        matrix.Add(new List<int>{0,0,0});

        UpdateSprites();
    }

    // Update is called once per frame
    void Update()
    {
        isCompleted = Check();
        if(isCompleted) Debug.Log("Completed");
    }

    void UpdateSprites()
    {
        List<int> result_DH = Decompose(matrix[0][2]);
        List<int> result_DB = Decompose(matrix[1][2]);
        List<int> result_BG = Decompose(matrix[2][0]);
        List<int> result_BD = Decompose(matrix[2][1]);
        result_DH_centaine.sprite = sprites_normal[result_DH[0]];
        result_DH_dizaine.sprite  = sprites_normal[result_DH[1]];
        result_DH_unite.sprite    = sprites_normal[result_DH[2]];
        result_DB_centaine.sprite = sprites_normal[result_DB[0]];
        result_DB_dizaine.sprite  = sprites_normal[result_DB[1]];
        result_DB_unite.sprite    = sprites_normal[result_DB[2]];
        result_BG_centaine.sprite = sprites_normal[result_BG[0]];
        result_BG_dizaine.sprite  = sprites_normal[result_BG[1]];
        result_BG_unite.sprite    = sprites_normal[result_BG[2]];
        result_BD_centaine.sprite = sprites_normal[result_BD[0]];
        result_BD_dizaine.sprite  = sprites_normal[result_BD[1]];
        result_BD_unite.sprite    = sprites_normal[result_BD[2]];
    }

    List<int> Decompose(int number)
    {
        int centaine = (int)Math.Truncate((double)(number / 100));
        int dizaine = (int)Math.Truncate((double)((number - centaine*100) / 10));
        int unite = (number - centaine*100 - dizaine*10);
        return new List<int>{centaine, dizaine, unite};
    }

    public void ModifyMatrix(int indexI, int indexJ, int _value)
    {
        matrix[indexI][indexJ] = _value;
        matrix[0][2] = matrix[0][0] + matrix[0][1];
        matrix[1][2] = matrix[1][0] + matrix[1][1];
        matrix[2][0] = matrix[0][0] + matrix[1][0];
        matrix[2][1] = matrix[0][1] + matrix[1][1];
        UpdateSprites();
    }

    bool Check()
    {
        return matrix[0][2] == expected[0] &&  matrix[1][2] == expected[1] && matrix[2][0] == expected[2] && matrix[2][1] == expected[3];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoFrameManager : MonoBehaviour
{
    private Dictionary<char, string> sprite_dictionary;

    void Awake()
    {
        sprite_dictionary = new Dictionary<char, string>();
        string path_start = Application.dataPath + "/Images/A20/P1/";
        sprite_dictionary.Add('A', "A20_lettre_A");
        sprite_dictionary.Add('B', "A20_lettre_B");
        sprite_dictionary.Add('C', "A20_lettre_C");
        sprite_dictionary.Add('D', "A20_lettre_D");
        sprite_dictionary.Add('E', "A20_lettre_E");
        sprite_dictionary.Add('F', "A20_lettre_F");
        sprite_dictionary.Add('G', "A20_lettre_G");

        GameObject a20ManagerObject = GameObject.Find("A20_Manager");
        A20_Manager a20_manager = a20ManagerObject.GetComponent<A20_Manager>();
        string sequence = a20_manager.pianoGenerator.sequence_to_display;
        int seq_length = sequence.Length;

        Sprite sprite;
        GameObject spriteObject;
        SpriteRenderer spriteRenderer;
        string path;
        float sequence_extension = 0.4375f * seq_length;

        Sprite[] sprites = new Sprite[seq_length];
        GameObject[] spriteObjects = new GameObject[seq_length];
        SpriteRenderer[] spriteRenderers = new SpriteRenderer[seq_length];

        for (int i = 0; i < seq_length; i++)
        {
            sprite_dictionary.TryGetValue(sequence[i], out path);
            sprites[i] = Resources.Load<Sprite>(path);
            spriteObjects[i] = new GameObject("Lettre_n"+i.ToString());
            spriteRenderers[i] = spriteObjects[i].AddComponent<SpriteRenderer>();
            spriteRenderers[i].sprite = sprites[i];
            spriteObjects[i].transform.position = new Vector3((0.5f * i) - (sequence_extension/2), -3.75f, 1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoGenerator
{
    public bool left_or_right; // 0 pour gauche, 1 pour droite
    public string sequence;
    public string sequence_to_display;
    private string[] sequence_dictionary =
    {
        "FACEAFACE",
        "BADGEAGE",
        "DEFACAGE",
        "EFFACAGE",
        "FABACEAE",
        "AFFEAGE",
        "BACCADE",
        "DEBEFFE",
        "FABACEE",
        "GEDAGED",
        "ABBEGA",
        "BAGACE",
        "BAGADA",
        "BAGADE",
        "BAGAGE",
        "CABECA",
        "CADEAC",
        "CAGADE",
        "DECADE",
        "DEGAGE",
        "EBAFFE",
        "EFFACE",
        "FACADE",
        "GADAGE"
    };

    public PianoGenerator()
    {
        left_or_right = Random.Range(0, 2) == 1;
        sequence = sequence_dictionary[Random.Range(0, 24)];
        sequence_to_display = sequence;
        if (left_or_right)
        {
            string temp_sequence = "";
            foreach (char c in sequence)
            {
                temp_sequence += c.ToString() + "b";
            }
            sequence = temp_sequence;
        }
    }
}

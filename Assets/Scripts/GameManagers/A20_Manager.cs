using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A20_Manager : MonoBehaviour
{
    // Puzzles randomization

    public PianoGenerator pianoGenerator;

    // Puzzles state

    public bool piano_completed;
    public bool ragman_opened;
    public bool bottle_broken;
    public bool wheel_completed;
    public bool tableCode_correct;
    public bool finalLock_opened;
    public bool silverlock_opened;
    public bool light_on;
    public bool bookcase_completed;
    public bool book_placed;

    // Items to pick
    public bool hammer_taken; // marteau dans le chiffonnier

    public bool silver_key_taken; // clé argentée (pour le chiffonnier) dans le piano
    public bool golden_key_taken; // clé dorée (pour la porte finale) dans le tiroir à code

    public bool bottle_paper_taken; // papier dans la bouteille en verre (n°2)
    public bool bookcase_paper_taken; // papier dans la bibliothèque (n°3)
    public bool wheel_paper_taken; // papier dans la roue (n°4)
    public bool book_taken;

    public int index_missingBook;

    public static A20_Manager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one instance of inventory");
            return;
        }
        instance = this;

        // Puzzles randomization

        pianoGenerator = new PianoGenerator();

        // Puzzles state
        piano_completed = false;
        ragman_opened = false;
        bottle_broken = false;
        wheel_completed = false;
        tableCode_correct = false;
        finalLock_opened = false;
        light_on = false;
        silverlock_opened = false;
        bookcase_completed = false;
        book_taken = false;

        // Items states
        hammer_taken = false;
        silver_key_taken = false;
        golden_key_taken = false;
        bottle_paper_taken = false;
        bookcase_paper_taken = false;
        wheel_paper_taken = false;
        book_placed = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Perplexed_Randomizer : MonoBehaviour
{
    /* Returns a list with expected results in this order : DH, DB, BG, BD*/
    public static List<int> Randomize()
    {
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
        int HG = (int)UnityEngine.Random.Range(1f, 99f);
        int HD =(int) UnityEngine.Random.Range(1f, 99f);
        int BG_v =(int) UnityEngine.Random.Range(1f, 99f);
        int BD_v =(int) UnityEngine.Random.Range(1f, 99f);
        int DH = HG + HD;
        int DB = BG_v + BD_v;
        int BG = HG + BG_v;
        int BD = HD + BD_v;
        
        return new List<int> {DH, DB, BG, BD};
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableauPianoMains : MonoBehaviour
{
    public GameObject tableau_GD;
    public GameObject tableau_G;
    public GameObject tableau_D;
    public string GouD;

    void Start()
    {
        tableau_GD.SetActive(true);
        tableau_G.SetActive(false);
        tableau_D.SetActive(false);
    }

    public virtual void OnMouseDown(){
        if(tableau_GD.activeSelf){
            if (GouD == "G"){
                tableau_GD.SetActive(false);
                tableau_G.SetActive(true);
            } else if(GouD == "D"){
                tableau_GD.SetActive(false);
                tableau_D.SetActive(true);
            }
        }else if(tableau_G.activeSelf) { 
            tableau_G.SetActive(false);
            tableau_GD.SetActive(true);
        } else if(tableau_D.activeSelf) { 
            tableau_D.SetActive(false);
            tableau_GD.SetActive(true);
        }
    } 

}

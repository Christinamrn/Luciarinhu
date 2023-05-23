using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourDeHanoi : MonoBehaviour
{
    
    public GameObject TourGauche;
    public GameObject TourMilieu;
    public GameObject TourDroite;

    public GameObject Pion1;
    public GameObject Pion2;
    public GameObject Pion3;

    private Transform Position1, Position2, Position3;

    private void Start()
    {
        Vector3 Position1 = Pion1.transform.position;
        Vector3 Position2 = Pion2.transform.position;
        Vector3 Position3 = Pion3.transform.position;

        // Afficher les positions dans la console
        /* Debug.Log("Position Object1: " + Position1);
        Debug.Log("Position Object2: " + Position2);
        Debug.Log("Position Object3: " + Position3);

        Debug.Log("TourGauche enfants :" + nbEnfantsTour(TourGauche));
        nomEnfantsTour(TourGauche);
        Debug.Log("TourMilieu enfants :" + nbEnfantsTour(TourMilieu));
        nomEnfantsTour(TourMilieu);
        Debug.Log("TourDroite enfants :" + nbEnfantsTour(TourDroite));
        nomEnfantsTour(TourDroite); */

        //DeplacerPionVersTour(Pion1, TourMilieu);

        /* Debug.Log("Position Object1: " + Position1);
        Debug.Log("Position Object2: " + Position2);
        Debug.Log("Position Object3: " + Position3);

        Debug.Log("TourGauche enfants :" + nbEnfantsTour(TourGauche));
        nomEnfantsTour(TourGauche);
        Debug.Log("TourMilieu enfants :" + nbEnfantsTour(TourMilieu));
        nomEnfantsTour(TourMilieu);
        Debug.Log("TourDroite enfants :" + nbEnfantsTour(TourDroite));
        nomEnfantsTour(TourDroite); */
    }

    private void Update(){
        //jeuFini();
    }
    
    private int nbEnfantsTour(GameObject Tour){
        return Tour.transform.childCount;
    } 

    void nomEnfantsTour(GameObject Tour){
        for(int i=0; i<Tour.transform.childCount; i++){
            Debug.Log("Enfant "+i+" : "+Tour.transform.GetChild(i).gameObject.name);
        }
    }
    
    string nomEnfantsTour(GameObject Tour, int i){
        return Tour.transform.GetChild(i).gameObject.name;
    }

    /* void DeplacerPionVersTour(GameObject Pion, GameObject Tour){
        Transform PionTransform = Pion.transform;
        Transform TourTransform = Tour.transform;

        PionTransform.SetParent(TourTransform);
    } */

    private bool bonOrdreEnfant(GameObject Tour){
        int ordre = 3;
        for(int i=0; i<Tour.transform.childCount; i++){
            string nomPion = Tour.transform.GetChild(i).gameObject.name;
            string numPion = nomPion.Substring(nomPion.Length-1);
            if(int.Parse(numPion) != ordre) return false;
            ordre --;
        }
        return true;
    }

    public bool jeuFini(){ 
        if(nbEnfantsTour(TourDroite) == 3 && bonOrdreEnfant(TourDroite) == true){
            Debug.Log("Fini !");
            return true;
            
        } 
        else
        {
            Debug.Log("Pas fini !");
            return false;
        } 
    }
}

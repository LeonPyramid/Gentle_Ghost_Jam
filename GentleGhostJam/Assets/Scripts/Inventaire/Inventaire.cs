using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventaire : MonoBehaviour
{
    public bool clicked;
    public int caseId;
    public int clicId;
    private ListeObjet listeToutObjet;
    public ListeObjet listeObjets;
    public GameObject[] lCases;
    void Start()
    {
        caseId = -1;
        clicId = -1;
        clicked = false;
        listeToutObjet = GameObject.FindGameObjectWithTag("listeToutObjet").GetComponent<ListeObjet>();
        for (int i =0; i<listeObjets.size;i++)
        {
            listeObjets.lObj[i] = listeToutObjet.getUnObjetById(-1);
            lCases[i].GetComponent<Case>().indice = i;

        }
        updateInventory();
    }

    public void updateInventory(){
        for (int i = 0; i<listeObjets.size;i++){
            lCases[i].GetComponent<Image>().sprite = listeObjets.lObj[i].sprite;
            if(listeObjets.lObj[i].id == -1){
                Color color  = lCases[i].GetComponent<Image>().color;
                color.a = 0;
                lCases[i].GetComponent<Image>().color = color;
            }
            else{
                Color color  = lCases[i].GetComponent<Image>().color;
                color.a = 1;
                lCases[i].GetComponent<Image>().color = color;
            }

        }
    }

    public void addInInventory(int objId){
        listeObjets.addUnObjet(listeToutObjet.getUnObjetById(objId));
        updateInventory();
    }
    public void supInInventory(int objId){
        listeObjets.supUnObjetById(objId);
        updateInventory();
    }

}

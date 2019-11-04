using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Case : MonoBehaviour, IPointerDownHandler
{
    private Inventaire inventaire;
    public GameObject mask;
    public Color color;
    private Color transparent;
    public int indice;
    public bool clicked;
    public GameObject loupe;


    private void Start() {
        loupe.SetActive(false);
        transparent.a = 0;
        inventaire = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventaire>();
        mask.GetComponent<Image>().color = transparent;
        clicked = false;
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (!clicked && inventaire.listeObjets.lObj[indice].id!=-1){
            loupe.SetActive(true);
            mask.GetComponent<Image>().color = color;
            clicked = true;
            if(inventaire.caseId != -1){
                inventaire.lCases[inventaire.caseId].GetComponent<Case>().UnClic();
            }
            inventaire.clicId = inventaire.listeObjets.lObj[indice].id;
            inventaire.caseId = indice;
        }
        else if (clicked){
            UnClic();
            inventaire.caseId = -1;
        }
        
    }

    public void UnClic (){
        mask.GetComponent<Image>().color = transparent;
        clicked = false;
        inventaire.clicId = -1;
        loupe.SetActive(false);
    }
}

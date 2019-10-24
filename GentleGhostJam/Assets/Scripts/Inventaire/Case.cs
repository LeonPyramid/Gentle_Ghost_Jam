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


    private void Start() {
        transparent.a = 0;
        inventaire = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventaire>();
        mask.GetComponent<Image>().color = transparent;
        clicked = false;
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (!clicked && inventaire.listeObjets.lObj[indice].id!=-1){
            mask.GetComponent<Image>().color = color;
            clicked = true;
        }
        
    }
}

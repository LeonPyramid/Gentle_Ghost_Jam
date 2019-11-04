using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoupeCase : MonoBehaviour
{
    private AudioSource bip;
    public Inventaire inventaire;
    public DialogManager dialogManager;
    void Start()
    {
        bip = GameObject.FindGameObjectWithTag("BipSound").GetComponent<AudioSource>();
        dialogManager = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventaire>().dialogManager;
        inventaire = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventaire>();
    }

    public void playDialog(){
        bip.Play();
        dialogManager.SetDialog(inventaire.listeObjets.getUnObjetById(inventaire.clicId).getDialog());
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{

    public bool collected;
    public int objId;
    public Sprite collesctedSprite;
    private Inventaire inventaire;

    public List<DialogPage> collectDialog;
    public List<DialogPage> collectedDialog;
    public bool postCollectDialog;
    void Start()
    {
        collected = false;
        inventaire = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventaire>();
        this.GetComponentInChildren<Interaction>().interactable = true;
    }

    // Update is called once per frame
    public bool Collect() { //renvoie si il faut desactiver le collider ou  non
        if (!collected){
            inventaire.addInInventory(objId);
            this.GetComponent<SpriteRenderer>().sprite = collesctedSprite;  
            collected = true;
            if(collesctedSprite == null){
                return true;
            }
            return false;
        }
        return false;
        
    }
}

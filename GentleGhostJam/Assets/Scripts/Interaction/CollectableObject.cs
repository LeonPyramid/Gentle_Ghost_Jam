using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    private bool interactable;
    public int objId;
    public Sprite collesctedSprite;
    private Inventaire inventaire;
    void Start()
    {
        interactable = false;
        inventaire = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventaire>();
        this.GetComponentInChildren<Interaction>().interactable = true;
    }

    // Update is called once per frame
    public bool Collect() { //renvoie si il faut desactiver le collider ou  non
        if (!interactable){
            inventaire.addInInventory(objId);
            this.GetComponent<SpriteRenderer>().sprite = collesctedSprite;  
            interactable = false;
            if(collesctedSprite == null){
                return true;
            }
            return false;
        }
        return false;
        
    }
}

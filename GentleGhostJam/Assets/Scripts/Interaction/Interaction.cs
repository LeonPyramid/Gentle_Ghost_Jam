using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum interactionClass {CollectableObject,DialogObject,ReactiveObject};
public class Interaction : MonoBehaviour
{
    private Sprite tmp;
    public GameObject parent;
    
    public bool interactable;
    
    public interactionClass interClass;

    private void Start() {
        this.GetComponent<SpriteMask>().sprite = parent.GetComponent<SpriteRenderer>().sprite;
        tmp = this.GetComponent<SpriteRenderer>().sprite;
        this.GetComponent<SpriteRenderer>().sprite = null;
    }

    public void OnMouseEnter(){
            if (interactable) {this.GetComponent<SpriteRenderer>().sprite = tmp;}

    }

    private void OnMouseExit() {
        if (interactable ) {this.GetComponent<SpriteRenderer>().sprite = null;}
    }

    private void OnMouseDown() {
        if (interactable){
            switch (interClass){
                case interactionClass.CollectableObject:
                    bool colliderOff;
                    interactable = false;
                    colliderOff = parent.GetComponent<CollectableObject>().Collect();
                    this.GetComponent<SpriteRenderer>().sprite = null;
                    if (colliderOff){
                        this.GetComponent<Collider2D>().isTrigger = true;
                    }

                break;
                case interactionClass.DialogObject:
                    //Afficher les dialoges
                break;
                case interactionClass.ReactiveObject:
                    //Interaction avec l'objet
                break;
                default:
                break;
            }
        }
    }
}

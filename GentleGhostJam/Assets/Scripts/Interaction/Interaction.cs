using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum interactionClass {CollectableObject,DialogObject,ReactiveObject};
public class Interaction : MonoBehaviour
{
    public List<DialogPage> cantDoDialog;
    private Inventaire inventaire;
    private Sprite tmp;
    public GameObject parent;
    
    public bool interactable;
    
    public interactionClass interClass;

    public Dialog dialog;

    public DialogManager dialogManager;

    private void Start() {
        this.GetComponent<SpriteMask>().sprite = parent.GetComponent<SpriteRenderer>().sprite;
        tmp = this.GetComponent<SpriteRenderer>().sprite;
        this.GetComponent<SpriteRenderer>().sprite = null;
        dialogManager = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventaire>().dialogManager;
        inventaire = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventaire>();
    }

    public void OnMouseEnter(){
            if (interactable && Time.timeScale != 0f) {this.GetComponent<SpriteRenderer>().sprite = tmp;}

    }

    private void OnMouseExit() {
        if (interactable && Time.timeScale != 0f) {this.GetComponent<SpriteRenderer>().sprite = null;}
    }

    private void OnMouseDown() {
        if (interactable){
            switch (interClass){
                case interactionClass.CollectableObject:
                    if(inventaire.clicId!=-1){
                        dialogManager.SetDialog(cantDoDialog);
                    }
                    else{
                        bool colliderOff;
                        CollectableObject parCollect = parent.GetComponent<CollectableObject>();
                        if(!parCollect.collected){
                            colliderOff = parCollect.Collect();
                            this.GetComponent<SpriteMask>().sprite = parent.GetComponent<SpriteRenderer>().sprite;
                            this.GetComponent<SpriteRenderer>().sprite = null;
                            if (!parCollect.postCollectDialog){
                                interactable = false;
                            }
                            if (colliderOff){
                                this.GetComponent<Collider2D>().isTrigger = true;
                            }
                            dialogManager.SetDialog(parCollect.collectDialog);
                        }
                        else{
                            dialogManager.SetDialog(parCollect.collectedDialog);
                            this.GetComponent<SpriteRenderer>().sprite = null;
                        }
                    }
                    

                break;
                case interactionClass.DialogObject:
                    DialogObject parDialog = parent.GetComponent<DialogObject>();
                    if(inventaire.clicId!=-1){
                        dialogManager.SetDialog(cantDoDialog);
                        this.GetComponent<SpriteRenderer>().sprite = null;
                    }
                    else{
                        if(parDialog.inspected){
                            this.GetComponent<SpriteRenderer>().sprite = null;
                            dialogManager.SetDialog(parDialog.inspectedDialog);
                        }
                        else{
                            this.GetComponent<SpriteRenderer>().sprite = null;
                            dialogManager.SetDialog(parDialog.inspectDialog);
                            parDialog.inspected = true;
                        }
                    }
                    
                break;
                case interactionClass.ReactiveObject:
                    this.GetComponent<SpriteRenderer>().sprite = null;
                    dialogManager.SetDialog(parent.GetComponent<InteractiveObject>().Interact(inventaire.clicId));
                    this.GetComponent<SpriteMask>().sprite = parent.GetComponent<SpriteRenderer>().sprite;
                break;
                default:
                break;
            }
        }
    }
}

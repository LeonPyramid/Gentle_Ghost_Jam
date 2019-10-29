using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public bool destroyObject;
    public Inventaire inventaire;
    public List<DialogPage> cantDo;
    public int keyObjectId;
    public List<DialogPage> inspect;
    public List<DialogPage> postInspect;
    public List<DialogPage> wrongObject;
    public List<DialogPage> rightObject;
    public bool activated;
    public Sprite postActivation;
    void Start()
    {
        activated = false;
        inventaire = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventaire>();
    }

    public List<DialogPage> Interact (int objectId){
        if(objectId == -1){
            if (activated){
                return postInspect;
            }
            return inspect;
        }
        else if(!activated){
            if(objectId == keyObjectId){
                this.GetComponent<SpriteRenderer>().sprite = postActivation;
                activated = true;
                if( destroyObject){
                    inventaire.supInInventory(keyObjectId);
                }
                return rightObject;
            }
            return wrongObject;
        }
        return cantDo;
    }

}

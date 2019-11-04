using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetInv : MonoBehaviour {
    public int id;
    public Sprite sprite;
    public List<DialogPage> dialogInfo;

    public ObjetInv(int unId, Sprite unSprite){
        this.id = unId;
        this.sprite = unSprite;
    }
    public ObjetInv(){
        this.id = -1;
        this.sprite = null;
    }
    public int getId(){
        return this.id;
    }
    public Sprite getSprite(){
        return this.sprite;
    }
    
    public List<DialogPage> getDialog(){
        return this.dialogInfo;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ListeObjet : MonoBehaviour{

    public ObjetInv[] lObj;
    public string libel;
    public int size;


    public ListeObjet (ObjetInv[]  uneL, string libel, int uneSize) {
        this.lObj = uneL;
        this.libel = libel;
        this.size = uneSize;
    }

    public ObjetInv getUnObjetById (int unId) {
        int i = 0;
        while (i < this.size && this.lObj[i].getId() != unId){
            i++;
        }
        if (i == this.size){
            return new ObjetInv();
        }
        return this.lObj[i];
    }
    public void supUnObjetById (int unId) {
        int i = 0;
        while (i < this.size){
            if(this.lObj[i].getId()==unId){
                this.lObj[i]=new ObjetInv();
            }
            i++;
        }
    }
    public void addUnObjet(ObjetInv unObjet){
        ObjetInv empty = new ObjetInv();
        int i = 0;
        while (i < this.size && this.lObj[i] != empty){
            i++;
        }
        this.lObj[i] = unObjet;
    }



}


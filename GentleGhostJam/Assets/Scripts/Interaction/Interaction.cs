using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Interaction : MonoBehaviour
{
    private Sprite tmp;
    public GameObject parent;

    private void Start() {
        this.GetComponent<SpriteMask>().sprite = parent.GetComponent<SpriteRenderer>().sprite;
        tmp = this.GetComponent<SpriteRenderer>().sprite;
        this.GetComponent<SpriteRenderer>().sprite = null;
    }

    public void OnMouseEnter(){
            this.GetComponent<SpriteRenderer>().sprite = tmp;

    }

    private void OnMouseExit() {
        this.GetComponent<SpriteRenderer>().sprite = null;
    }
}

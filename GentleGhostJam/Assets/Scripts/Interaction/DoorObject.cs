using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObject : MonoBehaviour
{
    private Collider2D playerCollider;
    private bool incollider;
    public Sprite open;
    public Sprite closed;
    public GameObject halo;
    private SpriteRenderer spriteRenderer;
    private void Start() {
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(this.GetComponent<InteractiveObject>().activated&&other==playerCollider){
            incollider = true;
            print("enter");
            spriteRenderer.sprite = open;
            halo.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        incollider = false;
        print("exit");
        spriteRenderer.sprite = closed;
        halo.SetActive(true);
    }
    public void OpenDoor(){
        if(incollider){
            print("open");
            spriteRenderer.sprite = open;
            halo.SetActive(false); 
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObject : MonoBehaviour
{
    private AudioSource doorsound;
    private Collider2D playerCollider;
    public bool incollider;
    public Sprite open;
    public Sprite closed;
    public GameObject halo;
    private SpriteRenderer spriteRenderer;
    private void Start() {
        doorsound = GameObject.FindGameObjectWithTag("DoorSound").GetComponent<AudioSource>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other==playerCollider){
            incollider = true;
            if(this.GetComponent<InteractiveObject>().activated){
                doorsound.Play();
                spriteRenderer.sprite = open;
                halo.SetActive(false);
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other==playerCollider){
            incollider = false;
            if(this.GetComponent<InteractiveObject>().activated){
                doorsound.Play();
                spriteRenderer.sprite = closed;
                halo.SetActive(true);
            }
        }

    }
    public void OpenDoor(){
        if(incollider){
            doorsound.Play();
            spriteRenderer.sprite = open;
            halo.SetActive(false); 
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum orient {n,s,e,w};
public class MoveOnTiles : MonoBehaviour
{
    public orient curOrient = orient.n;
    public float speed;
    private bool leftFoot;
    private bool midMove;
    private bool isMoving; //Savoir si le perso est en mouvement
    public bool GetIsMoving()
    {
        return isMoving;
    }
    public bool GetLeftFoot(){
        return leftFoot;
    }
    public bool GetMidMove(){
        return midMove;
    }

    public Vector2 tilePos;
    private float distFromTile;
    private float horizontal;
    private float vertical;
    public Vector2 direct;
    private Rigidbody2D rgbd;
    public float horTemp;
    public float verTemp;
    // Start is called before the first frame update
    void Start()
    {
        tilePos = new Vector2(this.transform.position.x,this.transform.position.y); // place la tuile de base
        isMoving = false;
        direct = new Vector2(0,0);
        rgbd = this.GetComponent<Rigidbody2D>();
        leftFoot = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical   = Input.GetAxis("Vertical");
        if(!isMoving){
            if(Mathf.Abs(horizontal)>Mathf.Abs(vertical)){
                isMoving = true;
                horTemp = horizontal;
                verTemp = 0;
                if(horizontal>0){
                    curOrient = orient.e;
                    direct = new Vector2(1,0);
                }
                else{
                    curOrient = orient.w;
                    direct = new Vector2(-1,0);
                }
            }
            else if (Mathf.Abs(horizontal)<Mathf.Abs(vertical)){
                isMoving = true;
                verTemp = vertical;
                horTemp = 0;
                if(vertical>0){
                    curOrient = orient.n;
                    direct = new Vector2(0,1);
                }
                else{
                    curOrient = orient.s;
                    direct = new Vector2(0,-1);
                }
            }
        }
        else{
            /*if (horTemp*horizontal <0){
                direct = -direct;
                horTemp = horizontal;
                if (horizontal>0){
                    tilePos = new Vector2(tilePos.x-32,tilePos.y);
                }
                else
                {
                    tilePos = new Vector2(tilePos.x+32,tilePos.y);
                }
            }
            if (verTemp*vertical<0){
                direct = -direct;
                verTemp = vertical;
                if (vertical>0){
                    tilePos = new Vector2(tilePos.x,tilePos.y-32);
                }
                else
                {
                    tilePos = new Vector2(tilePos.x,tilePos.y+32);
                }
            }   Code de demi-tour qui fait planter les collisions, à utiliser si tu prévient les colisions avec les murs*/
            distFromTile = CalculateDistFrom(tilePos);
            if (distFromTile < 32){
                Move (speed,direct);
                if (distFromTile > 16){
                    midMove = true;
                }
            }
            else {
                midMove = false;
                leftFoot = !leftFoot;
                tilePos = transform.position;
                if (horizontal*horTemp<=0&&vertical*verTemp<=0){
                    isMoving = false;
                    direct = new Vector2(0,0);
                }
                else{
                    Move (speed,direct);
                }
            }
        }

        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        isMoving = false;
        direct = new Vector2(0,0);
        this.transform.position = tilePos;
        verTemp = 0;
        horTemp = 0;
    }



    float CalculateDistFrom (Vector2 coord){
        float x = Mathf.Abs(coord.x - transform.position.x);
        float y = Mathf.Abs(coord.y - transform.position.y);
        return Mathf.Sqrt(x*x + y*y);
        
    }
    void Move (float speed,Vector2 direction){
        direction = direction*speed;
        rgbd.MovePosition(new Vector2(transform.position.x+direction.x,
                                        transform.position.y+direction.y));
    }

    

}

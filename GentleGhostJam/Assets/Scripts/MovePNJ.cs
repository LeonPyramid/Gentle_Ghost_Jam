using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum moveType {one,loop,reverse};

public class MovePNJ : MonoBehaviour
{
    public moveType mouvement;
    public orient curOrient = orient.n;

    public float speed;
    private int i;
    private float temps;
    private bool isMoving; //Savoir si le perso est en mouvement
    public bool GetIsMoving()
    {
        return isMoving;
    }
    private Vector2 tilePos;

    private float waitTime;
    private float distFromTile;
    private Vector2 direct;
    private Rigidbody2D rgbd;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        tilePos = new Vector2(this.transform.position.x,this.transform.position.y); // place la tuile de base
        isMoving = false;
        direct = new Vector2(0,0);
        rgbd = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        temps -= Time.deltaTime; // fait attendre le PNJ
        if (temps <=0){
            if(!isMoving){
                tilePos = GetComponent<ListeNoeuds>().liste[i].transform.position; //Définit la direction en fonction du noeud suivant
                direct = CalculateDirectOf(tilePos);
                if (direct != new Vector2(0,0)){
                    isMoving = true;
                    SetOrient (direct);
                }
            }
            else{

                distFromTile = CalculateDistFrom(tilePos);
                if (distFromTile>0){
                    Move (speed,direct);
                }
                else {
                    tilePos = transform.position;
                    isMoving = false;
                    direct = new Vector2(0,0);
                    Move (speed,direct);
                    if (i != GetComponent<ListeNoeuds>().liste.GetLength(0)-1){
                        temps = GetComponent<ListeNoeuds>().liste[i].temps;     //récupère le temps d'attente
                            i++;
                    }
                    else if (mouvement == moveType.one){
                        Destroy(GetComponent<MovePNJ>());
                    }
                }
            }
        }
        
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

    Vector2 CalculateDirectOf(Vector2 coord){
        float lx = coord.x - transform.position.x;
        if (lx != 0 ){
            lx = lx /Mathf.Abs(lx);
        }
        float ly = coord.y - transform.position.y;
        if (ly != 0){
            ly = ly /Mathf.Abs(ly);
        }
        return new Vector2(lx,ly);
        
    }

    orient SetOrient (Vector2 dir){
        if(dir.x != 0){
            if(dir.x>0){
                return orient.e;
            }
            return orient.w;
        }
        if(dir.y>0){
            return orient.n;
        }
        return orient.s;
    }
}

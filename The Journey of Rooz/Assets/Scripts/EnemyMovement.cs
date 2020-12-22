using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{

    public float runSpeed = 10f;
    public bool isRight;

    void Update() {

        if(isRight){

            transform.Translate( - 1 *runSpeed * Time.deltaTime, 0,0);
            transform.localScale = new Vector2(2,2);
    
        } else{

            transform.Translate(  1 *  runSpeed * Time.deltaTime, 0,0);
            transform.localScale = new Vector2(-2,2);
    
        }

    }  

    void OnTriggerEnter2D(Collider2D trig){


        if(trig.gameObject.CompareTag("turnLeftRight")){

            if(isRight){
                isRight = false;
            }
            else {
                isRight = true;
            }

        }

        if(trig.gameObject.CompareTag("Bullet")){

            Destroy(gameObject);
        }

        if(trig.CompareTag("Player")){

                GameMaster.instance.SetNumOfHearts(-1);
                
        }
    }



}

using UnityEngine;

public class eagleMovement : MonoBehaviour
{

    public float runSpeed = 1f;
    public bool isUp;

    void Update() {

        if(isUp){

            transform.Translate(0,  1 *runSpeed * Time.deltaTime, 0);
            transform.localScale = new Vector2(2,2);
    
        } else{

            transform.Translate(0,  -1 *  runSpeed * Time.deltaTime,0);
            transform.localScale = new Vector2(2,2);
    
        }

    }  

    void OnTriggerEnter2D(Collider2D trig){


        if(trig.gameObject.CompareTag("turnUpDown")){

            if(isUp){
                isUp = false;
            }
            else {
                isUp = true;
            }

        }
    }



}

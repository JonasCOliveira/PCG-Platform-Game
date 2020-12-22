using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

        public float runSpeed = 1f;
        public bool isUp;

    // Update is called once per frame
    void Update()
    {
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

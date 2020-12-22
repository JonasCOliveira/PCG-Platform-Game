using System;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{

    public Animator anim;
    public float transitionTime = .25f;  
    private Vector3 respPoint;
	public Transform endOfMapDeath;
    public Transform respawnPoint;

 	private void Awake(){

		respPoint = gameObject.transform.position;
	}

    public static void Reset(){

        
        if(GameMaster.instance.GetNumOfHearts() == 0){
            Debug.Log("Reset");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
            
            GameMaster.instance.ResetNumOfHearts();
            GameMaster.instance.ResetNumOfPoints();
            GameMaster.instance.ResetNumOfBullets();

            GameMaster.instance.SetNumOfHearts(5);
            GameMaster.instance.SetNumOfPoints(0);
            GameMaster.instance.SetNumOfBullets(10);

           GameMaster.instance.AttHud();

        } 

        else {
            //  PlayerPos.LoadCheckPoint();
             GameMaster.instance.AttHud();

        }

    }

    private void OnCollisionEnter2D(Collision2D collision){

		if (collision.collider.tag == "RespawnTag")
        {
            respPoint = new Vector3(collision.transform.position.x + 0.25f, collision.transform.position.y + 1, collision.transform.position.z);
            // GameObject.FindWithTag("RespawnTag").GetComponent<Collider2D>().isTrigger = true;
            collision.collider.isTrigger = true; 
           
        }

	}

	void OnTriggerEnter2D(Collider2D trig){

         if(trig.CompareTag("enemy")){

             StartCoroutine(PlayerHurt());
        }
        if (trig.gameObject.CompareTag("EndOfMap")){

            StartCoroutine(PlayerRespawn());
            
        }
        // if (trig.gameObject.CompareTag("RespawnTag")){
                
        //     Destroy(GameObject.FindWithTag("RespawnTag")); 
        //     GameObject.FindWithTag("RespawnTag").GetComponent<BoxCollider2D>().enabled = false;
        //     GameObject.FindWithTag("RespawnTag").GetComponent<BoxCollider2D>().isTrigger = true;
        // }
    }


     IEnumerator PlayerHurt(){

        anim.SetBool("isHurting", true);
        yield return new WaitForSeconds(transitionTime);
        GameMaster.instance.SetNumOfHearts(-1);
        anim.SetBool("isHurting", false);
        Reset();
        
    }

    IEnumerator PlayerRespawn(){

        gameObject.transform.position = respPoint;
        // gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        yield return new WaitForSeconds(transitionTime);
        // gameObject.GetComponent<Rigidbody2D>().gravityScale = 3f;
        GameMaster.instance.SetNumOfHearts(-1);
        Reset();
    }

}

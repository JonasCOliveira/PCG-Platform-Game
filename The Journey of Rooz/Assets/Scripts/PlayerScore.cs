using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

     void OnTriggerEnter2D(Collider2D other){

	if(other.CompareTag("gem")){

            GameMaster.instance.SetNumOfPoints(1);
        	GameMaster.instance.AttHud();
    }

    else if(other.CompareTag("life")){

            GameMaster.instance.SetNumOfHearts(1);
            GameMaster.instance.AttHud();
    }
 
    }

}

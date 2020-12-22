using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{

    public GameMaster gm;
    public bool isChecked = false;
    public static int numOfPointsCP; 
    public static int numOfBulletsCP;
    public static int numOfHeartsCP;

    void Start(){

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // void OnTriggerEnter2D(Collider2D other){

    //     if(other.CompareTag("Player") && isChecked == false){

    //         isChecked = true;
    //         numOfPointsCP = GameMaster.instance.GetNumOfPoints();
    //         numOfBulletsCP = GameMaster.instance.GetNumOfBullets();
    //         numOfHeartsCP = GameMaster.instance.GetNumOfHearts();
    //         gm.lastCheckPointPos = transform.position;
            
    //     }

    // }



    public static int GetNumOfPointsCP(){

        return numOfPointsCP;

    }

    public static int GetNumOfBulletsCP(){

        return numOfBulletsCP;

    }

    public static int GetNumOfHeartsCP(){

        return numOfHeartsCP;

    }

}

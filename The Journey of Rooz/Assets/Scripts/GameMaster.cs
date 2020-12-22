using System.Linq.Expressions;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameMaster : MonoBehaviour
{

    public static GameMaster instance;
    public Vector2 lastCheckPointPos;
    public int numOfHearts = 5;
    public int numOfPoints = 0;
    public int numOfBullets = 10;

    void Awake(){

        if(instance == null){

                instance = this;
                DontDestroyOnLoad(instance);
        } else {

            Destroy(gameObject);
        }

    }

    void Start(){

        AttHud();
    }

    void Update(){

        AttHud();

    }

    public void SetNumOfHearts(int hearts){

        numOfHearts += hearts;
        AttHud();
    }

    public int GetNumOfHearts(){

        return numOfHearts;

    }

    public void ResetNumOfHearts(){

        numOfHearts = 0;
    }

    public void SetNumOfPoints(int diamondPoints){

        numOfPoints += diamondPoints;
        AttHud();

    }


    public int GetNumOfPoints(){

        return numOfPoints;
    }

    public void ResetNumOfPoints(){

        numOfPoints = 0;
    }

    public void SetNumOfBullets(int bullets){

        numOfBullets += bullets;
        AttHud();

    }

    public int GetNumOfBullets(){

        return numOfBullets;
    }

    public void ResetNumOfBullets(){

        numOfBullets = 0;
    }



    public void AttHud(){

        GameObject.Find("HeartPointsText").GetComponent<Text>().text = numOfHearts.ToString();
        GameObject.Find("BulletsText").GetComponent<Text>().text = numOfBullets.ToString();
        GameObject.Find("DiamondsPointsText").GetComponent<Text>().text = numOfPoints.ToString();
        
    }


}

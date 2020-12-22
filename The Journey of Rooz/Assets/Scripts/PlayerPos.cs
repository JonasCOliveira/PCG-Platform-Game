
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerPos : MonoBehaviour
{

    public GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    public static void LoadCheckPoint(){

        
        GameMaster.instance.ResetNumOfPoints();
        GameMaster.instance.ResetNumOfBullets();


        if(Checkpoint.GetNumOfHeartsCP() == 0){
            Debug.Log("Reset");
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        } else {
            
            GameMaster.instance.SetNumOfPoints(Checkpoint.GetNumOfPointsCP());
            GameMaster.instance.SetNumOfBullets(Checkpoint.GetNumOfBulletsCP());

        }

        
        GameMaster.instance.AttHud();

    }



 
}

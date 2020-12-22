using UnityEngine.SceneManagement;
using UnityEngine;

public class Health : MonoBehaviour
{

    public Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset(){


        if(GameMaster.instance.GetNumOfHearts() == 0){

           SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        } 

        else {
             PlayerPos.LoadCheckPoint();
             GameMaster.instance.AttHud();

        }

    }

    public void Hurt(){

        anim.SetBool("isHurting", true);
        
    
            GameMaster.instance.SetNumOfHearts(-1);
            
            Reset();
    }
}

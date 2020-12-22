
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;    
    }

    // void OnTriggerEnter2D(Collider2D hitInfo){

    //     if(hitInfo.CompareTag("enemy")){

            

    //     }

    // }

}

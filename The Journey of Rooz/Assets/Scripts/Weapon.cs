
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public GameMaster gm;
    public int bulletQuantity = 0;


    void Start(){

        gm = gameObject.GetComponent<GameMaster>();
        bulletQuantity = GameMaster.instance.GetNumOfBullets();

    }

    // Update is called once per frame
    void Update()
    {
        bulletQuantity = GameMaster.instance.GetNumOfBullets();

        if(Input.GetButtonDown("Fire1") && bulletQuantity > 0){

            Shoot();
            GameMaster.instance.SetNumOfBullets(-1);
            GameMaster.instance.AttHud();
        }
    }

    void Shoot(){

        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }

}

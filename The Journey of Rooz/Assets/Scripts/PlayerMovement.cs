using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
	public  Animator animator;

    public float runSpeed = 40f;
	float horizontalMove = 0f;

	bool jump = false;

    // Update is called once per frame
    void Update()
    { 

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        

    
    	if (Input.GetButtonDown("Jump") ) {

			jump = true;
			animator.SetBool("isJumping", true);
		}

    
    }

	public void OnLanding() {

		animator.SetBool("isJumping", false);

	}

    void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, false , jump);
		jump = false;
	}

}

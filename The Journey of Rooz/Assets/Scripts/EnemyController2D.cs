using UnityEngine;
using UnityEngine.Events;

public class EnemyController2D : MonoBehaviour
{

    
	private Rigidbody2D m_Rigidbody2D;
	private Vector3 m_Velocity = Vector3.zero;


	[Header("Events")]
	[Space]

	public UnityEvent RunRightEvent;
    public UnityEvent RunLeftEvent;

	public void Move(float move){

	    Vector3 targetVelocity = new Vector3(10f, m_Velocity.y, m_Velocity.z);
		Debug.Log(targetVelocity);
		
	}

}

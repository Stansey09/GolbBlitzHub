using UnityEngine;
using System.Collections;

public class BoxingGlove : MonoBehaviour 
{

	public bool isReadyToPunch = true;
	public bool isDonePunching = false;
	public float punchPower  = 20.0f;

	public bool punchingNow = false;
	private float punchingTimer = 0.0f;
	//private Hashtable ht = new Hashtable();
	
	public void Start()
	{
		
	}
	
	public void Update()
	{
		punchingTimer += Time.deltaTime;
		if (punchingTimer > 0.05)
		{
			punchingNow = false;
		}
	}
	
	public void punchGlove()
	{
		//Animate the spatula
		//print ("flippin spatch");
		punchingNow = true;
		punchingTimer = 0.0f;
	}
	
	public void OnTriggerStay(Collider other)
	{
		GameObject CollidingGameObject;
		if (punchingNow)
		{
			print(other.gameObject.name);
			CollidingGameObject = other.gameObject.transform.parent.transform.parent.gameObject;
			if (CollidingGameObject.tag == "Player")
			{
				
				//Vector3 direction = new Vector3(gameObject.transform.up.x, gameObject.transform.up.y, gameObject.transform.forward.z + -0.4f );
				Vector3 direction = transform.forward;
				//direction += transform.up;
				//direction -= transform.forward;
				direction.Normalize();
				other.attachedRigidbody.velocity = direction * punchPower;
				other.attachedRigidbody.angularVelocity = transform.right * punchPower;
				//other.attachedRigidbody.AddForce(direction * punchPower * 50000);
				//Vector3 angula
				//other.attachedRigidbody.angularVelocity = transform.right * punchPower * 50000;
			}
		}
	}
	
	/*
	public void lowerSpatula()
	{
		print ("itWorked");	
	}
	*/
}

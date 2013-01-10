using UnityEngine;
using System.Collections;

/**************
 * controls the actual effect of the spatula weapon,
 * prevents it from flipping to often and makes it
 * behave normally, may be merged with spatula box perhaps.
 * **********/

public class Spatula : MonoBehaviour 
{
	public bool isReadyToFlip = true;
	public bool isDoneFlipping = false;
	public float spatulaPower  = 20.0f;

	public bool flippingNow = false;
	private float flippingTimer = 0.0f;
	private Hashtable ht = new Hashtable();
	
	public void Start()
	{
		
	}
	
	public void Update()
	{
		flippingTimer += Time.deltaTime;
		if (flippingTimer > 0.05)
		{
			flippingNow = false;
		}
	}
	
	public void flipSpatula()
	{
		//Animate the spatula
		//print ("flippin spatch");
		flippingNow = true;
		flippingTimer = 0.0f;
	}
	
	public void OnTriggerStay(Collider other)
	{
		GameObject CollidingGameObject;
		if (flippingNow)
		{
			print(other.gameObject.name);
			CollidingGameObject = other.gameObject.transform.parent.transform.parent.gameObject;
			if (CollidingGameObject.tag == "Player")
			{
				
				//Vector3 direction = new Vector3(gameObject.transform.up.x, gameObject.transform.up.y, gameObject.transform.forward.z + -0.4f );
				Vector3 direction = transform.up * 2;
				direction -= transform.forward;
				direction.Normalize();
				other.attachedRigidbody.velocity = direction * spatulaPower;
				//Vector3 angula
				other.attachedRigidbody.angularVelocity = -transform.right * spatulaPower;
			}
		}
	}
	
	public void lowerSpatula()
	{
		print ("itWorked");	
	}

}

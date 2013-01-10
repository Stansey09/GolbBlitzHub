using UnityEngine;
using System.Collections;

public class MineActiveBehavior : MonoBehaviour 
{
	float radius = 25.0f;
	float power = 1000.0f;
	

	void OnTriggerEnter(Collider other)
	{
		//print (other.gameObject.name);
		if (other.gameObject.name == "mainBody")
		{
			//print ("Going Boom");
			
			explode();
			Destroy(this.gameObject);	
		}
	}
	
	void explode()
	{	
		
		//SOUND EXPLOSION
		
		SoundGod god = GameObject.Find("God").GetComponent<SoundGod>();
		god.PlayExplosion();
		
		Vector3 exposionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(exposionPos, radius);
		
		foreach (Collider hit in colliders)
		{
			//if (!hit || hit.gameObject.name == "Mine(Clone)")
			//	continue;
				//hit.gameObject.GetComponent<MineActiveBehavior>().explode();
			
			if (hit.rigidbody && hit.gameObject.name != "CometBody")	
				hit.rigidbody.AddExplosionForce(power, exposionPos, radius, 10000.0f);
			
			
			if (hit.gameObject.name == "mainBody")
			{
				GameObject player = hit.gameObject.transform.parent.gameObject.transform.parent.gameObject;
				
				player.rigidbody.AddExplosionForce(power * player.rigidbody.mass, exposionPos, radius, 10000.0f);
				//print ("GO BOOM " + hit.gameObject.transform.parent.gameObject.transform.parent.gameObject.name);
			}
			
		}
	}
	
}

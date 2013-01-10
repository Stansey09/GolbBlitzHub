using UnityEngine;
using System.Collections;

public class MissileBehavior : MonoBehaviour 
{
	float Speed = 50f;
	float Turn = 10f;
	
	float accel = 0;
	
	float radius = 10.0f;
	float power = 1000.0f;
	
	string parent;
	
	float live = 5;//in seconds
	float startTime = Time.time;
	
	public AudioClip audio;
	
	SoundGod god; 
	
	void Start()
	{
		god = GameObject.Find("God").GetComponent<SoundGod>();	
	}
	// Update is called once per frame
	void Update () 
	{
		GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");
		GameObject closest = null;
		float closestDist = Mathf.Infinity;
		//float closestDist = 0;
		
		foreach (GameObject i in targets)
		{
			if (i.name != parent)
			{
				float dist = (transform.position - i.transform.position).sqrMagnitude;
					
				if (dist < closestDist)
				//if (dist > closestDist)
				{
					closestDist = dist;
					closest = i as GameObject;
				}
			}
		}
		
	
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(closest.transform.position - transform.position), Turn*Time.deltaTime);
		transform.position += transform.forward*Speed*Time.deltaTime * accel;
		accel += Time.deltaTime;
		
		if (startTime + live <= Time.time)
			Destroy(gameObject);
		
	}
	
	public void setParent(string vParent)
	{
		parent = vParent;
	}
	
	void OnCollisionEnter(Collision other)
	{
		explode();
		//dizzy(other.gameObject);
		//swap(other.gameObject);
		Destroy(gameObject);
	}
	
	
	void swap(GameObject target)
	{
		Vector3 temp = target.transform.position;
		target.transform.position = GameObject.Find(parent).transform.position;
		GameObject.Find(parent).transform.position = temp;
	}
	
	void dizzy(GameObject target)
	{
		target.transform.RotateAround(Vector3.up, Random.Range(1.0f, 360.0f));
	}
	
	
	void explode()
	{
		//print ("GO BOOM ");
		
		//SOUND EXPLOSION
		//AudioSource.PlayClipAtPoint(audio, Vector3.zero);
		god.PlayExplosion();
		Vector3 exposionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(exposionPos, radius);
		
		foreach (Collider hit in colliders)
		{
			if (!hit || hit.gameObject.name == "Missile(Clone)")
				continue;
			
			if (hit.rigidbody && hit.gameObject.name != "CometBody")	
				hit.rigidbody.AddExplosionForce(power * hit.gameObject.rigidbody.mass, exposionPos, radius, 10000.0f);
			
			
			if (hit.gameObject.name == "mainBody")
			{
				GameObject player = hit.gameObject.transform.parent.gameObject.transform.parent.gameObject;
				
				player.rigidbody.AddExplosionForce(power * player.rigidbody.mass, exposionPos, radius, 10000.0f);
				print ("GO BOOM " + player.name);
			}
			
		}
	}
	
	
	/*GameObject getParent(GameObject child)
	{
		return child.transform.parent.gameObject;	
	}*/
	
}
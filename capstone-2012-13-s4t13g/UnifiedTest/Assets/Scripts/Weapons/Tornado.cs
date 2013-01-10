using UnityEngine;
using System.Collections;

/********************************************
 * This class is currently not used in game
 * we can probably delete it
 * ***************************************/

public class Tornado : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		//gameObject.rigidbody.AddTorque(new Vector3(0.0f, 5.0f, 0));
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, 200.0f) * Time.deltaTime);
	}
	
	
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
			other.gameObject.rigidbody.AddForce(new Vector3(2.0f, 4.0f, 2.0f) * 10);
	}
}

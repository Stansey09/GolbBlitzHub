using UnityEngine;
using System.Collections;

public class t08cometBodyGrounded : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		//print(other.gameObject.name);	
		
		if (other.gameObject.name == "Terrain" || other.gameObject.name == "Cube")
		{
			iTween.StopByName("cometMove");	
		}
	}

}

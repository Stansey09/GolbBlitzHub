using UnityEngine;
using System.Collections;

public class t03Collection : MonoBehaviour 
{
	
	public int goldCollected = 0;
	
	
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.name == "Comet" || other.gameObject.name == "Comet(Clone)")
		{
			if (Input.GetAxis("Fire201") != 0 && gameObject.name == "Player01")
			{
				goldCollected += 1;	
				other.gameObject.GetComponent<t04CometScripts>().goldContent--;
			}
			
			if (Input.GetAxis("Fire202") != 0 && gameObject.name == "Player02")
			{
				goldCollected += 1;	
				other.gameObject.GetComponent<t04CometScripts>().goldContent--;
			}
		}
	}
	
	/*void OnGUI()
	{
		float tempTime = (GameObject.Find("Timer").GetComponent<t05Timer>().timeLimet + GameObject.Find("Timer").GetComponent<t05Timer>().startGameTime) - Time.time;
		
		GUI.Box(new Rect(0,0, 100, 25), "Gold: "+goldCollected.ToString());
		GUI.Box(new Rect(0, 30, 100, 25), "Time: "+ tempTime.ToString());
	}*/
}

using UnityEngine;
using System.Collections;

public class t05Timer : MonoBehaviour 
{
	
	public float startGameTime;
	public float timeLimet;
	
	// Use this for initialization
	void Start () 
	{
		//timeLimet = 60;
		timeLimet = 60 * 5;
		startGameTime = Time.time;
	}
	
	void OnGUI()
	{
		if (Time.time >= startGameTime + timeLimet)
		{
			//print ("end Game");
			//Time.timeScale = 0;
			Application.LoadLevel("Intro");
		}
		
//		float p1Gold = GameObject.Find("Player01").GetComponent<t03Collection>().goldCollected;
		//print(GameObject.Find("Player01").transform.GetChild(5).name);
		float p1Gold = GameObject.Find("Player01").transform.GetChild(5).GetComponent<PlayerWeapon>().goldCollected;
		//float p2Gold = GameObject.Find("Player02").GetComponent<t03Collection>().goldCollected;
		
		//reconfigured for the gold gun
		float p2Gold = GameObject.Find("Player02").transform.GetChild(5).GetComponent<PlayerWeapon>().goldCollected;
		
		
		GUI.Box(new Rect(0,(Screen.height / 2) - 12.5f, 200, 25), "Player01 Gold: "+p1Gold.ToString());
		GUI.Box(new Rect(Screen.width - 200, (Screen.height / 2) - 12.5f, 200, 25), "Player02 Gold: "+p2Gold.ToString());
		
		float currentTime = (timeLimet + startGameTime) - Time.time;
		string time = string.Format("{0:0}:{1:00}", Mathf.Floor((currentTime) /60), Mathf.Floor(currentTime) % 60);
		
		GUI.Box(new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 12.5f, 200, 25), "Time: "+ time.ToString());
		
		
		
		
		
	}
}

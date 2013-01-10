using UnityEngine;
using System.Collections;

public class CameraComplete : MonoBehaviour 
{
	GameObject[] players;
	int oldstate;
	
	public GUISkin finalSkin;
	
	// Use this for initialization
	void Start () 
	{
		gameObject.camera.depth = 1;
		Time.timeScale = 0.0f;
		
		players = gameObject.GetComponent<CameraAlmostComplete>().GetPlayers();
		oldstate = (int)Input.GetAxisRaw("P1FireWeapon");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Rect dimentions = gameObject.camera.rect;
		
		//for (int i = 0; i < 4; i++)
		//	if (dimentions[i] < 1.0f)
		//		dimentions[i] += 0.01;
		
		if (dimentions.height < 1.0)
		{
			//position
			if (dimentions.x > 0.0f)
				dimentions.x -= 0.01f;
		
			if (dimentions.y > 0.0f)
				dimentions.y -= 0.01f;
			
			//size
			if (dimentions.width < 1.0f)
				dimentions.width += 0.01f;
			
			if (dimentions.height < 1.0f)
				dimentions.height += 0.01f;
			
			gameObject.camera.rect = dimentions;
		}
		else 
		{
			if (oldstate != (int)Input.GetAxisRaw("P1FireWeapon"))
			{
			
				if (Input.GetAxisRaw("P1FireWeapon") != 0)
				{
					//exit
					Time.timeScale = 1.0f;
					Application.LoadLevel("Intro");
				}
			}
			oldstate = (int)Input.GetAxisRaw("P1FireWeapon");
			
		}
		
		//print(dimentions);
		
		//gameObject.transform.RotateAround(target.transform.position, 10.0f * Time.deltaTime);
		
		gameObject.transform.RotateAround(players[0].transform.position, Vector3.up, 0.1f);//10.0f * Time.deltaTime);
		gameObject.transform.LookAt(players[0].transform.position);
		
		
		
	}
	
	void OnGUI()
	{
		//box layout here
		GUI.skin = finalSkin;
		
		for (int i = 0; i < players.Length; i++)
		{
			int goldAmount = players[i].transform.GetChild(5).GetComponent<PlayerWeapon>().goldCollected;
			
//			GUI.Box(new Rect(0, 110 * i, 500, 100), players[i].gameObject.name.ToString() + " - Score: " + players[i].transform.GetChild(5).GetComponent<PlayerWeapon>().goldCollected.ToString());
			GUI.Box(new Rect(0 + (int)goldAmount/100, 110 * i, 500, 100), players[i].gameObject.name.ToString() + " - Score: " + goldAmount);
			
			//print(GameObject.Find(playerNames[i].ToString()).transform.GetChild(3).name);
			
			//output = playerNames[i] + " Gold: " + GoldAmount.ToString();
			//GUI.Box(new Rect(((Screen.width / 2) * (i % 2)) + 15, ((Screen.height / 2) * (i / 2)) + 15, Screen.width * 0.75, Screen.height * 0.75), output);
		}		
	}
}

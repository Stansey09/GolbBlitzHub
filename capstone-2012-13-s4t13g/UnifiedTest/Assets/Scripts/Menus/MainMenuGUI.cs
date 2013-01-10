using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour 
{
	
	public GUISkin defSkin;
	
	int oldState = 0;
	int currentSelect = 0;
	
	public GameObject splash01;
	public GameObject splash02;
	
	//GameObject[] splashScreens;
	
	ArrayList splashScreens;
	
	int splashCount;
	
	// Use this for initialization
	/*void Start () 
	{
		splashScreens = new ArrayList();
		splashScreens.Add(splash01);
		splashScreens.Add(splash02);
		//splashCount = 0;//splashScreens.Length;
			//for (int i = 0; i < splashScreens.Length; i++)
		FadeEffect();
		print("finishStart");
	}
	
	/*void Update()
	{	
		GatherInput();	
	}*/
	
	/*void FadeEffect()
	{
		/*if (splashCount < splashScreens.Length)
		{
			splashCount++;
			iTween.FadeTo(target, iTween.Hash("alpha", 1.0f, "time", 3.0f, "delay", 0.5f));
			iTween.FadeTo(target, iTween.Hash("alpha", 0.0f, "time", 3.0f, "delay", 4.0f, "oncomplete", "FadeEffect", "oncompleteparams", splashScreens[splashCount]));
		}
		else
		{
			print ("alldone");
			return;
		}*/
		/*
		for (int i = 0; i < splashScreens.Count; i++) 
		{
			print(splashScreens[i]);
			//GameObject target = splashScreens[i] as GameObject;
			iTween.FadeTo(splashScreens[i] as GameObject, iTween.Hash("alpha", 1.0f, "time", 3.0f, "delay", 0.5f));
			iTween.FadeTo(splashScreens[i] as GameObject, iTween.Hash("alpha", 0.0f, "time", 3.0f, "delay", 4.0f));//, "oncomplete", "FadeEffect", "oncompleteparams", splashScreens[splashCount]));
		}
		print ("done");
		
	}*/
	
	
	// Update is called once per frame
	void OnGUI () 
	{
		GUI.skin = defSkin;
		string output = "";
		
		if (currentSelect == 0)
			output = "Play";
		else if (currentSelect == 1)
			output = "Exit";
		
		GUI.Box(new Rect((Screen.width/2) - 75, (Screen.height / 2) + 200, 150, 200), output);
				//GUILayout.Box("GoldBlitz" + currentSelect.ToString());
		
		
		GatherInput();
	}
	
	
	
	void GatherInput()
	{
		if (Input.GetAxisRaw("P1Horizontal") != oldState)
		{
			currentSelect += (int)Input.GetAxisRaw("P1Horizontal");
			
			//check bounds
			if (currentSelect > 1)
				currentSelect = 1;
			else if (currentSelect < 0)
				currentSelect = 0;
			
			oldState = (int)Input.GetAxisRaw("P1Horizontal");
			
			//swap GUITexture
			
		}
		
		if (Input.GetAxis("P1FireWeapon") != 0)
		{
			FireButton(currentSelect);
		}
	}
	
	void FireButton(int selection)
	{
		switch(selection)
		{
		case 0:
			Application.LoadLevel("SelectionScreen");
			break;
		case 1:
			//Application.CancelQuit();
			Application.Quit();
			break;
		default:
			print("Out of bounds");
			break;
		}
	}
	
}

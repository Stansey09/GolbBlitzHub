using UnityEngine;
using System.Collections;

public class SelectMenuGUI : MonoBehaviour 
{
	public GUISkin defSkin;
	
	string[] cars;
	string[] carColors;
	string[] options;
	
	string[][] selections;
	
	int oldStateP1;
	
	void Start()
	{
		cars = new string[]{"Drivers", "Bob Delivers", "SciCo"};
		carColors = new string[]{"Red", "Blue", "Orange", "Purple"};
		//options = new string[]{"Ready"};
		
		
		selections = new string[][]{cars, carColors};
		
		print(cars.Length);
		
		//set max cars on all child objects
		for (int i = 0; i < gameObject.transform.childCount; i++)
			gameObject.transform.GetChild(i).gameObject.GetComponent<SelectCameraGUI>().setMaxCars((int)cars.Length);
	}
	
	public int GetMaxCars()
	{
		return (int)cars.Length;	
	}
	
	public int GetMaxColors()
	{
		return (int)carColors.Length;	
	}
	
	void Update () 
	{	
		//exit during gameplay
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			print("exit");
			//Application.Quit();	
		}
	}
	
	void OnGUI()
	{	
		//all layout controlled here
		
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			GUI.skin = defSkin;
			
			GameObject kid = gameObject.transform.GetChild(i).gameObject;
			kid.GetComponent<SelectCameraGUI>().GatherButtonInput();
			
			//GUI.Box(new Rect(((Screen.width / 2) - 310) + ((Screen.width / 2) *(i%2)), 10 + ((Screen.height / 2) * (i/2)), 300, 200), "Box");
		
			GUILayout.BeginArea(new Rect(((Screen.width / 2) - 520) + ((Screen.width / 2) *(i%2)), 20 + ((Screen.height / 2) * (i/2)), 500, 200));
			
				GUILayout.FlexibleSpace();
			
				if (!kid.GetComponent<SelectCameraGUI>().playerReady)
				{
					kid.GetComponent<SelectCameraGUI>().GatherInput();
					for (int j = 0; j < kid.GetComponent<SelectCameraGUI>().selections.Length; j++)
					{
						if (j == kid.GetComponent<SelectCameraGUI>().currentSelect)
							defSkin.box.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
						else
							defSkin.box.normal.textColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
						GUILayout.Box(selections[j][kid.GetComponent<SelectCameraGUI>().selections[j]]);
					}
				}
				else
				{
					GUILayout.Box("READY");	
				}
				
				
				
				
			//	print(kid.GetComponent<SelectCameraGUI>().selections[i]);
				/*		
					GUILayout.Box(Cars[kid.GetComponent<SelectCameraGUI>().CarSelect]);
			
					GUILayout.Box(CarColors[kid.GetComponent<SelectCameraGUI>().colorSelect]);
			
					GUILayout.Box("Ready");*/
			
				GUILayout.FlexibleSpace();
			
			
			GUILayout.EndArea();
		}		
	}
	
	public void AllReady()
	{
		for (int i = 0; i < gameObject.transform.childCount; i++)
			gameObject.transform.GetChild(i).gameObject.GetComponent<SelectCameraGUI>().playerReady = true;
		
		CheckReady();
	}
	
	public void CheckReady()
	{
		for (int i = 0; i < gameObject.transform.childCount; i++)
			if (gameObject.transform.GetChild(i).gameObject.GetComponent<SelectCameraGUI>().playerReady != true)
				return;
		
		Application.LoadLevel("FourPlayer2");
	}
}

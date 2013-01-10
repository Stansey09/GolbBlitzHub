using UnityEngine;
using System.Collections;

public class SelectCameraGUI : MonoBehaviour 
{
	public int currentSelect = 0;
	public int carSelect = 0;
	public int colorSelect = 1;

	public int maxColor;
	public int maxCars;
	
	public int[] selections;
	public int[] bounds;
	
	int oldState = 0;
	int oldStateVert = 0;
	public bool playerReady;
	
	// Use this for initialization
	void Start () 
	{
		selections = new int[]{carSelect, colorSelect};
		
		maxCars = gameObject.transform.parent.gameObject.GetComponent<SelectMenuGUI>().GetMaxCars();
		maxColor = gameObject.transform.parent.gameObject.GetComponent<SelectMenuGUI>().GetMaxColors();
		bounds = new int[]{maxCars, maxColor};
		print ("MaxColors "+maxColor.ToString());
	}
	
	public void GatherInput()
	{
		string player = gameObject.name;
		
		//Vertical(bumpers) - up/down through selections
		if (Input.GetAxisRaw(player+"Vertical") != oldState)
		{
			currentSelect += (int)Input.GetAxisRaw(player+"Vertical");

			//check bounds
			if (currentSelect >= selections.Length)
				currentSelect = selections.Length - 1;
			else if (currentSelect < 0)
				currentSelect = 0;
			
			oldState = (int)Input.GetAxisRaw(player+"Vertical");
		}
		
		//Horizontal(bumpers) - cycle through options
		if (Input.GetAxisRaw(player+"Horizontal") != oldStateVert)
		{
			//int test = 
			//if ((selections[currentSelect] += (int)Input.GetAxisRaw(player+"Vertical")) < 0 || (selections[currentSelect] += (int)Input.GetAxisRaw(player+"Vertical")) >= selections.Length)
			selections[currentSelect] += (int)Input.GetAxisRaw(player+"Horizontal");
		
			print("Bounds "+bounds[currentSelect]);
			
			//checks bounds
			if (selections[currentSelect] >= bounds[currentSelect])
				selections[currentSelect] = bounds[currentSelect] - 1;
			else if (selections[currentSelect] < 0)
				selections[currentSelect] = 0;
			
			
			print (currentSelect.ToString() + "-" + selections[currentSelect].ToString() + " bound - " + bounds[currentSelect].ToString());
			
			switch (currentSelect)
			{
				//car select
			case 0:
				iTween.MoveTo(gameObject, new Vector3(selections[0] * 20.0f, gameObject.transform.position.y, 0), 1.0f);
				break;
				//Color select
			case 1:
				for (int m = 0; m < maxCars; m++)
				{
					print (selections[currentSelect]);
					GameObject.Find(player+"PropCar_Car0"+m).GetComponent<PropCar>().SwapColor(selections[currentSelect]);
					
				}
				//selections[currentSelection] = GameObject.Find(player+"PropCar_Car01").GetComponent<PropCar>().SwapColor((int)Input.GetAxisRaw(player+"Vertical"));
				break;
			}
			//check bounds
			/*if (currentSelect > 1)
				currentSelect = 1;
			else if (currentSelect < 0)
				currentSelect = 0;*/
			
			oldStateVert = (int)Input.GetAxisRaw(player+"Horizontal");
		}
	}
	
	public void GatherButtonInput()
	{
		string player = gameObject.name;
		
		//Fire Button - set ready active
		if (Input.GetAxis(player+"FireWeapon") != 0)
		{
			//set to ready!
			playerReady = true;
			gameObject.transform.parent.gameObject.GetComponent<SelectMenuGUI>().CheckReady();
		}
		
		//Fire Button - set ready deactive
		if (Input.GetAxis(player+"Swap") != 0)
		{
			//back
			playerReady = false;
		}
		
		if (Input.GetAxis("P1GG") != 0)
		{
			gameObject.transform.parent.gameObject.GetComponent<SelectMenuGUI>().AllReady();	
		}
	}
	
	public void setMaxCars(int vValue)
	{
		maxCars = vValue;
		print (vValue);
		//bounds[(int)0] = vValue;
		//print (bounds[0]);
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/************************************
 * 
 * THis class is the weapon manager and in a word
 * I am sorry. This class became a catch all for 
 * quick solutions to making the weapons work, and
 * as such it has become quite messy. Notice it
 * keeps track of ammunition for all of the weapons,
 * it shouldn't. That information should be moved to 
 * the weapons themselves. there are a bunch of problems
 * here which will no doubt have to be fixed, use
 * comments to see how it works, and that should help
 * with any changes that need to be made
 * *************************************/

public class PlayerWeapon : MonoBehaviour 
{
    //has the index of selected weapon
	public int selectedWeapon;

    //Is used to know when the fire button
    //is pressed as opposed to when it is
    //still pressed
	private bool FireIsReleased;

    //same as above but for the swap button
	private bool SwapIsReleased;

    //keeps track of gold collected, 
	public int goldCollected = 0;

    //amunition amounts and maximum amounts for 
    //different weapons
	public int missileAmount = 0;
	public int mineAmount = 0;
	public int boostAmount = 0;
	public int spatulaAmount = 0;
	public int boxingAmount = 5;
	public int maxMissile = 3;
	public int maxMine = 6;
	public int maxBoost = 5;
	public int maxSpatula = 5;
	public int maxBoxing = 5;

    //used for a since removed gui display 
	public string activeWeapon = "";

    //identifies which of the 4 players this instance of
    //the weapon manager is for, was used for the gui
    //display
	public int playerNumber = -1;

    //this array holds the indices of 4 weapons,
    //that the player has, a -1 indicates that weapon
    //slot is empty
	public int[] currentWeapons = { 0, -1, -1, -1};

    //indicates which weapon slot the selected weapon is in,
    //important for gui.
	public int selectedSlot = 0;

    // this list holds the weapons that are actually in the game
    // and can be used, the list is populated i the start function
	public List<int> existingWeapons = new List<int>();

    //
	public GoldGunBox specialGoldGun;

	//This allows us to trigger sound effects fomr here
	SoundGod god;
	

    //since each weapon is represented by an int, as its index
    //I have an enum that names them
	public enum weaponIndices
	{
		GOLD_GUN = 0,
		MISSILE = 1,
		MINE = 2,
		SPATULA = 3,
		GLOVE = 4,
		BEES = 5,
		BETTER_GOLD_GUN = 6,
		BOOST = 7,
		SPACE_CANNON = 8
	}
	
	void Start()
	{
        //the sound god is the source of all sound
		god = GameObject.Find("God").GetComponent<SoundGod>();
		
		//what weapons are allowed;
		existingWeapons.Add((int)weaponIndices.MISSILE);
		existingWeapons.Add((int)weaponIndices.MINE);
		existingWeapons.Add((int)weaponIndices.SPATULA);
		existingWeapons.Add((int)weaponIndices.BOOST);
		existingWeapons.Add((int)weaponIndices.GLOVE);
		existingWeapons.Add((int)weaponIndices.BETTER_GOLD_GUN);
		
        //you start with the gold gun selected, and its in slot 0
		selectedSlot = 0;
		selectedWeapon = 0;
		
        //we need to know which player we are working with
        //so we know which input to aknowledge
		string playerName = transform.parent.name;
		if (playerName == "Player01" )
		{
			playerNumber = 0;	
		}
		else if (playerName == "Player02" )
		{
			playerNumber = 1;	
		}
		else if (playerName == "Player03" )
		{
			playerNumber = 2;	
		}
		else if (playerName == "Player04" )
		{
			playerNumber = 3;	
		}
	}
	
    //not sure is this function ever gets called
	void Awake()
	{
		SelectWeapon(0);
		selectedSlot = 0;
		selectedWeapon = 0;
	}
	
    //This might be used by the gold gun script, I didn't write that one,
    // either way, I describe in WeaponBox.cs, and I will also mention in a
    //meeting a change I want made, this shouldn't be necessary after that.
	bool getFireState()
	{ return FireIsReleased; }
	
	// Update is called once per frame
	void Update () 
	{

		if (gameObject.gameObject.transform.parent.name == "Player01")
		{
			if (Input.GetAxisRaw("P1Swap") == 1)
			{
				if (SwapIsReleased)
				{
					
					changeWeapon();

					SelectWeapon(selectedWeapon);
					SwapIsReleased = false;
				}
			}
			else if (Input.GetAxisRaw("P1Swap") == 0)
			{
				SwapIsReleased = true;	
			}
			
			if (Input.GetButton("P1GG"))
			{
				selectedWeapon = 0;
				selectedSlot = 0;
				SelectWeapon(selectedWeapon);
			}
		}
		
		//player02
		if (gameObject.gameObject.transform.parent.name == "Player02")
		{
			if (Input.GetAxisRaw("P2Swap") == 1)
			{
				if (SwapIsReleased)
				{
					//selectedWeapon++;
					changeWeapon();

					/*
					
					if (selectedWeapon == 1)
					{
						if (missileAmount < 1)
						{
							selectedWeapon++;	
						}
					}
					if (selectedWeapon == 2 )
					{
						if (mineAmount < 1)
						{
							selectedWeapon++;	
						}
					}
					if (selectedWeapon == 3 )
					{
						if (spatulaAmount < 1)
						{
							selectedWeapon++;	
						}
					}
					if (selectedWeapon == 4 )
					{

						selectedWeapon++;	
						
					}
					if (selectedWeapon == 5 )
					{

						selectedWeapon++;	
						
					}
					if (selectedWeapon == 6 )
					{

						selectedWeapon++;	
						
					}
					if (selectedWeapon == 7 )
					{
						if (boostAmount < 1)
						{
							selectedWeapon++;	
						}
					}
					
					if (selectedWeapon > 7)
						selectedWeapon = 0;//transform.childCount - 1;
					
					*/
					SelectWeapon(selectedWeapon);
					SwapIsReleased = false;
				}
			}
			else if (Input.GetAxisRaw("P2Swap") == 0)
			{
				SwapIsReleased = true;	
			}
			
			if (Input.GetButton("P2GG"))
			{
				selectedWeapon = 0;
				SelectWeapon(selectedWeapon);
			}
		}
		
		//player03
		if (gameObject.gameObject.transform.parent.name == "Player03")
		{
			if (Input.GetAxisRaw("P3Swap") == 1)
			{
				if (SwapIsReleased)
				{
					//selectedWeapon++;
					changeWeapon();

					/*
					
					if (selectedWeapon == 1)
					{
						if (missileAmount < 1)
						{
							selectedWeapon++;	
						}
					}
					if (selectedWeapon == 2 )
					{
						if (mineAmount < 1)
						{
							selectedWeapon++;	
						}
					}
					if (selectedWeapon == 3 )
					{
						if (spatulaAmount < 1)
						{
							selectedWeapon++;	
						}
					}
					if (selectedWeapon == 4 )
					{

						selectedWeapon++;	
						
					}
					if (selectedWeapon == 5 )
					{

						selectedWeapon++;	
						
					}
					if (selectedWeapon == 6 )
					{

						selectedWeapon++;	
						
					}
					if (selectedWeapon == 7 )
					{
						if (boostAmount < 1)
						{
							selectedWeapon++;	
						}
					}
					
					if (selectedWeapon > 7)
						selectedWeapon = 0;//transform.childCount - 1;
					
					*/
					SelectWeapon(selectedWeapon);
					SwapIsReleased = false;
				}
			}
			else if (Input.GetAxisRaw("P3Swap") == 0)
			{
				SwapIsReleased = true;	
			}
			
			if (Input.GetButton("P3GG"))
			{
				selectedWeapon = 0;
				SelectWeapon(selectedWeapon);
			}
		}
		
		//player04
		if (gameObject.gameObject.transform.parent.name == "Player04")
		{
			if (Input.GetAxisRaw("P4Swap") == 1)
			{
				if (SwapIsReleased)
				{
					//selectedWeapon++;
					changeWeapon();

					/*
					
					if (selectedWeapon == 1)
					{
						if (missileAmount < 1)
						{
							selectedWeapon++;	
						}
					}
					if (selectedWeapon == 2 )
					{
						if (mineAmount < 1)
						{
							selectedWeapon++;	
						}
					}
					if (selectedWeapon == 3 )
					{
						if (spatulaAmount < 1)
						{
							selectedWeapon++;	
						}
					}
					if (selectedWeapon == 4 )
					{

						selectedWeapon++;	
						
					}
					if (selectedWeapon == 5 )
					{

						selectedWeapon++;	
						
					}
					if (selectedWeapon == 6 )
					{

						selectedWeapon++;	
						
					}
					if (selectedWeapon == 7 )
					{
						if (boostAmount < 1)
						{
							selectedWeapon++;	
						}
					}
					
					if (selectedWeapon > 7)
						selectedWeapon = 0;//transform.childCount - 1;
					
					*/
					SelectWeapon(selectedWeapon);
					SwapIsReleased = false;
				}
			}
			else if (Input.GetAxisRaw("P4Swap") == 0)
			{
				SwapIsReleased = true;	
			}
			
			if (Input.GetButton("P4GG"))
			{
				selectedWeapon = 0;
				SelectWeapon(selectedWeapon);
			}
		}
		
		
		
		if ((selectedWeapon != 0) && (selectedWeapon != 6))
			CheckFire();
		else
			CheckFireCont();
		
	}
	
	
	void SelectWeapon (int index)
	{
		

		for (int i = 0; i < transform.childCount; i++)
		{
			if (i == index)
			{
				transform.GetChild(i).gameObject.SetActiveRecursively(true);
				activeWeapon = transform.GetChild(i).gameObject.name;
			}
			else
			{
				transform.GetChild(i).gameObject.SetActiveRecursively(false);
			}
		}
		
		//selectedWeapon = index;
	}
	
	void CheckFire()
	{
		if (gameObject.transform.parent.name == "Player01")
		{
			if (Input.GetAxisRaw("P1FireWeapon") == 1)
			{
				if (FireIsReleased)
				{
					gameObject.transform.GetChild(selectedWeapon).GetComponent<WeaponBoxBase>().Fire();
					FireIsReleased = false;			

				}
			}
			else if (Input.GetAxisRaw("P1FireWeapon") == 0)
			{
				FireIsReleased = true;


			}
		}
		
		
		if (gameObject.transform.parent.name == "Player02")
		{
			if (Input.GetAxisRaw("P2FireWeapon") == 1)
			{
				if (FireIsReleased)
				{
					gameObject.transform.GetChild(selectedWeapon).GetComponent<WeaponBoxBase>().Fire();
					FireIsReleased = false;			

				}
			}
			else if (Input.GetAxisRaw("P2FireWeapon") == 0)
			{
				FireIsReleased = true;


			}
		}
		
		if (gameObject.transform.parent.name == "Player03")
		{
			if (Input.GetAxisRaw("P3FireWeapon") == 1)
			{
				if (FireIsReleased)
				{
					gameObject.transform.GetChild(selectedWeapon).GetComponent<WeaponBoxBase>().Fire();
					FireIsReleased = false;			

				}
			}
			else if (Input.GetAxisRaw("P3FireWeapon") == 0)
			{
				FireIsReleased = true;


			}
		}
		
		if (gameObject.transform.parent.name == "Player04")
		{
			if (Input.GetAxisRaw("P4FireWeapon") == 1)
			{
				print ("fire!");
				if (FireIsReleased)
				{
					print ("fire!");
					gameObject.transform.GetChild(selectedWeapon).GetComponent<WeaponBoxBase>().Fire();
					FireIsReleased = false;			

				}
			}
			else if (Input.GetAxisRaw("P4FireWeapon") == 0)
			{
				FireIsReleased = true;


			}
		}
		
	}
	
	void CheckFireCont()
	{
		if (Input.GetAxisRaw("P1FireWeapon") == 1 && gameObject.transform.parent.name == "Player01")
			gameObject.transform.GetChild(selectedWeapon).GetComponent<WeaponBoxBase>().Fire();
		else if (Input.GetAxisRaw("P2FireWeapon") == 1 && gameObject.transform.parent.name == "Player02")
			gameObject.transform.GetChild(selectedWeapon).GetComponent<WeaponBoxBase>().Fire();
		else if (Input.GetAxisRaw("P3FireWeapon") == 1 && gameObject.transform.parent.name == "Player03")
			gameObject.transform.GetChild(selectedWeapon).GetComponent<WeaponBoxBase>().Fire();
		else if (Input.GetAxisRaw("P4FireWeapon") == 1 && gameObject.transform.parent.name == "Player04")
			gameObject.transform.GetChild(selectedWeapon).GetComponent<WeaponBoxBase>().Fire();
	}
	
	/*
	 * for (int i = 0; i < playerNames.Length; i++)
		{
			GoldAmount = GameObject.Find(playerNames[i].ToString()).transform.GetChild(5).GetComponent<PlayerWeapon>().goldCollected;
			output = playerNames[i] + " Gold: " + GoldAmount.ToString();
			GUI.Box(new Rect(((Screen.width / 2) * (i % 2)) + 15, ((Screen.height / 2) * (i / 2)) + 15, boxWidth, boxHeight), output);
		}
	*/
	
	void OnGUI ()
	{
		/*
		string output = string.Empty;
		int widthOffset = 200;
		int heightOffset = 100;

		output = string.Empty;
		output = "Active Weapon:" + activeWeapon + "\n" +
				 "Missiles: " + missileAmount + "/" + maxMissile + "\n" +
				 "Mines: " + mineAmount + "/" + maxMine + "\n" +
				 "Spatula: " + spatulaAmount + "/" + maxSpatula + "\n" +
				 "Boost: " + boostAmount + "/" + maxBoost;
		GUI.Box(new Rect(((Screen.width / 2) * ((playerNumber % 2) + 1) ) - (widthOffset + 15), 
			((Screen.height / 2) * ((playerNumber / 2) + 1)) - (heightOffset + 15), widthOffset, heightOffset), output);
		*/
		
	}
	
	public bool addWeapon(int index)
	{
		int emptySlot = -1;
		print("add weapon " + (weaponIndices)index);
		//bool alreadyHas = true;
		for (int i = 1; i < 4; i++)
		{
			if(currentWeapons[i] == index)
			{
				god.PlayReload();
				return true;
			}
			else if (currentWeapons[i] == -1)
			{
				if (emptySlot == -1)
				{
					emptySlot = i;
					god.PlayNewWeapon();
				}
			}
		}
		if (emptySlot != -1)
		{
			currentWeapons[emptySlot] = index;
			return true;
		}
		
		god.PlayNoCollection();
		return false;
	}
		
	
	public void ammoPickup()
	{
		
		print ("ammo pickup");
		bool success = false;
		int which = -1;
		while (!success)
		{
			which = Random.Range(1,9);
			if (which == (int)weaponIndices.MISSILE)
			{
				if (addWeapon(which))
				{
					missileAmount = maxMissile;
				}
				success = true;
			}
			else if (which == (int)weaponIndices.MINE)
			{
				if (addWeapon(which))
				{
					mineAmount = maxMine;
				}
				success = true;	
			}
			else if (which == (int)weaponIndices.SPATULA)
			{
				if (addWeapon(which))
				{
					spatulaAmount = maxSpatula;
				}
				success = true;	
			}
			else if (which == (int)weaponIndices.BOOST)
			{
				if (addWeapon(which))
				{
					boostAmount = maxBoost;
				}
				success = true;	
			}
			else if (which == (int)weaponIndices.GLOVE)
			{
				if (addWeapon(which))
				{
					boxingAmount = maxBoxing;	
				}
				success = true;
			}
			else if (which == (int)weaponIndices.BETTER_GOLD_GUN)
			{
				if (addWeapon(which))
				{
					specialGoldGun.getSomeTicks();	
				}
				success = true;
			} 
		}
		

	}
	
	public void removeWeapon()
	{
		for (int i = 1; i < 4; i++)
		{
			if (currentWeapons[i] == selectedWeapon)
			{
				currentWeapons[i] = -1;	
			}
		}
		selectedWeapon = 0;
		selectedSlot = 0;
		SelectWeapon(0);
		god.PlayEmpty();
	}
	
	public void changeWeapon()
	{
		
		for ( int i = selectedSlot; i < selectedSlot + 3; i++)
		{
			print((i+1)%4);
			if (currentWeapons[(i+1)%4] != -1)
			{
				selectedSlot = (i+1)%4;
				selectedWeapon = currentWeapons[selectedSlot];
				break;
			}
		}
	
	}
	
}

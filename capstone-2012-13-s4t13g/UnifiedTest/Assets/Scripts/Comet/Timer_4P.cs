using UnityEngine;
using System.Collections;

public class Timer_4P : MonoBehaviour 
{
	
	public float startGameTime;
	public float timeLimet;
	public GUISkin defSkin;
	
	float runTime = 0.0f;
	int warnTime;
	
	
	private float boxWidth;
	private float boxHeight;
	
	bool firstBanter = true;
	bool secondBanter = true;
	bool thirdBanter = true;
	bool fourthBanter = true;
	bool fifthBanter = true;
	
	SoundGod god;
	
	private string[] playerNames;
	// Use this for initialization
	void Start () 
	{
		timeLimet = 60 * 3;
		//timeLimet = 60 * 5;
		//timeLimet = 300;
		//timeLimet = 60 * 5;

		startGameTime = Time.time;
		
		playerNames = new string[]{"Player01", "Player02", "Player03", "Player04"};
		
		//boxWidth = 200.0f;
		//boxHeight = 25.0f;
		
		boxWidth = 220.0f;
		boxHeight = 40.0f;
		
		runTime = 0.0f;
		warnTime = 1;
		
		god = GameObject.Find("God").GetComponent<SoundGod>();
		
	}
	
	void Update()
	{
		//exit during gameplay
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			print("exit");
			//Application.Quit();	
		}
		
		runTime += Time.deltaTime;
		
		if ((runTime > 2 ) && firstBanter)
		{
			god.PlayFirst();
			firstBanter = false;
		}
		if ((runTime > 45 ) && secondBanter)
		{
			god.PlaySecond();
			secondBanter = false;
		}
		if ((runTime > 90 ) && thirdBanter)
		{
			god.PlayThird();
			thirdBanter = false;
		}
		if ((runTime > 135 ) && fourthBanter)
		{
			god.PlayFourth();
			fourthBanter = false;
		}
		if ((runTime > 180 ) && fifthBanter)
		{
			god.PlayFifth();
			fifthBanter = false;
		}
		
	}
	
	void OnGUI()
	{
		GUI.skin = defSkin;
		if (Time.time >= startGameTime + timeLimet)
		{
			EndGame();
		}
		
		float GoldAmount;
		string output;
		
		for (int i = 0; i < playerNames.Length; i++)
		{
			//print(GameObject.Find(playerNames[i].ToString()).transform.GetChild(3).name);
			GoldAmount = GameObject.Find(playerNames[i].ToString()).transform.GetChild(5).GetComponent<PlayerWeapon>().goldCollected;
			//output = playerNames[i] + " Gold: " + GoldAmount.ToString();
			output = "Gold: " + GoldAmount.ToString();
			//output = string.Format("{00000}", GoldAmount);
			GUI.Box(new Rect(((Screen.width / 2) * (i % 2)) + 15, ((Screen.height / 2) * (i / 2)) + 25, boxWidth, boxHeight), output);
		}
		
		float currentTime = (timeLimet + startGameTime) - Time.time;
		string time = string.Format("{0:0}:{1:00}", Mathf.Floor((currentTime) /60), Mathf.Floor(currentTime) % 60);
		GUI.Box(new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 25f, 200, 50), "Time: " + time);
	}
	
	void EndGame()
	{
		GameObject[] players = new GameObject[4];
		
		
		//calculate first player
		
		
		for (int i = 0; i < playerNames.Length; i++)
		{
			
			//Figure out first person here and place them in the array at the appropreate posisionts
			
			GameObject currentPlayer = GameObject.Find(playerNames[i].ToString());
			
			float currentAmount = currentPlayer.transform.GetChild(5).GetComponent<PlayerWeapon>().goldCollected;
			//float playerGold = GameObject.Find(playerNames[i].ToString()).transform.GetChild(5).GetComponent<PlayerWeapon>().goldCollected;
			
			int aheadCounter = 3; 
			
			for (int j = 0; j < playerNames.Length; j++)
			{
				//aheadCounter = 0;
				if (currentAmount > GameObject.Find(playerNames[j].ToString()).transform.GetChild(5).GetComponent<PlayerWeapon>().goldCollected)
				{
					aheadCounter--;
				}		
			}	
			
			//for ties
			while (players[aheadCounter] != null)
			{
				aheadCounter--;
			}
			
			//place player in the correct spot
			players[aheadCounter] = currentPlayer;
			
			
//			players[i] = currentPlayer;
				
		}
		
		
		//print(players[0].gameObject.name[players[0].gameObject.name.Length-1]);
		
		//first person in array gets to get bigger screen
		char firstNumber = players[0].gameObject.name[players[0].gameObject.name.Length-1];
		GameObject firstCamera = GameObject.Find("CarCamera0"+firstNumber);
		
		//attach and remove the appropreate codes - and send the array over
		firstCamera.GetComponent<CameraAlmostComplete>().SetPlayers(players);
		Destroy(firstCamera.GetComponent<SmoothFollow>());
		firstCamera.AddComponent<CameraComplete>();
		Destroy(this);
		
		//Application.LoadLevel("Intro");
	}
	
}

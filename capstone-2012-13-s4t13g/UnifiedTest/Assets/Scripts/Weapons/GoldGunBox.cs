using UnityEngine;
using System.Collections;

public class GoldGunBox : WeaponBoxBase 
{

	//public int goldCollected = 0;
	bool inRange = false;
	
	// gold collected per tick
	public int goldCollectInt = 2;
	
	public bool isFinite;
	public int tickLimit;
	
	// number of ticks per second of gold gunning
	public int goldTicksPerSecond = 10;
	
	public double tickTime;
	public double tickTimer;
	
	private StephenCarController carController;
	
	//bool firing = false;
	
	GameObject comet = null;
	
	public float GunRange = 25.0f;
	
	SoundGod god;
	
	LineRenderer line;
	ParticleSystem system;
	
	public void Start()
	{
		
		god = GameObject.Find("God").GetComponent<SoundGod>();
		tickTime = 1.0 / goldTicksPerSecond;
		tickTimer = 0.0;
		
		carController = transform.parent.transform.parent.GetComponent<StephenCarController>();
	
		line = gameObject.GetComponent<LineRenderer>();
		system = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponentInChildren<ParticleSystem>();
		system.enableEmission = false;
		system.Clear();
		//EraseLine();
	}
	
	public override void Fire ()
	{
		
        
		//print("trying to gather");

		//print ("Fire for gold: "+inRange);
		if ((inRange) && (carController.isGrounded))
		{
			if (tickTimer >= tickTime)
			{
				tickTimer = 0.0;
				if (comet.gameObject.GetComponent<t04CometScripts>().tryMeteor(transform.parent.transform.parent.gameObject))
				{
					
					gameObject.transform.parent.gameObject.GetComponent<PlayerWeapon>().goldCollected += goldCollectInt;
					//print(gameObject.transform.parent.gameObject.name);
					//goldCollected += 1;	
					comet.gameObject.GetComponent<t04CometScripts>().goldContent -= goldCollectInt;
					// SOUND gold "tick"
					god.PlayConnection();
					
					//draing the line
					line.SetPosition(0, gameObject.transform.GetChild(0).transform.GetChild(0).transform.position); 
					line.SetPosition(1, comet.transform.position);
					system.enableEmission = true;
					if (isFinite)
					{
						print ("removing something");
						tickLimit--;
						if (tickLimit <= 0)
						{
							PlayerWeapon weaponManager = transform.parent.gameObject.GetComponent<PlayerWeapon>();
							weaponManager.removeWeapon();
						}
					}
				}
			}
		}
		else
		{
			EraseLine();
		}
	}
	
	
	void Update()
	{
		comet = GameObject.Find("Comet(Clone)");
		
		//print(Vector3.Distance(comet.transform.position, transform.position));
		tickTimer += Time.deltaTime;
		
		if (Vector3.Distance(comet.transform.position, transform.position) <= GunRange)
		{
			inRange = true;	
		}
		else 
			inRange = false;
		
		
		gameObject.transform.GetChild(0).transform.LookAt(comet.transform.position);
		
		gameObject.transform.GetChild(0).transform.GetChild(0).transform.Rotate(new Vector3(0, 0, 10), Space.Self);
	}
	
	public void EraseLine()
	{
		line.SetPosition(0, Vector3.zero);
		line.SetPosition(1, Vector3.zero);
		
		system.enableEmission = false;
		//system.Clear();
		//print ("erasing");
	}
	
	public void getSomeTicks()
	{
		print("getting some ticks");
		tickLimit = 75;
	}
	
	
/*	void OnTriggerStay(Collider other)
	{
		print(other.gameObject.name);
		
		if (other.gameObject.name == "Comet" || other.gameObject.name == "Comet(Clone)")
		{
			inRange = true;
			Comet = other.gameObject;
			print ("withinRange "+inRange);
		}
	}*/
	
	
	/*void OnTriggerEnter(Collider other)
	{
		print ("In Comet Range");
		
		if (other.gameObject.name == "Comet" || other.gameObject.name == "Comet(Clone)")
		{
			inRange = true;
			Comet = other.gameObject;
			print ("withinRange "+inRange);
		}
	}
	void OnTriggerExit(Collider other)
	{
		
		print ("Out of Comet Range");
		if (other.gameObject.name == "Comet" || other.gameObject.name == "Comet(Clone)")
		{
			inRange = false;
			Comet = null;
		}
	}*/
}

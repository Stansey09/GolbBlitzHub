using UnityEngine;
using System.Collections;

public class t04CometScripts : MonoBehaviour 
{
	
	public int goldContent;
	public GameObject prefab;
	
	public GameObject owner = null;
	public float ownerTimer = 0;
	
	//Vector3 spawnPos;
	public Vector3 landingTarget;
	
	//bool grounded;
	
	// Use this for initialization
	void Start () 
	{
		//grounded = false;
		goldContent = 300;
		
		//iTween.MoveTo(gameObject, landingTarget, 2.0f);
		iTween.MoveTo(gameObject, iTween.Hash("name", "cometMove", "position", landingTarget, "time", 3.0f, "easetype", iTween.EaseType.linear));
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		ownerTimer += Time.deltaTime;
		if (ownerTimer > 0.2f)
		{
			owner = null;
		}
		
		if (goldContent <= 0)
		{
			//GameObject.Find("Plain").GetComponent<t06SpawnGround>().Spawn();
			GameObject.Find("Terrain").GetComponent<t06SpawnGround>().Spawn();
			Destroy(gameObject);
			//Spawn();
		}
	}
	
	public bool tryMeteor(GameObject newOwner)
	{
		if ((newOwner == owner) || (owner == null))
		{
			owner = newOwner;
			ownerTimer = 0.0f;
			return true;
		}
		else
		{
		
			return false;
		}
	}

}

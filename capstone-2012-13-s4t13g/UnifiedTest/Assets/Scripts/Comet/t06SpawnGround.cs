using UnityEngine;
using System.Collections;

public class t06SpawnGround : MonoBehaviour 
{
	
	GameObject[] landingSites;
	public GameObject prefab;
	
	void Start()
	{
		landingSites = GameObject.FindGameObjectsWithTag("LandingZones");
		Spawn();	
	}
	
	public void Spawn()
	{
		//GameObject tempGround = GameObject.Find("Plain");
		//print(tempGround)
		//Vector3 landingSite = new Vector3(Random.Range(-tempGround.transform.localScale.x / 2, -tempGround.transform.localScale.x / 2), -tempGround.transform.position.y, Random.Range(-tempGround.transform.localScale.z / 2, -tempGround.transform.localScale.z / 2));
		
		//select random zone
		GameObject landingZone = landingSites[Random.Range(0, landingSites.Length)];
		
		
		Vector3 landingSite = new Vector3(Random.Range(-landingZone.transform.localScale.x / 2, landingZone.transform.localScale.x / 2) + landingZone.transform.position.x, 
			landingZone.transform.position.y, 
			Random.Range(landingZone.transform.localScale.z / 2, -landingZone.transform.localScale.z / 2) + landingZone.transform.position.z);
		
		Vector3 randomSpawn = new Vector3(landingSite.x, 300.0f, landingSite.z);
		
			
		GameObject tempComet = Instantiate(prefab, randomSpawn, Quaternion.identity) as GameObject;
		tempComet.GetComponent<t04CometScripts>().landingTarget = landingSite;
		//GameObject bob = Instantiate(prefab, new Vector3(0, 300, 0), Quaternion.identity);
	}
}

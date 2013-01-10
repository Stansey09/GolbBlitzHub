using UnityEngine;
using System.Collections;

public class ItemPickupCube : MonoBehaviour {
	
	public float crateTimer = 0.0f;
	bool canCollect = true;
	public Material active;
	public Material inActive;
	public MeshRenderer cube1;
	public MeshRenderer cube2;
	public Animation cubeTurn;
	
	// Use this for initialization
	void Start () {
		cubeTurn.wrapMode = WrapMode.Loop;
	}
	
	// Update is called once per frame
	void Update () {
		crateTimer += Time.deltaTime;
		if (crateTimer > 3.0f)
		{
			canCollect = true;
			cube1.material = active;
			cube2.material = active;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		//print (other.gameObject.name);
		if (other.gameObject.name == "mainBody")
		{
			if (canCollect)
			{
				//print(other.gameObject.transform.parent.transform.parent.gameObject.name);
				PlayerWeapon weapon = other.gameObject.transform.parent.transform.parent.gameObject.GetComponentInChildren<PlayerWeapon>();
				weapon.ammoPickup();
				canCollect = false;
				crateTimer = 0.0f;
				//MeshRenderer cubeMesh = gameObject.GetComponent<MeshRenderer>();
				//cubeMesh.material = inActive;
				cube1.material = inActive;
				cube2.material = inActive;
			}
			
		}
	}
}

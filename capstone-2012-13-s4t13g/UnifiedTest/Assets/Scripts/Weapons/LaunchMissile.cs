using UnityEngine;
using System.Collections;

public class LaunchMissile : WeaponBoxBase 
{
	public GameObject prefab;
	private bool FireIsReleased;
	private float missileTimer;
	public float missileCooldown = 10;
	
	public void Start()
	{
		missileTimer = missileCooldown;	
	}
	
	public void Update()
	{
		missileTimer += Time.deltaTime;	
	}
	
	public override void Fire()
	{
		PlayerWeapon weaponManager = transform.parent.gameObject.GetComponent<PlayerWeapon>();
		if (weaponManager.missileAmount > 0)
		{
			GameObject missile = Instantiate(prefab, transform.position + (transform.localPosition + new Vector3(0.0f, 1.0f, 0.0f)), transform.rotation) as GameObject;
			missile.GetComponent<MissileBehavior>().setParent(transform.parent.transform.parent.name);
			missileTimer = 0;
			weaponManager.missileAmount--;
			if (weaponManager.missileAmount == 0)
			{
				weaponManager.removeWeapon();	
			}
		}
		
	}
	
}

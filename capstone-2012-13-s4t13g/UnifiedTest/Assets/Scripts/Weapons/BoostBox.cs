using UnityEngine;
using System.Collections;

public class BoostBox : WeaponBoxBase 
{
	public float BoostTimer;
	public float BoostCooldown = 8.0f;
	//private bool FireIsReleased;
	
	public void Start()
	{
		BoostTimer = BoostCooldown;	
	}
	
	public void Update()
	{
		BoostTimer += Time.deltaTime;
	}
	
	override public void Fire()
	{	
		PlayerWeapon weaponManager = transform.parent.gameObject.GetComponent<PlayerWeapon>();
		if (weaponManager.boostAmount > 0)
		{
			StephenCarController car = transform.parent.transform.parent.GetComponent<StephenCarController>();
			car.activateBoost();
			BoostTimer = 0;
			weaponManager.boostAmount--;
			if (weaponManager.boostAmount == 0)
			{
				weaponManager.removeWeapon();
			}
		}
	}
	
}
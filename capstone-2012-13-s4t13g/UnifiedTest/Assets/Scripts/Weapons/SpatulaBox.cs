using UnityEngine;
using System.Collections;

/********************
 * 
 * spatula weapon controller, not there is also a spatula
 * script that works with this one, might not be necessary 
 ******************/

public class SpatulaBox : WeaponBoxBase 
{
	
	public Animation spatFlip;
	public Spatula spatula;
	
	
	public override void Fire ()
	{
		PlayerWeapon weaponManager = transform.parent.gameObject.GetComponent<PlayerWeapon>();
		if (weaponManager.spatulaAmount > 0 )
		{
			print("happened");
			spatFlip.Play();
			gameObject.GetComponentInChildren<Spatula>().flipSpatula();
			weaponManager.spatulaAmount--;
			
			
		}
		if (weaponManager.spatulaAmount == 0)
		{
			if (spatula.flippingNow == false)
			{
				weaponManager.removeWeapon();
			}
		}
	}
}

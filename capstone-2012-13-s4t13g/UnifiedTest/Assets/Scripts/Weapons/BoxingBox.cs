using UnityEngine;
using System.Collections;

public class BoxingBox : WeaponBoxBase 
{

	public Animation glovePunch;
	public BoxingGlove glove;
	
	public override void Fire ()
	{
		PlayerWeapon weaponManager = transform.parent.gameObject.GetComponent<PlayerWeapon>();
		if (weaponManager.boxingAmount > 0 )
		{
			//print("happened");
			glovePunch.Play();
			gameObject.GetComponentInChildren<BoxingGlove>().punchGlove();
			weaponManager.boxingAmount--;
			if (weaponManager.boxingAmount == 0)
			{
				weaponManager.removeWeapon();
			}
			
		}
		if (weaponManager.boxingAmount == 0)
		{
			if (glove.punchingNow == false)
			{
				weaponManager.removeWeapon();
			}
		}
	}
}

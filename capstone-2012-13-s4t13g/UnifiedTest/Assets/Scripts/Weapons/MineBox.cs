using UnityEngine;
using System.Collections;

public class MineBox : WeaponBoxBase 
{
	public GameObject prefab;
	public float mineTimer;
	//private bool FireIsReleased;
	
	public void Start()
	{
		
	}
	
	public void Update()
	{
		mineTimer += Time.deltaTime;
	}
	
	override public void Fire()
	{	
		PlayerWeapon weaponManager = transform.parent.gameObject.GetComponent<PlayerWeapon>();
		if (weaponManager.mineAmount > 0)
		{
			GameObject Mine = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
			Mine.transform.localPosition += new Vector3(0f, 0f, -2.0f);//sets the mine behind you
			mineTimer = 0;
			weaponManager.mineAmount--;
			if ( weaponManager.mineAmount == 0)
			{
				weaponManager.removeWeapon();	
			}
			
		}
	}
	
	
	
}

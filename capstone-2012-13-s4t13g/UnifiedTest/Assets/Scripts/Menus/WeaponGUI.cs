using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponGUI : MonoBehaviour {
	
	public PlayerWeapon weaponManager;
	public GUITexture firstSlot;
	public GUITexture secondSlot;
	public GUITexture thirdSlot;
	public GUITexture fourthSlot;
	public GUITexture selector;
	public Texture GGIcon;
	public Texture MissileIcon;
	public Texture MineIcon;
	public Texture BoostIcon;
	public Texture NoWeaponIcon;
	public Texture SpatulaIcon;
	public Texture GloveIcon;
	public Texture SGGIcon;
	//public Texture MineIcon;
	public List<GUITexture> slotList;
	
	
	// Use this for initialization
	void Start () {
		slotList = new List<GUITexture>();
		slotList.Add(firstSlot);
		slotList.Add(secondSlot);
		slotList.Add(thirdSlot);
		slotList.Add(fourthSlot);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (weaponManager.selectedSlot == 0)
		{
			selector.gameObject.transform.position = firstSlot.gameObject.transform.position;
			selector.gameObject.transform.Translate(Vector3.forward);
		}
		else if (weaponManager.selectedSlot == 1)
		{
			selector.gameObject.transform.position = secondSlot.gameObject.transform.position;
			selector.gameObject.transform.Translate(Vector3.forward);
		}
		else if (weaponManager.selectedSlot == 2)
		{
			selector.gameObject.transform.position = thirdSlot.gameObject.transform.position;
			selector.gameObject.transform.Translate(Vector3.forward);
		}
		else if (weaponManager.selectedSlot == 3)
		{
			selector.gameObject.transform.position = fourthSlot.gameObject.transform.position;
			selector.gameObject.transform.Translate(Vector3.forward);
		}
		
		for (int i = 0; i < 4; i++)
		{
			if (weaponManager.currentWeapons[i] == (int)PlayerWeapon.weaponIndices.GOLD_GUN)
			{
				slotList[i].texture = GGIcon;	
			}
			else if (weaponManager.currentWeapons[i] == (int)PlayerWeapon.weaponIndices.MISSILE)
			{
				slotList[i].texture = MissileIcon;	
			}
			else if (weaponManager.currentWeapons[i] == (int)PlayerWeapon.weaponIndices.BOOST)
			{
				slotList[i].texture = BoostIcon;	
			}
			else if (weaponManager.currentWeapons[i] == (int)PlayerWeapon.weaponIndices.SPATULA)
			{
				slotList[i].texture = SpatulaIcon;	
			}
			else if (weaponManager.currentWeapons[i] == (int)PlayerWeapon.weaponIndices.MINE)
			{
				slotList[i].texture = MineIcon;	
			}
			else if (weaponManager.currentWeapons[i] == (int)PlayerWeapon.weaponIndices.GLOVE)
			{
				slotList[i].texture = GloveIcon;	
			}
			else if (weaponManager.currentWeapons[i] == (int)PlayerWeapon.weaponIndices.BETTER_GOLD_GUN)
			{
				slotList[i].texture = SGGIcon;	
			}
			else
			{
				slotList[i].texture = NoWeaponIcon;	
			}
		}
		
	}
}

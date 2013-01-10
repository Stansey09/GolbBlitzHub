using UnityEngine;
using System.Collections;

public class GuiGod : MonoBehaviour {
	
	public PlayerWeapon P1Weapon;
	public PlayerWeapon P2Weapon;
	public PlayerWeapon P3Weapon;
	public PlayerWeapon P4Weapon;
	
	public GUITexture P1Gui;
	public GUITexture P2Gui;
	public GUITexture P3Gui;
	public GUITexture P4Gui;
	
	public Texture First;
	public Texture Second;
	public Texture Third;
	public Texture Fourth;
	
	
	// Use this for initialization
	void Start () {
		P1Gui.guiTexture.texture = First;
		P2Gui.guiTexture.texture = First;
		P3Gui.guiTexture.texture = First;
		P4Gui.guiTexture.texture = First;
	}
	
	// Update is called once per frame
	void Update () {
		int aheadCounter;
		
		aheadCounter = 0;
		if (P1Weapon.goldCollected < P2Weapon.goldCollected)
		{
			aheadCounter++;
		}
		if (P1Weapon.goldCollected < P3Weapon.goldCollected)
		{
			aheadCounter++;
		}
		if (P1Weapon.goldCollected < P4Weapon.goldCollected)
		{
			aheadCounter++;
		}
		
		if (aheadCounter == 0)
		{
			P1Gui.guiTexture.texture = First;
		}
		else if (aheadCounter == 1)
		{
			P1Gui.guiTexture.texture = Second;
		}
		else if (aheadCounter == 2)
		{
			P1Gui.guiTexture.texture = Third;
		}
		else if (aheadCounter == 3)
		{
			P1Gui.guiTexture.texture = Fourth;
		}
		
		aheadCounter = 0;
		if (P2Weapon.goldCollected < P1Weapon.goldCollected)
		{
			aheadCounter++;
		}
		if (P2Weapon.goldCollected < P3Weapon.goldCollected)
		{
			aheadCounter++;
		}
		if (P2Weapon.goldCollected < P4Weapon.goldCollected)
		{
			aheadCounter++;
		}
		
		if (aheadCounter == 0)
		{
			P2Gui.guiTexture.texture = First;
		}
		else if (aheadCounter == 1)
		{
			P2Gui.guiTexture.texture = Second;
		}
		else if (aheadCounter == 2)
		{
			P2Gui.guiTexture.texture = Third;
		}
		else if (aheadCounter == 3)
		{
			P2Gui.guiTexture.texture = Fourth;
		}
		
		aheadCounter = 0;
		if (P3Weapon.goldCollected < P1Weapon.goldCollected)
		{
			aheadCounter++;
		}
		if (P3Weapon.goldCollected < P2Weapon.goldCollected)
		{
			aheadCounter++;
		}
		if (P3Weapon.goldCollected < P4Weapon.goldCollected)
		{
			aheadCounter++;
		}
		
		if (aheadCounter == 0)
		{
			P3Gui.guiTexture.texture = First;
		}
		else if (aheadCounter == 1)
		{
			P3Gui.guiTexture.texture = Second;
		}
		else if (aheadCounter == 2)
		{
			P3Gui.guiTexture.texture = Third;
		}
		else if (aheadCounter == 3)
		{
			P3Gui.guiTexture.texture = Fourth;
		}
		
		aheadCounter = 0;
		if (P4Weapon.goldCollected < P1Weapon.goldCollected)
		{
			aheadCounter++;
		}
		if (P4Weapon.goldCollected < P2Weapon.goldCollected)
		{
			aheadCounter++;
		}
		if (P4Weapon.goldCollected < P3Weapon.goldCollected)
		{
			aheadCounter++;
		}
		
		if (aheadCounter == 0)
		{
			P4Gui.guiTexture.texture = First;
		}
		else if (aheadCounter == 1)
		{
			P4Gui.guiTexture.texture = Second;
		}
		else if (aheadCounter == 2)
		{
			P4Gui.guiTexture.texture = Third;
		}
		else if (aheadCounter == 3)
		{
			P4Gui.guiTexture.texture = Fourth;
		}
			
		
	}
}

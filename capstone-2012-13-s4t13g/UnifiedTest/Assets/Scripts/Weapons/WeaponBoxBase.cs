using UnityEngine;
using System.Collections;

/***************************************************
 * This is the base class for all the weapon scripts.
 * 
 * TODO
 * I want the weapon box Fire function removed, and for the 
 * the weapons to instead use their update function. The update will
 * have a boolean for whether or not the fire button is pressed as
 * a parameter. That way the weapons can handle everything else on their
 * own, currently all weapons fire when the fire button is pressed,
 * except the gold gun which is held continiously, the weapon manager
 * handles the difference in how these weapons work which is messy.
 * by having each weapon just know whether the button is pressed, and 
 * know how to behave accordingly is better encapsulated and will allow
 * us to clean up the messy weapons manager
 **************************************************/

public class WeaponBoxBase : MonoBehaviour 
{


/*	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}*/
	
	public virtual void Fire()
	{
		print("KaBoom");	
	}
	
}

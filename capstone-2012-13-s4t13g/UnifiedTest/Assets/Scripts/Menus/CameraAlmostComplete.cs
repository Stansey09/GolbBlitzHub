using UnityEngine;
using System.Collections;

public class CameraAlmostComplete : MonoBehaviour 
{	
	GameObject[] players;
	
	public void SetPlayers(GameObject[] array)
	{
		players = array;	
	}
	
	public GameObject[] GetPlayers()
	{
		return players;	
	}
	
}

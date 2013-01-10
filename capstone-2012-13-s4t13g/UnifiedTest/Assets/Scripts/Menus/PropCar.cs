using UnityEngine;
using System.Collections;

public class PropCar : MonoBehaviour 
{	
	// Update is called once per frame
	
	public Material mat01;
	public Material mat02;
	public Material mat03;
	public Material mat04;
	
	public Material[] colors;
	public string[] colorNames;
	
	//public string name;
	
	void Start()
	{
		colors = new Material[]{mat01, mat02, mat03, mat04};
		colorNames = new string[]{"Red", "Blue", "Orange", "Purple"};
	}
	
	
	void Update () 
	{
		gameObject.transform.Rotate(new Vector3(0f, 0.025f, 0f));
	}
	
	
	public void SwapColor(int index)
	{
		
		/*if (index > colors.Length)
			index = colors.Length;
		else*/
		print ("Index "+index);
		gameObject.transform.GetChild(0).gameObject.renderer.material = colors[index];
		
		
		//return index;
	}
}

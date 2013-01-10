using UnityEngine;
using System.Collections;

public class MineInactiveBehavior : MonoBehaviour 
{
	float timerLimit = 1f;
	public Material Red;

	void Update () 
	{
		timerLimit -= Time.deltaTime;
		if (timerLimit <= 0)
		{
			gameObject.renderer.material = Red;
			Destroy(GetComponent<MineInactiveBehavior>());
			gameObject.AddComponent<MineActiveBehavior>();
		}
	}
}

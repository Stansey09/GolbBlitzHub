using UnityEngine;
using System.Collections;

public class SoundGod : MonoBehaviour {

	public AudioClip explosion;
	public AudioClip newWeapon;
	public AudioClip reload;
	public AudioClip noCollection;
	public AudioClip connection;
	public AudioClip weaponEmpty;
	public AudioClip first;
	public AudioClip second;
	public AudioClip third;
	public AudioClip fourth;
	public AudioClip fifth;
	
	public AudioSource connectionSound;
	
	// Use this for initialization
	void Start () {
		//connectionSound = new AudioSource();
		//connectionSound.clip = connection;
		//connectionSound.
		//connectionSound.audio = connection;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void PlayExplosion()
	{
		print ("boom");
		AudioSource.PlayClipAtPoint(explosion, Vector3.zero);
	}
	
	public void PlayFirst()
	{
		AudioSource.PlayClipAtPoint(first, Vector3.zero);
	}
	
	public void PlaySecond()
	{
		AudioSource.PlayClipAtPoint(second, Vector3.zero);
	}
	
	public void PlayThird()
	{
		AudioSource.PlayClipAtPoint(third, Vector3.zero);
	}
	
	public void PlayFourth()
	{
		AudioSource.PlayClipAtPoint(fourth, Vector3.zero);
	}
	
	public void PlayFifth()
	{
		AudioSource.PlayClipAtPoint(fifth, Vector3.zero);
	}
	
	public void PlayNewWeapon()
	{
		AudioSource.PlayClipAtPoint(newWeapon, Vector3.zero);
	}
	
	public void PlayReload()
	{
		AudioSource.PlayClipAtPoint(reload, Vector3.zero);
	}
	
	public void PlayNoCollection()
	{
		AudioSource.PlayClipAtPoint(noCollection, Vector3.zero);
	}
	
	public void PlayConnection()
	{
		//AudioSource.PlayClipAtPoint(connection, Vector3.zero);
		if (!connectionSound.isPlaying)
		{
			connectionSound.Play();
		}
	}
	
	public void PlayEmpty()
	{
		AudioSource.PlayClipAtPoint(weaponEmpty, Vector3.zero);
	}
}

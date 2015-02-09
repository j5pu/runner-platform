using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	// Use this for initialization

	public AudioClip  clickSound,singleJumpSound;
	public AudioClip coinHitSound;
	public AudioClip StarsSound; 
	public AudioClip coinCounting; 
	public static SoundController Static ;
	public AudioSource[]  audioSources;
	void Start () {
		Static = this;
	}
	
	// Update is called once per frame

	//for single Jump
	public void PlaySingleJumpSound()
	{
		
		swithAudioSources(singleJumpSound);
	}
	 
	//---------------------------------

	public void PlayClickSound()
	{
		 
		swithAudioSources(clickSound);
	}
	 

	public void playcoinCounting()
	{
		
		audio.PlayOneShot(coinCounting);
	}

		public void playCoinHit()
	{
		
		audio.PlayOneShot(coinHitSound);
	}

	public void playStarsSound()
	{
		
		audio.PlayOneShot(StarsSound);
	}
	

	 
	 


	void swithAudioSources( AudioClip clip)
	{
		if(audioSources[0].isPlaying) 
		{
			audioSources[1].PlayOneShot(clip);
		}
		else audioSources[0].PlayOneShot(clip);

	}
}

﻿using UnityEngine;
using System.Collections;
using System;
public class CollisionAndTrigger : MonoBehaviour {

	// Use this for initialization


	public GameObject ScorePrefab;
	public IngameUI IngameUIChild;
	public static EventHandler displayAd; 
	public PlayerController playerControllerChild;


	void Start()
	{

	 
		IngameUIChild = GameObject.FindGameObjectWithTag("uiCam").GetComponent<IngameUI> ();
		}

	void OnTriggerEnter( Collider incoming)
	{
		if (incoming.tag=="coin")
		{
			incoming.gameObject.SetActive(false);
			IngameUIChild.numberofCoins++;
			IngameUI.scoreCount=IngameUI.scoreCount+100;
			GameObject ScoreIndicator=Instantiate(ScorePrefab,incoming.transform.position,Quaternion.identity)as GameObject;
			
		}
		IngameUIChild.displyCount.text = IngameUIChild.numberofCoins.ToString ();

	}
	void OnControllerColliderHit(ControllerColliderHit hit) 
	{
		if (hit.collider.tag=="coin")
		{
			hit.gameObject.SetActive(false);
			IngameUIChild.numberofCoins++;

			GameObject ScoreIndicator=Instantiate(ScorePrefab,hit.collider.transform.position,Quaternion.identity)as GameObject;

				}
		IngameUIChild.displyCount.text = IngameUIChild.numberofCoins.ToString ();


		if (hit.collider.name.Contains ("respawn")) 
		{
			IngameUIChild.life--;
			if (IngameUIChild.life < 0) 
			{
				IngameUIChild.OnGameOver();
				
				//gameObject.GetComponent<playerControl>().enabled=false;
			}
		 	else{
				//hit.gameObject.GetComponent<PlayerHurt>().Update();
				transform.position=  hit.collider.transform.GetChild(0).transform.position;
			}
			 

		}

		IngameUIChild.lifeText.text = IngameUIChild.life.ToString ();


		if (hit.collider.name.Contains ("final")) 
		{
			 
			hit.collider.name="END";
			gameObject.SendMessage("StopPlayerAnimation",SendMessageOptions.DontRequireReceiver);

			IngameUIChild.OnLevelEnd();

		  if(displayAd != null)	displayAd(null,null);



		
		}

	}
}

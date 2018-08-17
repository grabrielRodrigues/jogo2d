﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

	public static GM instance = null;

	public float yMinLIve = -8f;

	PlayerCtrl player;

	public float timeToRespawn = 2f;
	public Transform spawnPoint;
	public GameObject playerPrefab;

	public UI ui;

	GameData data = new GameData();

	void Awake(){
		if (instance == null){
			instance = this;
		}
	}

	void Start () {
		if (player == null){
			RespawnPlayer();
		}
	}
	
	void Update () {
		if (player == null){
			GameObject obj = GameObject.FindGameObjectWithTag("Player");
			if (obj != null){
				player = obj.GetComponent<PlayerCtrl>();
			}
		}
		DisplayHudData();
	}

	void DisplayHudData(){
		ui.hud.txtCoinCount.text = "x " + data.coinCount;
	}

	public void IncrementCoinCount(){
		data.coinCount++;
	}

	public void RespawnPlayer(){
		Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
	}

	public void KillPlayer(){
		if (player != null){
			Destroy(player.gameObject);
			Invoke("RespawnPlayer", timeToRespawn);
		}
	}
}

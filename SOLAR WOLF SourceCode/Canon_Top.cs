﻿using UnityEngine;
using System.Collections;

public class Canon_Top: MonoBehaviour {

	public float time;
	public float num;
	public float freqOfFire;                 //freqOfFire will be varied in different levls to vary the difficulty;
	public float speed;

	public GameObject fireBall;
	public Transform shotSpawn;

	public AudioSource shootSound;

	public GameControllerSOLAR controller;

	void Start()
	{
		time = 0;
		num = Random.Range (0, freqOfFire);  

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if(gameControllerObject != null)
		{
			controller = gameControllerObject.GetComponent<GameControllerSOLAR>();
		}
	}

	void Update()
	{
		float swing = Mathf.PingPong (Time.time * speed, 48);
		transform.position= new Vector3( (swing - 24), transform.position.y, transform.position.z);

		time += Time.deltaTime;
		//Debug.Log (time);

		if(time > (num/100.0f) - 0.05 && time < (num/100.0f) + 0.05)
		{
			time = 0;
			num = Random.Range(0, freqOfFire);
			if(controller.startShooting)
			{
				Instantiate(fireBall, shotSpawn.position, shotSpawn.rotation);
				shootSound.Play();
			}
		}
	}
}

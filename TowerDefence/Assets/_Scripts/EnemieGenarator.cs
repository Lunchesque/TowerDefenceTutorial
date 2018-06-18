using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieGenarator : MonoBehaviour 
{
	[SerializeField] private GameObject enemie;
	[SerializeField] private float waveDelay = 10.0f;
	[SerializeField] private int count = 10;
	[SerializeField] private float spawnDelay;


	private bool isWave;
	float currentTime;
	private int currentCount;

	private void Update()
	{
		currentTime += Time.deltaTime;
		
		if(isWave)
			ProcessWave();
		else
			Wait();
	}

	private void Wait()
	{
		if(currentTime >= waveDelay)
		{
			currentTime = 0.0f;
			isWave = true;
		}
	}

	private void ProcessWave()
	{


		if (currentTime >= spawnDelay)
		{
			currentTime = 0.0f;

			GameObject newEnemie = Instantiate(enemie);
			newEnemie.SetActive(true);
			currentCount++;
		}

		if (currentCount >= count)
		{
			currentTime = 0.0f;
			currentCount = 0;
			isWave = false;
		}
	}
}

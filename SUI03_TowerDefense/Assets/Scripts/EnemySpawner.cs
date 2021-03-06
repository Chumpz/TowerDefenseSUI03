using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[SerializeField] 
	private GameObject enemyPrefab;
	private GameObject enemy;
	float timer;
	float timeBetweenWaves = 10.0f;


	void start()
	{
		timer = 2.0f; 
	}


	void Update()
	{		
		if (timer <= 0.0f)
		{
			StartCoroutine (WaveSpawning());
			timer = timeBetweenWaves;
		}
		timer -= Time.deltaTime;

	}


	void EnemySpawning()
	{
		int waveIncrease = 4;
		int waveNumber = 0;

		Debug.Log ("New wave incoming");

		waveNumber += waveIncrease;

		for (int i = 0; i < waveNumber; i++) 
		{				
			enemy = Instantiate (enemyPrefab) as GameObject;
			enemy.transform.position = new Vector3 (5, 4, 25);
			WaveSpawning ();
		}
		if (waveNumber >= 20) {
			Debug.Log ("You won");
		}

	}


	public IEnumerator WaveSpawning()
	{

		yield return new WaitForSeconds (1.0f);
		
	}	
}
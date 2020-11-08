using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	public IEnumerator SpawnEnemiesCoro;
	// Minumum and maximum values from the centre
	public float min = 3.0f;
	public float max = 7.0f;
	public float spawnDelay = 0.2f;


	// Use this for initialization
	void Start()
	{
		//1.8
		SpawnEnemiesCoro = SpawnEnemies(spawnDelay);
		StartCoroutine(SpawnEnemiesCoro);
	}

	private IEnumerator SpawnEnemies(float waitTime)
	{
		while (true)
		{
			if (!GameManager.instance.isPaused)
			{
				float delta = max - min;
				// Get random point on line
				float length = min + delta * Random.value;
				// Get random point from circle's area
				var randomPosInWorld = Random.insideUnitCircle.normalized * length;
				GameObject enemy = Instantiate(enemyPrefab, randomPosInWorld, Quaternion.identity);
				GameManager.instance.enemies.Add(enemy);
				yield return new WaitForSeconds(waitTime);
			}
			yield return new WaitForSeconds(spawnDelay);
		}
	}
}

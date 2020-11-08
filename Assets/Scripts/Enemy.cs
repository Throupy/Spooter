using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private bool isDead;

	public GameObject explosion;

	private void Start()
	{
		explosion = gameObject.transform.Find("Explosion").gameObject;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if ((collision.tag == "Bullet" || collision.tag == "BombExplosion") && !isDead)
		{
			isDead = true;
			ScoreManager.instance.AddScore(1);
			explosion.SetActive(true);
			Destroy(gameObject, 
				explosion.gameObject.transform.Find("ExpAnimator").gameObject.GetComponent<Animator>()
				.GetCurrentAnimatorStateInfo(0).length - 0.5f);
			GameManager.instance.enemies.Remove(gameObject);
		} else if (collision.tag == "HomePlanet" && !isDead)
		{
			Debug.Log("game over");
			GameManager.instance.enemies.Remove(gameObject);
			//GameManager.instance.EndGame();
		} else if (collision.tag == "Missile" && !isDead)
		{
			isDead = true;
			ScoreManager.instance.AddScore(1);
			explosion.SetActive(true);
			Destroy(gameObject,
				explosion.gameObject.transform.Find("ExpAnimator").gameObject.GetComponent<Animator>()
				.GetCurrentAnimatorStateInfo(0).length - 0.5f);
			GameManager.instance.enemies.Remove(gameObject);
		}
	}
}

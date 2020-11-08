using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	public bool isPaused = false;

	public GameObject homePlanet;
	public GameObject pausePanel;
	public List<GameObject> enemies = new List<GameObject>();

	public static GameManager instance;
	public static GameManager Instance { get { return instance; } }


	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
		}
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			// Toggle shop
			ShopManager.instance.ToggleShop();
		}
		if(Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			GameManager.instance.TogglePause();
			Debug.Log("Game Paused: " + isPaused.ToString());
		}
	}

	public void EndGame()
	{
		IEnumerator endGameCoro = EndGameCoro();
		StartCoroutine(endGameCoro);
	}

	public void TogglePause()
	{
		isPaused = !isPaused;
		if (isPaused) { pausePanel.SetActive(true); }
		else { pausePanel.SetActive(false); }
	}

	IEnumerator EndGameCoro()
	{
		homePlanet.GetComponent<Rigidbody2D>().gravityScale = 1;
		yield return new WaitForSecondsRealtime(1f);
		Time.timeScale = 0;
	}
}

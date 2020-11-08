using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
	public GameObject towerPrefab;
	public GameObject missileTowerPrefab;
	public GameObject shopPanel;
	public IEnumerator beginPlacementCoro;

	public bool shopOpen;

	public static ShopManager instance;
	public static ShopManager Instance { get { return instance; } }

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

	public IEnumerator BeginPlacement(GameObject tower)
	{
		while (true)
		{
			// Inefficient - better method needed
			yield return new WaitForSecondsRealtime(0.01f);
			tower.transform.position = Vector2.MoveTowards(tower.transform.position,
				Camera.main.ScreenToWorldPoint(Input.mousePosition), 
				10 * Time.deltaTime);
			if (Input.GetMouseButtonDown(0))
			{
				CloseShop(false);
				shopOpen = false;
				yield break;
			}
		}
		
	}

	public void ToggleShop()
	{
		if (!shopOpen) { OpenShop(); }
		else { CloseShop(false); }
	}

	public void OpenShop() {
		shopOpen = true;
		// Vector3(1, 1, 1) represents the whole screen, Vector3(0, 0, 0) is the very middle
		LeanTween.scale(shopPanel, new Vector3(1, 1, 1), 0.5f);
	}

	public void CloseShop(bool instantClose = false)
	{ 
		shopOpen = false;
		if (instantClose) {
			LeanTween.scale(shopPanel, new Vector3(0, 0, 0), 0f);
		}
		else { 
			LeanTween.scale(shopPanel, new Vector3(0, 0, 0), 0.5f); 
		}
	}

	public void BuyTower(GameObject planet)
	{
		// Change price
		if (ScoreManager.instance.score >= 0)
		{
			CloseShop(true);
			GameObject tower = Instantiate(planet, Vector3.zero, Quaternion.identity);
			beginPlacementCoro = BeginPlacement(tower);
			StartCoroutine(beginPlacementCoro);
		}
	}

}

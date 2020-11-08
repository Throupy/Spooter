using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpEffect : MonoBehaviour {

	public float expandSpeed = 30f;

	void Start () {
		transform.localScale = Vector3.zero;
	}
	
	void Update () {
		transform.localScale += Vector3.one * expandSpeed * Time.deltaTime;
	}
}

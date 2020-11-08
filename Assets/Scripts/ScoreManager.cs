using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] private static Slider slider;
	[SerializeField] private TMP_Text pointsText;
	[SerializeField] private TMP_Text currentScoreText;
	[SerializeField] private TMP_Text targetScoreText;
	public int score;
	[SerializeField] private GameObject levelUpEffect;

	public int levelsCompleted = 0;

	public static ScoreManager instance;
	public static ScoreManager Instance { get { return instance; } }

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

	private void Start()
	{
		instance = this;
		pointsText = GameObject.Find("Points Text").GetComponent<TMP_Text>();
		slider = GameObject.Find("Score Slider").GetComponent<Slider>();
		targetScoreText.text = slider.maxValue.ToString();
	}

	public void LevelUp()
	{
		slider.value = 0;
		levelsCompleted++;
		slider.minValue = slider.maxValue;
		slider.maxValue += 10;
	}

	public void AddScore(int _score)
	{
		if (slider.value == slider.maxValue)
		{
			IEnumerator levelUp = LevelUpEffect();
			StartCoroutine(levelUp);
			return;
		}
		score += _score;
		pointsText.text = "Points: " + score.ToString();
		currentScoreText.text = score.ToString();
		slider.value += 1;
	}

	IEnumerator LevelUpEffect()
	{
		targetScoreText.text = (slider.maxValue + 10).ToString();
		Instantiate(levelUpEffect, 
			Vector3.zero, 
			Quaternion.identity);
		LevelUp();
		// Slow down time
		Time.timeScale = 0.3f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
		yield return new WaitForSecondsRealtime(1f);
		// Speed up time
		Time.timeScale = 1f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
	}

}

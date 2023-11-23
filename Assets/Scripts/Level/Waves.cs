using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Waves : MonoBehaviour
{
	public Text waveCountText;


	public float waveStartDelay;
	public float timer;

	public LevelInfo levelInfo;
	public Spawner spawner;
	public enum WaveDificulty { Easy, Medium, Normal, Hard };
	public WaveDificulty waveDificulty;

	public List<int> waveCount = new List<int>();
	List<int> enemyCount = new List<int>();
	void Start()
	{
		waveCount.Capacity = levelInfo.maxWaveCount;		
	}
	public void EnemiesPerWave()
	{
		
		waveCount.Add(1);
		
		foreach (int wave in waveCount)
		{
			if (waveDificulty == WaveDificulty.Easy)
			{
				if (spawner.maxNumOfEnemies < 75)
				{
					spawner.maxNumOfEnemies += (spawner.maxNumOfEnemies / 5);
				}else { spawner.maxNumOfEnemies = 75; }
			}
			else if (waveDificulty == WaveDificulty.Medium)
			{
				if (spawner.maxNumOfEnemies < 195)
				{
					spawner.maxNumOfEnemies += (spawner.maxNumOfEnemies / 5);
				}
				else { spawner.maxNumOfEnemies = 195; }
			}
			else if (waveDificulty == WaveDificulty.Normal)
			{
				if (spawner.maxNumOfEnemies < 500)
				{
					spawner.maxNumOfEnemies += (spawner.maxNumOfEnemies / 5);
				}
				else { spawner.maxNumOfEnemies = 500; }
			}
			else if (waveDificulty == WaveDificulty.Hard)
			{
				if (spawner.maxNumOfEnemies < 1500)
				{
					spawner.maxNumOfEnemies += (spawner.maxNumOfEnemies / 5);
				}
				else { spawner.maxNumOfEnemies = 1500; }
			}
		}
		spawner.numOfEnemies = 0;
	}
	public void selectWaveDificulty()
	{
		if (waveDificulty == WaveDificulty.Easy)
		{
			Debug.Log("75% || 0.75x");
			levelInfo.waveDifficultyText = "Easy";
		}
		else if (waveDificulty == WaveDificulty.Medium)
		{
			Debug.Log("100% || 1x");
			levelInfo.waveDifficultyText = "Medium";
		}
		else if (waveDificulty == WaveDificulty.Normal)
		{
			Debug.Log("125% || 1.25x");
			levelInfo.waveDifficultyText = "Normal";
		}
		else if (waveDificulty == WaveDificulty.Hard)
		{
			Debug.Log("200% || 2x");
			levelInfo.waveDifficultyText = "Hard";
		}
	}
	void Update()
	 {
		waveCountText.text = waveCount.Count + " / " + levelInfo.maxWaveCount;
		Debug.Log(spawner.enemies.Count);
		selectWaveDificulty();
		if (spawner.enemies.Count <= 0)
		{
			timer += Time.deltaTime;
			if (timer > waveStartDelay)
			{
				timer = 0;
				EnemiesPerWave();
			}
		}else { timer = 0; }
	 }
}

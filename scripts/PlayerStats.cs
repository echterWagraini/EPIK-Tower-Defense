using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
	public static PlayerStats instance;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one PlayerStats in scene!");
			return;
		}
		instance = this;
	}

	public static int Money;
	public int startMoney = 400;

	public static int Lives;
	public int startLives = 2;

	public static int Rounds;

	public Text moneyText;
	public Text hpText;
	public Text infoText;

	public GameObject mainCanvas;
	public GameObject pauseCanvas;
	public bool paused;

	void Start()
	{
		pauseCanvas.SetActive(false);
		paused = false;

		Money = startMoney;
		Lives = startLives;

		Rounds = 0;
	}

	// Update is called once per frame
	void Update()
	{
		moneyText.text = "Money: " + Money.ToString();
		hpText.text = "HP: " + Lives.ToString();

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (paused == true)
				UnPause();
			else
				Pause();
		}

        if (Lives <= 0)
        {
			GameOver();
        }
	}

	void Pause()
    {
		mainCanvas.SetActive(false);
		pauseCanvas.SetActive(true);
		paused = true;

		Time.timeScale = 0;
	}
	void UnPause()
	{
		mainCanvas.SetActive(true);
		pauseCanvas.SetActive(false);
		paused = false;

		Time.timeScale = 1;
	}
	void GameOver()
    {
		mainCanvas.SetActive(false);
		pauseCanvas.SetActive(true);

		infoText.text = "Game Over!";

		Time.timeScale = 0;
    }
	public void looseHealth(int damage)
    {
		Lives -= damage;
    }
	public void earnMoney(int amount)
    {
		Money += amount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {


    public static PlayerStats instance;

    private void Awake()
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
    public Text MoneyText;
   

    public static int Lives;
    public static int startLives = 1;
    public Text LivesText;

    public static int Rounds;


    void Start()
    {
        Money = startMoney;
        MoneyText.text = Money.ToString();
        Lives = startLives;
        LivesText.text = Lives.ToString();
        Rounds = 0;
    }

    public void ReduceLives()
    {
        Lives--;
        LivesText.text = Lives.ToString();
    }
    public void ReduceMoney(int cost)
    {
        Money -= cost;
        MoneyText.text = Money.ToString();
    }
    public void IncreaseMoney(int gain)
    {
        Money += gain;
        MoneyText.text = Money.ToString();
    }
    public int getLives()
    {
        return Lives;
    }

}

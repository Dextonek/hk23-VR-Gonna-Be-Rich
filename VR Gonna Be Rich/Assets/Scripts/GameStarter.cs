using System.Collections;
using System.Collections.Generic;
using Game_Logic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuGameObject;
    [SerializeField] private GameObject gameObjectsGameObject;
    
    public static float StartingBankAccountBalance;
    public static float StartingSavingsAccountBalance;
    public static float StartingInvestmentAccountBalance;

    public static List<Expense> StartingExpenses;
    public static List<Earning> StartingEarnings;

    public void EasyStart()
    {
        StartingBankAccountBalance = 1000f;
        StartingSavingsAccountBalance = 1000f;
        StartingInvestmentAccountBalance = 1000f;

        StartingExpenses = new List<Expense>();
        StartingExpenses.Add(new Expense("Rent", 530f));
        StartingExpenses.Add(new Expense("Food", 300f));

        StartingEarnings = new List<Earning>();
        StartingEarnings.Add(new Earning("Work", 2000f));
        
        StartGame();
    }

    private void StartGame()
    {
        mainMenuGameObject.SetActive(false);
        gameObjectsGameObject.SetActive(true);
    }
}

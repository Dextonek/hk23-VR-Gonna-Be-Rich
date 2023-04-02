using System;
using System.Globalization;
using Game_Logic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WhiteboardRightManager : MonoBehaviour
{
    

    [SerializeField] private TextMeshProUGUI dateField;

    [SerializeField] private TextMeshProUGUI bankAccountBalanceField;

    [SerializeField] private TextMeshProUGUI savingsAccountBalanceField;
    
    [SerializeField] private TextMeshProUGUI investmentsAccountBalanceField;

    [SerializeField] private TextMeshProUGUI netWorthField;


    private void OnEnable()
    {
        DateManager.Instance.OnCurrentDateChanged += DateChanged;
        BankAccountManager.Instance.OnAccountBalanceChanged += BankAccountBalanceChanged;
        SavingsSystem.Instance.OnSavingsChanged += SavingsAccountBalanceChanged;
        InvestmentsManager.Instance.OnInvestmentsChanged += InvestmentsAccountBalanceChanged;
        
        DateChanged(DateManager.Instance.CurrentDate);
        BankAccountBalanceChanged(BankAccountManager.Instance.Balance);
        SavingsAccountBalanceChanged(SavingsSystem.Instance.Savings);
        InvestmentsAccountBalanceChanged(InvestmentsManager.Instance.Investments);
    }

    public void DateChanged(DateTime date)
    {
        dateField.text = date.ToString("d.M.yyyy");
    }

    public void BankAccountBalanceChanged(float value)
    {
        bankAccountBalanceField.text = value.ToString("F2");
        CalculateNetWorth();
    }
    
    public void SavingsAccountBalanceChanged(float value)
    {
        savingsAccountBalanceField.text = value.ToString("F2");
        CalculateNetWorth();
    }
    
    public void InvestmentsAccountBalanceChanged(float value)
    {
        investmentsAccountBalanceField.text = value.ToString("F2");
        CalculateNetWorth();
    }

    public void CalculateNetWorth()
    {
        var netWorth = BankAccountManager.Instance.Balance + SavingsSystem.Instance.Savings +
                       InvestmentsManager.Instance.Investments;

        netWorthField.text = "Net worth: " + netWorth.ToString("F2");
    }

    public void AdvanceTime()
    {
        DateManager.Instance.OnAdvanceTimeButtonClick();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Game_Logic;
using TMPro;
using UnityEngine;

public class WhiteBoardLeftManager : MonoBehaviour
{
    [Header("Expenses")]
    [SerializeField] private TextMeshProUGUI rentValueText;
    [SerializeField] private TextMeshProUGUI foodValueText;
    [SerializeField] private TextMeshProUGUI totalValueText;

    [Header("Earnings")] 
    [SerializeField] private TextMeshProUGUI earningsValueText;
    
    [Header("Profits")]
    [SerializeField] private TextMeshProUGUI profitsValueText;

    private float _total;

    private void OnEnable()
    {
        var expenses = ExpensesSystem.Instance.Expenses;
        foreach (var expense in expenses)
        {
            _total += expense.Amount;
            
            if (expense.Name == "Rent")
            {
                rentValueText.text = expense.Amount.ToString("F2");
            }

            if (expense.Name == "Food")
            {
                foodValueText.text = expense.Amount.ToString("F2");
            }
        }

        totalValueText.text = _total.ToString("F2");

        earningsValueText.text = EarningSystem.Instance.Earnings.ToArray()[0].Amount.ToString("F2");
        profitsValueText.text = (EarningSystem.Instance.Earnings.ToArray()[0].Amount - _total).ToString("F2");
    }
}

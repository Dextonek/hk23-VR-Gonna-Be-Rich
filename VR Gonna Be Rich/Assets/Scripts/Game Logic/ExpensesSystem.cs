using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game_Logic
{
    public struct Expense
    {
        public string Name { get;}
        public float Amount { get;} 

        public Expense(string name, float amount)
        {
            Name = name;
            Amount = amount;
        }
    }
    
    public class ExpensesSystem : MonoBehaviour
    {
        public static ExpensesSystem Instance { get; private set; }

        private List<Expense> _expenses;
        public List<Expense> Expenses
        {
            set
            {
                if (value.SequenceEqual(_expenses))
                    return;

                _expenses = value;
                OnExpensesChanged?.Invoke(value);
            }

            get => _expenses;
        }
        
        public delegate void OnExpensesChangedDelegate(List<Expense> expenses);

        public event OnExpensesChangedDelegate OnExpensesChanged;
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            
            Instance = this;
        }
        
        private void OnDestroy()
        {
            if (Instance == this)
                Instance = null;
        }

        private void OnEnable()
        {
            DateManager.Instance.OnMonthAdvanced += PayExpenses;
        }

        private void OnDisable()
        {
            if (!BankAccountManager.Instance)
                return;
            
            DateManager.Instance.OnMonthAdvanced -= PayExpenses;
        }

        private void PayExpenses(DateTime currentDate)
        {
            foreach (var expense in Expenses)
            {
                BankAccountManager.Instance.Balance -= expense.Amount;
            }
        }
    }
}

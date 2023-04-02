using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game_Logic
{
    public class Loan
    {
        private float _amount;

        public float Amount
        {
            set
            {
                _amount = value;
                if (_amount <= 0)
                {
                    ExpensesSystem.Instance.Expenses.Remove(Expense);
                    LoansSystem.Instance.Loans.Remove(this);
                }
            }

            get => _amount;
        }
        public Expense Expense { get; }
        public float MonthlyPayment { get; }

        public Loan(float amount)
        {
            Amount = amount;
            MonthlyPayment = Amount / 12;
            Expense = new Expense("Loan", MonthlyPayment * 1.04f);
        }
    }

    public class LoansSystem : MonoBehaviour
    {
        public static LoansSystem Instance { get; private set; }
        private List<Loan> _loans;

        public List<Loan> Loans
        {
            set
            {
                if (value.SequenceEqual(_loans))
                    return;

                _loans = value;
                OnLoansChanged?.Invoke(value);
            }

            get => _loans;
        }

        public delegate void OnLoansChangedDelegate(List<Loan> loans);

        public event OnLoansChangedDelegate OnLoansChanged;

        private void OnEnable()
        {
            DateManager.Instance.OnMonthAdvanced += PayLoans;
        }

        private void OnDisable()
        {
            if (!BankAccountManager.Instance)
                return;

            DateManager.Instance.OnMonthAdvanced -= PayLoans;
        }

        public void PayLoans(DateTime currentDate)
        {
            if(Loans == null)
                return;
            
            foreach (var loan in Loans)
            {
                loan.Amount -= loan.MonthlyPayment;
            }
        }
    }
}
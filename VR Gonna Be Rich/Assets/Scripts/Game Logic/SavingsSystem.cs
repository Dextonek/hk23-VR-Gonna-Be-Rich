using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game_Logic
{
    public class SavingsSystem : MonoBehaviour
    {
        private const float IncreaseConstant = 1.02f;
        public static SavingsSystem Instance { get; private set; }

        private float _transferAmount;
        
        private float _savings;
        private int _counterOfMonths;

        public float Savings
        {
            set
            {
                if (Math.Abs(value - _savings) < 0.00001)
                    return;

                _savings = value;
                OnSavingsChanged?.Invoke(value);
            }
            
            get => _savings;
        }
        
        public delegate void OnSavingsChangedDelegate(float savings);
        public event OnSavingsChangedDelegate OnSavingsChanged;
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
            DateManager.Instance.OnMonthAdvanced += IncreaseMonthCounter;

            Savings = GameStarter.StartingSavingsAccountBalance;
        }
    
        private void OnDisable()
        {
            if (!BankAccountManager.Instance)
                return;
                
            DateManager.Instance.OnMonthAdvanced -= IncreaseMonthCounter;
        }

        private void IncreaseMonthCounter(DateTime currentDate)
        {
            _counterOfMonths++;
            
            if (_counterOfMonths >= 12)
            {
                _counterOfMonths = 0;
                IncreaseSavings();
            }
        }

        private void IncreaseSavings()
        {
            Savings *= IncreaseConstant;
        }

        private void TransferMoneyInitiation(float amount)
        {
            if (amount + _transferAmount > _savings)
                return;
            
            _transferAmount += amount;
            DateManager.Instance.OnMonthAdvanced += TransferMoneyToBankAccount;
        }

        private void TransferMoneyToBankAccount(DateTime currentDate)
        {
            Savings -= _transferAmount;
            BankAccountManager.Instance.Balance += _transferAmount;
            _transferAmount = 0;

            DateManager.Instance.OnMonthAdvanced -= TransferMoneyToBankAccount;
        }
        


    }
}
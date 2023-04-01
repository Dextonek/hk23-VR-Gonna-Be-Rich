using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game_Logic
{
    public struct Earning
    {
        public string Name { get;}
        public float Amount { get;}

        public Earning(string name, float amount)
        {
            Name = name;
            Amount = amount;
        }
    }
    
    public class EarningSystem : MonoBehaviour
    {
        public static EarningSystem Instance { get; private set; }
    
        private List<Earning> _earnings;
        public List<Earning> Earnings
        {
            set
            {
                if (value.SequenceEqual(_earnings))
                    return;
    
                _earnings = value;
                OnEarningsChanged?.Invoke(value);
            }
    
            get => _earnings;
        }
            
        public delegate void OnEarningsChangedDelegate(List<Earning> earnings);
    
        public event OnEarningsChangedDelegate OnEarningsChanged;
            
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
            DateManager.Instance.OnMonthAdvanced += GetEarnings;
        }
    
        private void OnDisable()
        {
            if (!BankAccountManager.Instance)
                return;
                
            DateManager.Instance.OnMonthAdvanced -= GetEarnings;
        }
    
        private void GetEarnings(DateTime currentDate)
        {
            foreach (var earning in Earnings)
            {
                BankAccountManager.Instance.Balance += earning.Amount;
            }
        }
    }
}

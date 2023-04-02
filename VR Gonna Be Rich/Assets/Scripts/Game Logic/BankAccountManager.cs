using System;
using UnityEngine;

namespace Game_Logic
{
    public class BankAccountManager : MonoBehaviour
    {
        private float _balance;
        
        public static BankAccountManager Instance { get; private set; }

        public float Balance
        {
            set
            {
                if(Math.Abs(value - _balance) < 0.000001f)
                    return;
                
                _balance = value;
                OnAccountBalanceChanged?.Invoke(value);
            }

            get => _balance;
        }
    
        public delegate void OnAccountBalanceChangedDelegate(float currentBalance);

        public event OnAccountBalanceChangedDelegate OnAccountBalanceChanged;
        
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game_Logic
{
    public class InvestmentsManager : MonoBehaviour
    {
        public static InvestmentsManager Instance { get; private set; }

        private const float IncreaseConstant = 1.02f;

        private float _investments;

        public float Investments
        {
            set
            {
                if(Math.Abs(value - _investments) < 0.000001f)
                    return;

                _investments = value;
                OnInvestmentsChanged?.Invoke(value);                
            }

            get => _investments;
        }
        
        public delegate void OnInvestmentsChangedDelegate(float investments);
    
        public event OnInvestmentsChangedDelegate OnInvestmentsChanged;
        
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
            DateManager.Instance.OnMonthAdvanced += EarnMoney;
        }
    
        private void OnDisable()
        {
            if (!BankAccountManager.Instance)
                return;
                
            DateManager.Instance.OnMonthAdvanced -= EarnMoney;
        }

        private void EarnMoney(DateTime currentDate)
        {
            _investments *= IncreaseConstant;
        }
    }
}

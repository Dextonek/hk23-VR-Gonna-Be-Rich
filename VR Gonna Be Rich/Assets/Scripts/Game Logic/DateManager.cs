using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game_Logic
{
    public class DateManager : MonoBehaviour
    {
        [SerializeField] private float advanceDayDelay = 0.1f;
        
        private DateTime _currentDate = new DateTime(2023, 4, 1);
        private bool _advanceTime;
        private float _advanceTimeCounter;

        public DateManager Instance { get; private set; }

        public DateTime CurrentDate
        {
            private set
            {
                if (value.CompareTo(_currentDate) == 0)
                    return;

                if (value.Month != _currentDate.Month)
                {
                    _advanceTime = false;
                    OnMonthAdvanced?.Invoke(value);
                }

                _currentDate = CurrentDate;
                OnCurrentDateChanged?.Invoke(value);
            }

            get => _currentDate;
        }

        public delegate void OnCurrentDateChangedDelegate(DateTime currentDate);

        public event OnCurrentDateChangedDelegate OnCurrentDateChanged;
        
        public delegate void OnMonthAdvancedDelegate(DateTime currentDate);

        public event OnMonthAdvancedDelegate OnMonthAdvanced;

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

        private void Update()
        {
            AdvanceTime();
        }

        private void AdvanceTime()
        {
            if (!_advanceTime)
                return;

            

            if (_advanceTimeCounter < advanceDayDelay)
            {
                _advanceTimeCounter += Time.deltaTime;
                return;
            }

            CurrentDate = CurrentDate.AddDays(1);
            
            _advanceTimeCounter = 0f;
        }

        public void OnAdvanceTimeButtonClick()
        {
            _advanceTime = true;
        }
    }
}

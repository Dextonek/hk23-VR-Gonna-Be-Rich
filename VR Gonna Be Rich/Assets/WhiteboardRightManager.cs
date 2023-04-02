using System;
using System.Globalization;
using Game_Logic;
using TMPro;
using UnityEngine;

public class WhiteboardRightManager : MonoBehaviour
{
    private DateTime _date;
    private float _balance;
    private float _saveingBalance;
    private float _investment;
    

    [SerializeField]
    private TextMeshProUGUI dateField;
    // Start is called before the first frame update
    void Start()
    {
        _date = DateTime.Today;
        dateField.text = _date.ToString(CultureInfo.CurrentCulture);
            
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

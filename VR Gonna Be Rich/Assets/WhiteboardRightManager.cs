using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WhiteboardRightManager : MonoBehaviour
{
    private DateTime _date;

    [SerializeField] private TextMeshProUGUI dateField;

    [SerializeField] private TextMeshProUGUI balanceField;

    [SerializeField] private Button nextDate;
    // Start is called before the first frame update
    void Start()
    {
        _date = DateTime.Today;
        dateField.text = _date.ToString(CultureInfo.CurrentCulture);
        balanceField.text = "650€";

    }

    // Update is called once per frame
    void Update()
    {
        if (dateField.text != _date.ToString(CultureInfo.CurrentCulture))
        {
            dateField.text = _date.ToString(CultureInfo.CurrentCulture);
        }   
    }

    public void NextDate()
    {
        _date += TimeSpan.FromDays(1);
        balanceField.text = "500€";
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class WhiteboardRightManager : MonoBehaviour
{
    private DateTime _date;

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

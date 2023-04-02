using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PiggyBankManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI piggyBankValue;
    // Start is called before the first frame update
    void Start()
    {
        piggyBankValue.text = "8000€";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

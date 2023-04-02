using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI walletMoneyValue;
    
    // Start is called before the first frame update
    void Start()
    {
        walletMoneyValue.text = "500";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

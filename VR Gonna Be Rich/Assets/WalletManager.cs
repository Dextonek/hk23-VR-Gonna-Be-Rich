using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI walletValue;
    
    // Start is called before the first frame update
    void Start()
    {
        walletValue.text = "50€";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Game_Logic;
using TMPro;
using UnityEngine;

public class WalletManager : MonoBehaviour
{
    [SerializeField] private GameObject canvasGameObject;
    [SerializeField] private TextMeshProUGUI walletValue;

    private void OnEnable()
    {
        BankAccountValueChanged(BankAccountManager.Instance.Balance);
        BankAccountManager.Instance.OnAccountBalanceChanged += BankAccountValueChanged;
        canvasGameObject.SetActive(false);
    }

    public void OnGrabbed()
    {
        canvasGameObject.SetActive(true);
    }

    public void OnDropped()
    {
        canvasGameObject.SetActive(false);
    }

    public void BankAccountValueChanged(float value)
    {
        walletValue.text = value.ToString("F2");
    }
}

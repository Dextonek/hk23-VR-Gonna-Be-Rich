using System;
using System.Collections;
using System.Collections.Generic;
using Game_Logic;
using TMPro;
using UnityEngine;

public class PiggyBankManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI savingsAmount;
    [SerializeField] private GameObject canvasGameObject;


    private void OnEnable()
    {
        SavingsChanged(SavingsSystem.Instance.Savings);
        SavingsSystem.Instance.OnSavingsChanged += SavingsChanged;
    }

    private void SavingsChanged(float value)
    {
        savingsAmount.text = value.ToString("F2");
    }

    public void OnGrabbed()
    {
        canvasGameObject.SetActive(true);
    }

    public void OnDropped()
    {
        canvasGameObject.SetActive(false);
    }
}

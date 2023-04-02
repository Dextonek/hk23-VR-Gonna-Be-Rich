using Game_Logic;
using TMPro;
using UnityEngine;

public class TabletManager : MonoBehaviour
{
    [SerializeField] private GameObject graphObject;
    [SerializeField] private GameObject canvasObject;
    [SerializeField] private TextMeshProUGUI investmentsBalanceText;

    private void OnEnable()
    {
        InvestmentsAmountChanged(InvestmentsManager.Instance.Investments);
        InvestmentsManager.Instance.OnInvestmentsChanged += InvestmentsAmountChanged;
        
        canvasObject.SetActive(false);
    }

    public void InvestmentsAmountChanged(float value)
    {
        investmentsBalanceText.text = value.ToString("F2");
    }

    public void OnGrabbed()
    {
        graphObject.SetActive(false);
        canvasObject.SetActive(true);
    }

    public void OnDropped()
    {
        graphObject.SetActive(true);
        canvasObject.SetActive(false);
    }

    public void AddMoney()
    {
        if (BankAccountManager.Instance.Balance < 100f)
            return;
        
        BankAccountManager.Instance.Balance -= 100f;
        InvestmentsManager.Instance.Investments += 100f;
    }

    public void WithdrawMoney()
    {
        InvestmentsManager.Instance.TransferMoneyInitiation(100f);
    }
}

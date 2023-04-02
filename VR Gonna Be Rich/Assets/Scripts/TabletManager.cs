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
}

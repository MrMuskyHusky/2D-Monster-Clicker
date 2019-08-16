using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [Header("Upgrade Buttons")]
    public GameObject[] perSecondUpgrade;
    public GameObject[] clickValueUpgrade;

    [Header("Upgrade Prices")]
    public int[] perSecondPrices;
    public int[] clickValuePrices;

    [Header("Upgrade Amounts")]
    public int[] perSecondValue;
    public int[] clickValueValue;

    private void Update()
    {
        for (int i = 0; i < perSecondPrices.Length; i++)
        {
            if (ScoreManager.score >= perSecondPrices[i])
            {
                perSecondUpgrade[i].SetActive(true);
            }
            else
            {
                perSecondUpgrade[i].SetActive(false);
            }
            if (ScoreManager.score >= clickValuePrices[i])
            {
                clickValueUpgrade[i].SetActive(true);
            }
            else
            {
                clickValueUpgrade[i].SetActive(false);
            }
        }
    }

    public void ClickValueUpgrade(int indexRef)
    {
        ScoreManager.score -= clickValuePrices[indexRef];
        ClickButton.clickValue += clickValueValue[indexRef];
        clickValuePrices[indexRef] += 50;
        ScoreManager.Increase();
    }
    public void PerSecondUpgrade(int indexRef)
    {
        ScoreManager.score -= perSecondPrices[indexRef];
        ClickButton.amountPerSecond += perSecondValue[indexRef];
        perSecondPrices[indexRef] += 50;
        ScoreManager.Increase();
    }
}
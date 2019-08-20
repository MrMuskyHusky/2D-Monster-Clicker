using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    [Header("Upgrade Buttons")]
    public GameObject[] perSecondUpgrade;
    public GameObject[] clickValueUpgrade;
    public GameObject[] critDamageUpgrade;
    public GameObject[] critChanceUpgrade;

    [Header("Upgrade Prices")]
    public int[] perSecondPrices;
    public int[] clickValuePrices;
    public int[] critChancePrices;
    public int[] critDamagePrices;

    [Header("Upgrade Amounts")]
    public int[] perSecondValue;
    public int[] clickValueValue;
    public int[] critChanceValue;
    public float[] critDamageValue;

    [Header("Text Elements")]
    public Text[] perSecondText;
    public Text[] clickValueText;
    public Text[] critChanceText;
    public Text[] critDamageText;


    public bool calledUpgrade = false;

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

            if (ScoreManager.score >= critChancePrices[i])
            {
                critChanceUpgrade[i].SetActive(true);
            }
            else
            {
                critChanceUpgrade[i].SetActive(false);
            }

            if (ScoreManager.score >= critDamagePrices[i])
            {
                critDamageUpgrade[i].SetActive(true);
            }
            else
            {
                critDamageUpgrade[i].SetActive(false);
            }
        }
    }

    public void ClickValueUpgrade(int indexRef)
    {
        ScoreManager.score -= clickValuePrices[indexRef];
        ClickButton.clickValue += clickValueValue[indexRef];
        clickValuePrices[indexRef] += 50;
        ScoreManager.Increase();
        calledUpgrade = true;
        clickValueText[indexRef].text = "Cost: " + clickValuePrices[indexRef];
    }

    public void PerSecondUpgrade(int indexRef)
    {
        ScoreManager.score -= perSecondPrices[indexRef];
        ClickButton.amountPerSecond += perSecondValue[indexRef];
        perSecondPrices[indexRef] += 50;
        ScoreManager.Increase();
        calledUpgrade = true;
        perSecondText[indexRef].text = "Cost: " + perSecondPrices[indexRef];
    }

    public void CritChanceUpgrade(int indexRef)
    {
        ScoreManager.score -= critChancePrices[indexRef];
        CriticalHit.critChance += critChanceValue[indexRef];
        critChancePrices[indexRef] += 50;
        ScoreManager.Increase();
        calledUpgrade = true;
        critChanceText[indexRef].text = "Cost: " + critChancePrices[indexRef];
    }

    public void CritDamageUpgrade(int indexRef)
    {
        ScoreManager.score -= critDamagePrices[indexRef];
        CriticalHit.critDamage += critDamageValue[indexRef];
        critDamagePrices[indexRef] += 50;
        ScoreManager.Increase();
        calledUpgrade = true;
        critDamageText[indexRef].text = "Cost: " + critDamagePrices[indexRef];
    }
}
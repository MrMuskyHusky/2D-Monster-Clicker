using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    private Text _currentClickDamage;
    private Text _currentDPS;
    private Text _currentCritChance;
    private Text _currentCritDamage;
    private float _critDamageHolder;
    
    public UpgradeManager upgradeManager;
    // Start is called before the first frame update
    void Start()
    {
        _currentClickDamage = GameObject.FindGameObjectWithTag("ClickDamageText").GetComponent<Text>();
        _currentDPS = GameObject.FindGameObjectWithTag("DPSText").GetComponent<Text>();
        _currentCritChance = GameObject.FindGameObjectWithTag("CritChanceText").GetComponent<Text>();
        _currentCritDamage = GameObject.FindGameObjectWithTag("CritDamageText").GetComponent<Text>();

        // upgradeManager = GameObject.FindGameObjectWithTag("UpgradeManager").GetComponent<UpgradeManager>;
    }

    // Update is called once per frame
    void Update()
    {
        if (upgradeManager.calledUpgrade)
        {
            upgradeManager.calledUpgrade = false;

            _currentClickDamage.text = "Current Click Damage: " + ClickButton.clickValue;
            _currentDPS.text = "Current DPS: " + ClickButton.amountPerSecond;
            _currentCritChance.text = "Current Crit Chance: " + CriticalHit.critChance + "%";
            _critDamageHolder = Mathf.Round(CriticalHit.critDamage * 100f) / 100f;
            _currentCritDamage.text = "Current Crit Damage: " + _critDamageHolder;
        }
    }
}

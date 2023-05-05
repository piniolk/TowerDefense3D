using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerUIMenu : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI ROFText;
    [SerializeField] private TextMeshProUGUI radiusText;
    [SerializeField] private GameObject upgradeButton;

    public void SellTower() {
        int sellPrice = gameObject.GetComponent<TowerBase>().GetTowerCost();
        sellPrice = Mathf.RoundToInt(sellPrice / 2);
        PaymentSystem.Instance.AddCoins(sellPrice);
        GridPosition gridPosition = GridMechanics.Instance.GetGridPosition(gameObject.transform.position);
        GridObject gridObject = GridMechanics.Instance.GetTower(gridPosition);
        TowerSystem.Instance.SetNullToSelectedTower();
        gridObject.RemoveTower();
    }

    public void Upgrade() {
        gameObject.GetComponent<TowerBase>().UpgradeTower();
        UpdateText(); 
    }

    public void DeleteUpgradeButton() {
        Destroy(upgradeButton);
    }

    public void UpdateText() {
        int count = 0;
        foreach (string str in gameObject.GetComponent<TowerBase>().GetTowerInfo()) {
            if (count == 0) {
                levelText.text = "Level: " + str;
            }
            if (count == 1) {
                damageText.text = "Damage: " + str;
            }
            if (count == 2) {
                ROFText.text = "ROF: " + str;
            }
            if (count == 3) {
                radiusText.text = "Radius: " + str;
            }
            count++;
        };

        costText.text = gameObject.GetComponent<TowerBase>().GetTowerCost().ToString();

        if (gameObject.GetComponent<TowerBase>().GetUpgradeInfo() != null) {
            count = 0;
            foreach (string str in gameObject.GetComponent<TowerBase>().GetUpgradeInfo()) {
                if (count == 0) {
                    levelText.text += " -> " + str;
                }
                if (count == 1) {
                    damageText.text += " -> " + str;
                }
                if (count == 2) {
                    ROFText.text += " -> " + str;
                }
                if (count == 3) {
                    radiusText.text += " -> " + str;
                }
                count++;
            }
        } else {
            costText.text = "";
        };

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUIMenu : MonoBehaviour {
    
    public void SellTower() {
        int sellPrice = gameObject.GetComponent<TowerBase>().GetTowerCost();
        sellPrice = Mathf.RoundToInt(sellPrice/2);
        PaymentSystem.Instance.AddCoins(sellPrice);
        GridPosition gridPosition = GridMechanics.Instance.GetGridPosition(gameObject.transform.position);
        GridObject gridObject = GridMechanics.Instance.GetTower(gridPosition);
        gridObject.RemoveTower();
    }

    public void Upgrade() {
        foreach (string str in gameObject.GetComponent<TowerBase>().GetTowerInfo()) {
            Debug.Log("Current: " + str);
        };
        gameObject.GetComponent<TowerBase>().UpgradeTower();
        foreach (string str in gameObject.GetComponent<TowerBase>().GetTowerInfo()) {
            Debug.Log("Upgraded: " + str); 
        };
    }
}

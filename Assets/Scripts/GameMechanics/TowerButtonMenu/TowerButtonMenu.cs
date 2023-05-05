using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerButtonMenu : MonoBehaviour {
    [SerializeField] private Transform towerButtonsContainer;
    [SerializeField] private Button buttonTower;

    private void Awake() {
        CreateTowerButtons();
    }

    private void CreateTowerButtons() {
        // destroy buttons in the container
        foreach (Transform btn in towerButtonsContainer) {
            Destroy(btn.gameObject);
        }

        // create new buttons
        TowerObject[] towerList = TowerSystem.Instance.GetTowerObjectList();
        foreach (TowerObject tower in towerList) {
            Button actionButton = Instantiate(buttonTower, towerButtonsContainer); 
            TextMeshProUGUI buttonText = actionButton.GetComponentInChildren<TextMeshProUGUI>();
            GameObject towerObj = tower.towerModel.gameObject;
            buttonText.text = towerObj.GetComponent<TowerBase>().GetTowerName();
            Debug.Log(towerObj.GetComponent<TowerBase>().GetTowerName());
            actionButton.onClick.AddListener(() => {
                UISelect.Instance.SetTowerPrefab(tower.towerModel);
                UISelect.Instance.SetTowerPlacingPrefab(tower.towerPlacingModel);
                UISelect.Instance.TowerButtonClick();
            });
        }
    }
}

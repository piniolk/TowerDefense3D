using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerButtonMenu : MonoBehaviour {
    [SerializeField] private TowerObject[] towerObjectsList;
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
        foreach (TowerObject tower in towerObjectsList) {
            Button actionButton = Instantiate(buttonTower, towerButtonsContainer);
            TextMeshProUGUI buttonText = actionButton.GetComponentInChildren<TextMeshProUGUI>();
            GameObject towerObj = tower.towerModel.gameObject;
            buttonText.text = towerObj.GetComponent<TowerBase>().GetTowerName();

            buttonTower.onClick.AddListener(OnClick);
        }
    }

    private void OnClick() {
        Debug.Log("In Listener 1");
        //UISelect.Instance.TowerButtonClick();
        //Debug.Log("In Listener 2");
    }
}

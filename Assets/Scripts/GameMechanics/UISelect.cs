using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UISelect : MonoBehaviour {

    public static UISelect Instance { get; private set; }
    [SerializeField] private LayerMask placeableLayerMask;
    [SerializeField] private GameObject testTowerBasePrefab;
    [SerializeField] private GameObject testTowerPlacingPrefab;
    private GameObject placingTower;
    private bool isCurrentlyPlacingTower;
    private PlayerControlActions playerControlActions;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        playerControlActions = new PlayerControlActions();
        playerControlActions.Mouse.Enable();
    }

    private void Update() {
        PlaceTower();
    }

    public void TowerButtonClick() {
        //NOTE: still places tower if you click button over plane
        //refactor later
        if ((float)PaymentSystem.Instance.GetCoins() > TowerSystem.Instance.GetTowerType().GetComponent<TowerBase>().GetTowerCost()) {
            if (isCurrentlyPlacingTower) {
                //button was pressed and want to cancel
                isCurrentlyPlacingTower = false;
                Destroy(placingTower);
                placingTower = null;
            } else {
                //button has not been pressed yet
                NewTower();
            }
        }
    }

    public void GeneralTowerButtonClick() {
        //refactor later
        if ((float)PaymentSystem.Instance.GetCoins() > TowerSystem.Instance.GetTowerType().GetComponent<TowerBase>().GetTowerCost()) {
            if (isCurrentlyPlacingTower) {
                //button was pressed and want to cancel
                isCurrentlyPlacingTower = false;
                Destroy(placingTower);
                placingTower = null;
            } else {
                //button has not been pressed yet
                NewTower();
            }
        }
    }

    private void NewTower() {
        Vector3 mousePosition = MousePosition.Instance.GetWorldPosition();
        //mousePosition.y += 1;
        placingTower = Instantiate(testTowerPlacingPrefab, mousePosition, Quaternion.identity) as GameObject;
        isCurrentlyPlacingTower = true;
    }

    // TOWER IS PLACING INSIDE OF BG TOWER, FIX

    private void PlaceTower() {
        if (isCurrentlyPlacingTower) {
            if (MousePosition.Instance.TryGetWorldPosition()) {
                Vector3 mousePosition = MousePosition.Instance.GetWorldPosition();
                GridPosition gridPos = GridMechanics.Instance.GetGridPosition(mousePosition);
                Vector3 worldPos = GridMechanics.Instance.GetWorldPosition(gridPos);
                //worldPos.y += 1;
                placingTower.transform.position = worldPos;
                if (playerControlActions.Mouse.Click.WasPressedThisFrame()) {
                    if (!EventSystem.current.IsPointerOverGameObject()) {
                        if (GridMechanics.Instance.CheckIfInGrid(gridPos)) {
                            if (GridMechanics.Instance.CheckIfPlaceable(gridPos) && GridMechanics.Instance.CheckIfFillable(gridPos)) {
                                Destroy(placingTower);
                                placingTower = Instantiate(testTowerBasePrefab, worldPos, Quaternion.identity) as GameObject;
                                GridMechanics.Instance.PlaceTower(gridPos, placingTower);
                                isCurrentlyPlacingTower = false;
                                PaymentSystem.Instance.BuyTower(GridMechanics.Instance.GetTower(gridPos).GetTower().GetComponent<TowerBase>().GetTowerCost());
                                GridMechanics.Instance.GetTower(gridPos).GetTower().GetComponent<TowerBase>().ChangeTowerCost();
                                GridMechanics.Instance.GetTower(gridPos).GetTower().GetComponent<TowerUIMenu>().UpdateText();
                                TowerSystem.Instance.HandleUISelect(GridMechanics.Instance.GetTower(gridPos));
                            }
                        }
                    }
                }
            }
        }
    }

    public bool GetIfCurrentlyPlacingTower() {
        return this.isCurrentlyPlacingTower;
    }
}

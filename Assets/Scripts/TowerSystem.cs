using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerSystem : MonoBehaviour {

    public static TowerSystem Instance { get; private set; }
    [SerializeField] private LayerMask towerLayerMask;
    [SerializeField] private GameObject towerTypes;
    private PlayerControlActions playerControlActions;
    private float timer;
    private GridObject selectedGridObject;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        playerControlActions = new PlayerControlActions();
        playerControlActions.Mouse.Enable();
        timer = 0f;
    }

    private void Update() {
        if (timer > 0f) {
            timer -= Time.deltaTime;
        } else {
            ClickTower();
        }
        if (UISelect.Instance.GetIfCurrentlyPlacingTower()) {
            timer = .5f;
        }
    }

    private void ClickTower() {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, towerLayerMask)) {
            if (playerControlActions.Mouse.Click.WasPressedThisFrame()) {
                GameObject towerClicked = raycastHit.transform.gameObject;
                Vector3 towerClickedPos = towerClicked.GetComponent<Transform>().position;
                towerClickedPos.y -= 1;
                GridPosition gridPos = GridMechanics.Instance.GetGridPosition(towerClickedPos);
                GridObject gridObject = GridMechanics.Instance.GetTower(gridPos);

                if (selectedGridObject == gridObject) {
                    // hide current one
                       // empty selected obj to current
                    selectedGridObject = null;
                } else if (selectedGridObject != null) {
                    // show and one already on
                      //handle info of old
                      // update selected obj to current
                    selectedGridObject.HandleTowerInfo();
                    selectedGridObject = gridObject;
                } else {
                    // show and none on
                       // update selected obj to current
                    selectedGridObject = gridObject;
                }
                gridObject.GetTower().GetComponent<TowerBase>().ChangeTowerCost();
                gridObject.HandleTowerInfo();
            }
        }
    }

    public GameObject GetTowerType() {
        return this.towerTypes;
    }
}

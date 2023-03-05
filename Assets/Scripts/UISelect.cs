using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UISelect : MonoBehaviour {

    public static UISelect Instance { get; private set; }
    [SerializeField] private GameObject testTowerBasePrefab;
    [SerializeField] private GameObject testTower;
    private GameObject placingTower;
    private bool isCurrentlyPlacingTower;
    private PlayerControlActions playerControlActions;

    private void Start() {
        playerControlActions = new PlayerControlActions();
        playerControlActions.Mouse.Enable();
    }

    private void Update() {
        PlaceTower();
    }

    public void NewTower() {
        Vector3 mousePosition = MousePosition.Instance.GetWorldPosition();
        mousePosition.y = 1;
        placingTower = Instantiate(testTowerBasePrefab, mousePosition, Quaternion.identity) as GameObject;
        isCurrentlyPlacingTower = true;
    }

    private void PlaceTower() {
        if (isCurrentlyPlacingTower) {
            if (MousePosition.Instance.TryGetWorldPosition()) {
                Vector3 mousePosition = MousePosition.Instance.GetWorldPosition();
                mousePosition.y = 1;
                placingTower.transform.position = mousePosition;
                if (playerControlActions.Mouse.Click.WasPressedThisFrame()) {
                    isCurrentlyPlacingTower = false;
                }
            }
        }
    }
}
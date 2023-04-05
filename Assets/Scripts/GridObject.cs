using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject {

    private GridSystem gridSystem;
    private bool isFilled;
    private bool isPlaceable;
    private GridPosition gridPosition;
    private GameObject tower;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition) {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        this.isFilled = false;
        this.isPlaceable = true;
    }

    public bool GetIsPlaceable() {
        return isPlaceable;
    }

    public void SetIsPlaceable() {
        this.isPlaceable = true;
    }

    public bool GetIsFilled() {
        return isFilled;
    }

    public bool SetTower(GameObject tower) {
        if (!this.isFilled && isPlaceable) {
            this.isFilled = true;
            this.tower = tower;
            Debug.Log("true");
            return true;
        }
        Debug.Log("false");
        return false;
    }

    public void RemoveTower() {
        this.isFilled = false;
        GameObject.Destroy(this.tower);
        this.tower = null;
    }

    public GameObject GetTower() {
        return this.tower;
    }

    public void HandleTowerInfo() {
        this.tower.GetComponent<TowerBase>().HandleTowerInfo();
    }
}

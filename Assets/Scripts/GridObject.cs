using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject {

    private GridSystem gridSystem;
    private bool isFilled;
    private bool isPlaceable;
    private GridPosition gridPosition;
    //private Tower tower;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition) {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        this.isFilled = false;
        this.isPlaceable = false;
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

    public bool SetTower() {
        if (!this.isFilled && isPlaceable) {
            this.isFilled = true;
            return true;
        }
        return false;
    }

    public void RemoveTower() {
        this.isFilled = false;
    }

    //public Tower GetTower(){}
}

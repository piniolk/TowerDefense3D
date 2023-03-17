using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMechanics : MonoBehaviour {

    public static GridMechanics Instance { get; private set; }
    private GridSystem gridSystem;

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("There's more than one GridMechanics! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        gridSystem = new GridSystem();
    }

    private void Start() {
        Instance = this;
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition) {
        return gridSystem.GetWorldPosition(gridPosition);
    }

    public Vector3 GetWorldPosition(int x, int y, int z) {
        return gridSystem.GetWorldPosition(x, y, z);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) {
        int x = Mathf.RoundToInt(worldPosition.x / gridSystem.GetCellSize());
        int y = Mathf.RoundToInt(worldPosition.y / gridSystem.GetCellSize());
        int z = Mathf.RoundToInt(worldPosition.z / gridSystem.GetCellSize());

        //Debug.Log("2: " + new GridPosition(x, y, z));
        return new GridPosition(x, y, z);
    }

    public void PlaceTower(GridPosition gridPosition, GameObject tower) {
        gridSystem.PlaceTower(gridPosition, tower);
    }

    public bool CheckIfPlaceable(GridPosition gridPosition) {
        return gridSystem.CheckIfPlaceable(gridPosition);
    }

    public bool CheckIfPlaceable(Vector3 worldPosition) {
        return gridSystem.CheckIfPlaceable(worldPosition);
    }

    public bool CheckIfFillable(GridPosition gridPosition) {
        return gridSystem.CheckIfFillable(gridPosition);
    }

    public bool CheckIfFillable(Vector3 worldPosition) {
        return gridSystem.CheckIfFillable(worldPosition);
    }

    public bool CheckIfInGrid(Vector3 worldPos) {
        return gridSystem.CheckIfInGrid(worldPos);
    }

    public bool CheckIfInGrid(GridPosition gridPos) {
        return gridSystem.CheckIfInGrid(gridPos);
    }

    public GridObject GetTower(GridPosition gridPosition) {
        return gridSystem.GetTower(gridPosition);
    }

    public int GetWidth() {
        return gridSystem.GetWidth();
    }

    public int GetHeight() {
        return gridSystem.GetHeight();
    }

    public int GetLength() {
        return gridSystem.GetLength();
    }
}

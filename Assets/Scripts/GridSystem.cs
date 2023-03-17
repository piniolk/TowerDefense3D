using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem {

    private int width = 15;
    private int length = 15;
    private int height = 2;
    private int cellSize = 2;
    private GridObject[,,] gridObjectArray;

    public GridSystem() {
        gridObjectArray = new GridObject[width, height, length];
        for (int x = 0; x < width; x++) {
            for (int z = 0; z < length; z++) {
                for (int y = 0; y < height; y++) {
                    Debug.DrawLine(GetWorldPosition(x, y, z), GetWorldPosition(x, y, z) + Vector3.right * .2f, Color.white, 1000);
                    GridPosition gridPos = new GridPosition(x, y, z);
                    gridObjectArray[x, y, z] = new GridObject(this, gridPos);
                }
            }
        }
    }

    public GridSystem(int width, int height, int length) {
        gridObjectArray = new GridObject[width, height, length];
        for (int x = 0; x < width; x++) {
            for (int z = 0; z < length; z++) {
                for (int y = 0; y < height; y++) {
                    Debug.DrawLine(GetWorldPosition(x, y, z), GetWorldPosition(x, y, z) + Vector3.right * .2f, Color.white, 1000);
                    GridPosition gridPos = new GridPosition(x, y, z);
                    gridObjectArray[x, y, z] = new GridObject(this, gridPos);
                }
            }
        }

    }

    public int GetCellSize() {
        return cellSize;
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition) {
        return new Vector3(gridPosition.x * cellSize, gridPosition.y * cellSize, gridPosition.z * cellSize);
    }

    public Vector3 GetWorldPosition(int x, int y, int z) {
        return new Vector3(x * cellSize, y * cellSize, z * cellSize);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) {
        int x = Mathf.RoundToInt(worldPosition.x / cellSize);
        int y = Mathf.RoundToInt(worldPosition.y / cellSize);
        int z = Mathf.RoundToInt(worldPosition.z / cellSize);

        //Debug.Log("2: " + new GridPosition(x, y, z));
        return new GridPosition(x, y, z);
    }

    public void PlaceTower(GridPosition gridPosition, GameObject tower) {
        gridObjectArray[gridPosition.x, gridPosition.y, gridPosition.z].SetTower(tower);
    }

    public bool CheckIfPlaceable(GridPosition gridPosition) {
        return gridObjectArray[gridPosition.x, gridPosition.y, gridPosition.z].GetIsPlaceable();
    }

    public bool CheckIfPlaceable(Vector3 worldPosition) {
        GridPosition gridPosition = GetGridPosition(worldPosition);
        return gridObjectArray[gridPosition.x, gridPosition.y, gridPosition.z].GetIsPlaceable();
    }

    public bool CheckIfFillable(GridPosition gridPosition) {
        return !gridObjectArray[gridPosition.x, gridPosition.y, gridPosition.z].GetIsFilled();
    }

    public bool CheckIfFillable(Vector3 worldPosition) {
        GridPosition gridPosition = GetGridPosition(worldPosition);
        return !gridObjectArray[gridPosition.x, gridPosition.y, gridPosition.z].GetIsFilled();
    }

    public GridObject GetTower(GridPosition gridPosition) {
        return gridObjectArray[gridPosition.x, gridPosition.y, gridPosition.z];
    }

    public int GetWidth() {
        return this.width;
    }

    public int GetHeight() {
        return this.height;
    }

    public int GetLength() {
        return this.length;
    }
}
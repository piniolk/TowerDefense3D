using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem {
    private int width = 15;
    private int length = 15;
    private int height = 1;
    private int cellSize = 2;
    private GridObject[,,] gridObjectArray;


    public GridSystem() {
        gridObjectArray = new GridObject[width, height, length];
        for (int x = 0; x < width; x++) {
            for (int z = 0; z < length; z++) {
                for (int y = 0; y < height; y++) {
                    Debug.DrawLine(GetWorldPosition(x, y, z), GetWorldPosition(x, y, z) + Vector3.right * .2f, Color.white, 1000);
                    GridPosition gridPos = new GridPosition(x, y, z);
                    gridObjectArray[x,y,z] = new GridObject(this, gridPos);
                }
            }
        }

    }

    public Vector3 GetWorldPosition(int x, int y, int z) {
        return new Vector3(x * cellSize, y * cellSize, z * cellSize);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) {
        int x = Mathf.RoundToInt(worldPosition.x / cellSize);
        int y = Mathf.RoundToInt(worldPosition.y / cellSize);
        int z = Mathf.RoundToInt(worldPosition.z / cellSize);

        return new GridPosition(x, y, z);
    }

    public void PlaceTower(GridPosition gridposition) {
        if (gridObjectArray[gridposition.x, gridposition.y, gridposition.z].GetIsPlaceable()) {
            //check size if all for GetIsFilled and on the x if is placeable
            //if so place tower and fill in 
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    
    public static LevelManager Instance { get; private set; }
    private List<GridPosition> enemyTravelPath;

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("There's more than one LevelManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //get enemy travel path
        enemyTravelPath = new List<GridPosition>{ new GridPosition(0, 0, 0), 
                                                  new GridPosition(3, 0, 0), 
                                                  new  GridPosition(3, 0, 4), 
                                                  new GridPosition(14, 0, 10)};
    }

    public List<GridPosition> GetEnemyTravelPath() {
        return enemyTravelPath;
    }
}

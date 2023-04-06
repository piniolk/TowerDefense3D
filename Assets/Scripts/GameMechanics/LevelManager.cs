using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    
    public static LevelManager Instance { get; private set; }
    //private List<GridPosition> enemyTravelPath;

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("There's more than one LevelManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //get enemy travel path
        //enemyTravelPath = ;
    }

    public List<GridPosition> GetEnemyTravelPath() {
        return new List<GridPosition>{ new GridPosition(0, 0, 0),
                                                  new GridPosition(2, 0, 0),
                                                  new GridPosition(2, 0, 4),
                                                  new GridPosition(4, 0, 4),
                                                  new GridPosition(5, 1, 4),
                                                  new GridPosition(6, 1, 4),
                                                  new GridPosition(6, 1, 2),
                                                  new GridPosition(10, 1, 2),
                                                  new GridPosition(10, 1, 7),
                                                  new GridPosition(13, 1, 7),
                                                  new GridPosition(13, 1, 9),
                                                  new GridPosition(13, 2, 10),
                                                  new GridPosition(13, 2, 12),
                                                  new GridPosition(15, 2, 12),
                                                  new GridPosition(15, 2, 15),
                                                  new GridPosition(11, 2, 15),
                                                  new GridPosition(11, 2, 13),
                                                  new GridPosition(10, 3, 13),
                                                  new GridPosition(8, 3, 13),
                                                  new GridPosition(8, 3, 15),
                                                  new GridPosition(2, 3, 15),
                                                  new GridPosition(2, 5, 13),
                                                  new GridPosition(2, 5, 12),
                                                  new GridPosition(0, 5, 12),
                                                  new GridPosition(0, 5, 10),
                                                  new GridPosition(3, 5, 10),
                                                  new GridPosition(3, 5, 12),
                                                  new GridPosition(6, 5, 12),
                                                  new GridPosition(6, 5, 10),
                                                  new GridPosition(6, 6, 9),
                                                  new GridPosition(6, 6, 1),
                                                  new GridPosition(8, 6, 1),
                                                  new GridPosition(8, 6, 8),
                                                  new GridPosition(13, 6, 8),
                                                  new GridPosition(13, 6, 6),
                                                  new GridPosition(10, 6, 6),
                                                  new GridPosition(10, 6, 4),
                                                  new GridPosition(13, 6, 4),
                                                  new GridPosition(13, 6, 1)};
    }
}

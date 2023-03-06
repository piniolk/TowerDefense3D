using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackRangeCollider : MonoBehaviour {

    private List<GameObject> enemiesInRange;
    private int length;

    private void Start() {
        enemiesInRange = new List<GameObject>();
        length = 0;
    }

    private void OnTriggerEnter(Collider other) {
        if (!enemiesInRange.Contains(other.gameObject)) {
            enemiesInRange.Add(other.gameObject);
            length++;
        }
    }

    private void OnTriggerExit(Collider other) {
        enemiesInRange.Remove(other.gameObject);
        length--;
    }

    public List<GameObject> GetEnemiesInRange() {
        return this.enemiesInRange;
    }

    public int GetLength() {
        return this.length;
    }
}

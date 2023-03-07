using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackRangeCollider : MonoBehaviour {


    private List<GameObject> enemiesInRange;
    private int length;

    private void Start() {
        enemiesInRange = new List<GameObject>();
        length = 0;
        EnemyManager.Instance.onEnemyDeath += EnemyManager_OnEnemyDeath;
    }

    private void OnTriggerEnter(Collider other) {
        if (!enemiesInRange.Contains(other.gameObject)) {
            enemiesInRange.Add(other.gameObject);
            length++;
            //Debug.Log(length);
        }
    }

    private void OnTriggerExit(Collider other) {
        enemiesInRange.Remove(other.gameObject);
        length--;
        //Debug.Log(length);
    }

    public List<GameObject> GetEnemiesInRange() {
        return this.enemiesInRange;
    }

    public GameObject GetClosestEnemy() {
        GameObject closestEnemy = enemiesInRange[0];
        Vector3 towerPos = transform.position;
        float closestEnemyRange;// = Mathf.Abs(Vector3.Distance(towerPos, closestEnemy.transform.position));
        foreach (GameObject enemy in enemiesInRange) {
            if (enemy == null) {
                enemiesInRange.Remove(enemy);
                length--;
                return null;
            }
            float enemyRange = Mathf.Abs(Vector3.Distance(towerPos, enemy.transform.position));
            if (closestEnemy == null) {
                closestEnemyRange = enemyRange;
                closestEnemy = enemy;
            } else {
                closestEnemyRange = Mathf.Abs(Vector3.Distance(towerPos, closestEnemy.transform.position));
                if (enemyRange < closestEnemyRange) {
                    closestEnemyRange = enemyRange;
                    closestEnemy = enemy;
                }
            }
        }
        return closestEnemy;
    }

    public int GetLength() {
        return this.length;
    }

    private void EnemyManager_OnEnemyDeath(object sender, EventArgs e) {
        GetEnemiesInRange();
    }
}

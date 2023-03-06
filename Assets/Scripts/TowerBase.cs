using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour {

    private GridPosition gridPosition;
    //private int height = 1;
    //private int health = 100;
    private int damage = 20;
    private int towerCost = 100;
    private float rateOfFire = 5f;
    private float timer;
    private bool canFire = false;
    [SerializeField] private GameObject attackRadius;
    [SerializeField] GameObject towerInfoUI;

    private void Start() {
        timer = rateOfFire;
    }

    private void Update() {
        if (canFire) {
            AttackClosestEnemy();
        } else {
            timer -= Time.deltaTime;
        }
        if (timer <= 0) {
            canFire = true;
        }
    }

    public int GetDamageDealt() {
        return this.damage;
    }

    public void HandleTowerInfo() {
        towerInfoUI.SetActive(!towerInfoUI.activeSelf);
        attackRadius.GetComponent<MeshRenderer>().enabled = !attackRadius.GetComponent<MeshRenderer>().enabled;
    }

    public int GetTowerCost() {
        return this.towerCost;
    }

    private void AttackClosestEnemy() {
        TowerAttackRangeCollider attackRange = attackRadius.GetComponent<TowerAttackRangeCollider>();
        List<GameObject> enemiesInRange = attackRange.GetEnemiesInRange();
        if (attackRange.GetLength() == 0) {

        } else {
            //find closest enemy
            GameObject closestEnemy = enemiesInRange[0];
            Vector3 towerPos = transform.position;
            float closestEnemyRange = Mathf.Abs(Vector3.Distance(towerPos, closestEnemy.transform.position));
            foreach (GameObject enemy in enemiesInRange) {
                float enemyRange = Mathf.Abs(Vector3.Distance(towerPos, enemy.transform.position));
                if (enemyRange < closestEnemyRange) {
                    closestEnemyRange = enemyRange;
                    closestEnemy = enemy;
                }
            }

            //attack enemy
            timer = rateOfFire;
            canFire = false;
        }
    }
}

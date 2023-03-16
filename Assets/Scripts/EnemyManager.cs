using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    private int enemiesAlive;
    private int enemiesTotal;

    private float timer;

    public event EventHandler onEnemyDeath;
    [SerializeField] private GameObject enemyType;

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("There's more than one EnemyManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start() {
        timer = 0f; ;
        enemiesAlive = 0;
        enemiesTotal = 0;
    }

    private void Update() {
        if (timer >= 2f) {
            SpawnNewEnemy();
            timer = 0f;
        }
        timer += Time.deltaTime;
    }

    public void EnemyDeath() {
        onEnemyDeath?.Invoke(this, EventArgs.Empty);
        enemiesAlive--;
    }

    private void SpawnNewEnemy() {
        GameObject ob = Instantiate(enemyType, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        enemiesAlive++;
        ob.name = "Enemy_" + enemiesTotal.ToString();
        enemiesTotal++;
    }
}

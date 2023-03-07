using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    private int enemiesAlive;

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

    public void EnemyDeath() {
        onEnemyDeath?.Invoke(this, EventArgs.Empty);
        enemiesAlive--;
    }
}

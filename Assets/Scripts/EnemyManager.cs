using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public static EnemyManager Instance { get; private set; }

    private int enemiesAlive;
    private int enemiesTotal;
    private int enemiesTypeTotal;
    private int enemyTypeNum;
    private int waveNum;
    private int waveMaxNum;
    private int maxNumPerWave;
    private int maxTypeNumPerWave;

    private float timer;
    private float waveTimer;
    private float waveBuff;

    public event EventHandler onEnemyDeath;
    [SerializeField] private GameObject[] enemyType;

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("There's more than one EnemyManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start() {
        this.waveBuff = 7f;
        this.timer = 0f; ;
        this.waveTimer = this.waveBuff;
        this.enemiesAlive = 0;
        this.enemyTypeNum = 0;
        this.enemiesTotal = 0;
        this.enemiesTypeTotal = 0;
        this.waveNum = 0;
        this.waveMaxNum = 5;
        this.maxNumPerWave = 30;
        this.maxTypeNumPerWave = 10;
    }

    private void Update() {
        if (waveTimer >= waveBuff) {
            SpawnNewWave();
        }

        if (this.enemiesTypeTotal < this.maxTypeNumPerWave) {
            if (this.timer >= 2f) {
                SpawnNewEnemy();
                this.timer = 0f;
            }
            this.timer += Time.deltaTime;
        } else if(this.enemiesTotal < this.maxNumPerWave) {
            this.enemyTypeNum++;
            if (this.enemyTypeNum == this.enemyType.Length) {
                this.enemyTypeNum = 0;
            }
            this.enemiesTypeTotal = 0;
        } else {
            this.waveTimer += Time.deltaTime;
        }
    }

    public void EnemyDeath() {
        onEnemyDeath?.Invoke(this, EventArgs.Empty);
        this.enemiesAlive--;
    }

    private void SpawnNewEnemy() {
        GameObject ob = Instantiate(this.enemyType[this.enemyTypeNum], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        this.enemiesAlive++;
        ob.name = "Enemy_" + this.enemiesTotal.ToString();
        this.enemiesTotal++;
        this.enemiesTypeTotal++;
    }

    private void SpawnNewWave() {
        this.enemiesTotal = 0;
        this.maxNumPerWave += 10;
        this.waveNum++;
        this.waveTimer = 0f;
    }
}

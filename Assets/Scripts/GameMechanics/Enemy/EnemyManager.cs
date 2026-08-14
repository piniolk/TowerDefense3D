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
        this.waveBuff = EnemySpawningManager.Instance.waveBuff; //change
        this.timer = 0f;
        this.waveTimer = this.waveBuff;
        this.enemiesAlive = 0;
        this.enemyTypeNum = 0;
        this.enemiesTotal = 0;
        this.enemiesTypeTotal = 0;
        this.waveNum = 0;
        this.waveMaxNum = EnemySpawningManager.Instance.waveMaxNum; //change
        this.maxNumPerWave = EnemySpawningManager.Instance.maxNumPerWave; //change
        this.maxTypeNumPerWave = EnemySpawningManager.Instance.maxTypeNumPerWave; //change
    }


    private void Update() {
        if (this.waveTimer >= this.waveBuff) {
            if (this.waveNum >= this.waveMaxNum) {
                if (this.enemiesAlive <= 0) {
                    WinLossSystem.Instance.WinGame();
                }
            } else {
                SpawnNewWave();
            }
        }
        if (waveNum <= waveMaxNum) {
            if (this.enemiesTypeTotal < this.maxTypeNumPerWave) {
                if (this.timer >= EnemySpawningManager.Instance.timer) { //change
                    SpawnNewEnemy();
                    this.timer = 0f;
                }
                this.timer += Time.deltaTime;
            } else if (this.enemiesTotal < this.maxNumPerWave) {
                this.enemyTypeNum++;
                if (this.enemyTypeNum == this.enemyType.Length) {
                    this.enemyTypeNum = 0;
                }
                this.enemiesTypeTotal = 0;
            } else if (this.enemiesTotal > this.maxNumPerWave) {
                this.waveTimer = this.waveBuff;
            } else {
                this.waveTimer += Time.deltaTime;
            }
        } 
    }

    public void EnemyDeath() {
        onEnemyDeath?.Invoke(this, EventArgs.Empty);
        this.enemiesAlive--;
    }

    private void SpawnNewEnemy() {
        GameObject ob = Instantiate(this.enemyType[this.enemyTypeNum], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;  //change
        this.enemiesAlive++;
        ob.name = "Enemy_" + this.enemiesTotal.ToString();
        this.enemiesTotal++;
        this.enemiesTypeTotal++;
    }

    private void SpawnNewWave() {
        this.enemiesTotal = 0;
        //this.maxNumPerWave += EnemySpawningManager.Instance.maxNumPerWaveAdjust; //change
        this.waveNum++;
        this.waveTimer = 0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningManager : MonoBehaviour {
    public static EnemySpawningManager Instance { get; private set; }
    public float waveBuff;
    public float timer;
    public int waveMaxNum;
    public int maxNumPerWave;
    public int maxNumPerWaveAdjust;
    public int maxTypeNumPerWave;


    private void Awake() {
        if (Instance != null) {
            Debug.LogError("There's more than one EnemySpawningManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        this.waveBuff = 7f;
        this.timer = 2f;
        this.waveMaxNum = 1;
        this.maxNumPerWave = 30;
        this.maxNumPerWaveAdjust = 10;
        this.maxTypeNumPerWave = 10;
    }
}

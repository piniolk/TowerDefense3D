using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour {

    private GridPosition gridPosition;
    private int height = 1;
    private int health = 100;
    private int damage = 20;
    private float rateOfFire = 5f;
    private float timer = 0f;
    private bool canFire = true;

    private void Update() {
        if (canFire) {

        }

        timer += Time.deltaTime;
    }

    public int GetDamageDealt() {
        return damage;
    }
}

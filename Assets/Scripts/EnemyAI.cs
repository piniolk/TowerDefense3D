using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour {

    private int health;
    private int __maxHealth__;
    private float speed;
    private float coinsDropped;
    [SerializeField] private Slider healthBar;

    private void Start() {
        __maxHealth__ = 100;
        health = __maxHealth__;
        speed = 5f;
        coinsDropped = 10f;
    }

    public void DamageTaken() {
        health -= 25;
        if(health <= 0) {
            health = 0;
            PaymentSystem.Instance.AddCoins(coinsDropped);
            Destroy(gameObject);
        }
        float healthValue = (float)health / (float)__maxHealth__;
        healthBar.value = healthValue;
    }
}

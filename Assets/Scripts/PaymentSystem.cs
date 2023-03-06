using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaymentSystem : MonoBehaviour {

    public static PaymentSystem Instance { get; private set; }
    private int __maxCoinAllowance__ = 99999;
    private float coins;
    private float coinMultiplier;
    [SerializeField] private TextMeshProUGUI coinText;
    private int coinCost = 100; // refactor later

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        this.coins = 0;
        this.coinMultiplier = 10f;
    }

    private void Update() {
        if (coins < __maxCoinAllowance__) {
            this.coins += 5 * this.coinMultiplier * Time.deltaTime;
            this.coinText.text = this.coins.ToString("#.0");
        }
    }

    public float GetCoins() {
        return this.coins;
    }

    public void BuyTower() {
        this.coins -= this.coinCost;
        this.coinText.text = this.coins.ToString("#.0");
    }

    public void AddCoins(float coins) {
        if (this.coins + coins > this.__maxCoinAllowance__) {
            this.coins = this.__maxCoinAllowance__;
        } else {
            this.coins += coins;
        }
    }
}

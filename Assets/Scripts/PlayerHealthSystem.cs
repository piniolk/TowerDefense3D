using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthSystem : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI healthText;
    public static PlayerHealthSystem Instance;
    private int health;

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("There's more than one PlayerHealthSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start() {
        health = 100;
    }

    public void ReachedByEnemy() {
        health--;
        UpdateHealth();
    }

    private void UpdateHealth() {
        healthText.text = "Health: " + health.ToString();
    }
}

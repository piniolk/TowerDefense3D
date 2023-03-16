using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour {

    private int health;
    private int __maxHealth__;
    private bool canMove;
    private float speed;
    private float coinsDropped;
    private GridPosition fromPosition;
    private GridPosition toPosition;
    private List<GridPosition> movementPath;
    [SerializeField] private Slider healthBar;

    private void Start() {
        canMove = true;
        __maxHealth__ = 100;
        health = __maxHealth__;
        speed = 2f;
        this.coinsDropped = 10f;
        this.movementPath = LevelManager.Instance.GetEnemyTravelPath();
        GetInitialEnemyMovement();
    }

    private void Update() {
        /*if (GridMechanics.Instance.GetGridPosition(transform.position).x == GridMechanics.Instance.GetWidth() - 1) {
            return;
        }*/
        if (CheckIfAtGridPosition()) {
            canMove = false;
            GetEnemyMovement();
            transform.rotation = Quaternion.LookRotation((GridMechanics.Instance.GetWorldPosition(this.toPosition) - transform.position).normalized);
            canMove = true;
        } 
        if(canMove){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    /*
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("End")) {
            
        }
    }*/

    private void Death() {
        EnemyManager.Instance.EnemyDeath();
        Destroy(gameObject);
    }

    public void DamageTaken() {
        health -= 25;
        if (health <= 0) {
            health = 0;
            PaymentSystem.Instance.AddCoins(coinsDropped);
            Death();
        }
        float healthValue = (float)health / (float)__maxHealth__;
        healthBar.value = healthValue;
    }

    public bool CheckIfAtGridPosition() {
        float overBlub = .1f;
        Vector3 targetPos = GridMechanics.Instance.GetWorldPosition(this.toPosition);
        if (Mathf.Abs(transform.position.x - targetPos.x) < overBlub &&
            Mathf.Abs(transform.position.z - targetPos.z) < overBlub) {
            if (Mathf.Abs(transform.position.y - targetPos.y) < .6f) {
                return true;
            }
        }
        return false;
    }

    public void GetInitialEnemyMovement() {
        int check = 0;
        foreach (GridPosition gridPos in movementPath) {
            if (check == 0) {
                this.toPosition = gridPos;
            }
            check++;
        }
        movementPath.RemoveAt(0);
    }

    public void GetEnemyMovement() {
        int check = 0;
        foreach (GridPosition gridPos in movementPath) {
            if (check == 0) {
                this.fromPosition = this.toPosition;
                this.toPosition = gridPos;
            }
            check++;
        }
        if (movementPath.Count == 0) {
            PlayerHealthSystem.Instance.ReachedByEnemy();
            Death();
        } else {
            movementPath.RemoveAt(0);
        }
    }
}

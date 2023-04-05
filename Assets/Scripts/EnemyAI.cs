using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour {

    protected int health;
    [SerializeField] protected int __maxHealth__;
    protected bool canMove;
    [SerializeField] protected float speed;
    [SerializeField] protected float coinsDropped;
    protected GridPosition fromPosition;
    protected GridPosition toPosition;
    protected List<GridPosition> movementPath;
    [SerializeField] private Slider healthBar;

    protected void Start() {
        this.canMove = true;
        //this.__maxHealth__ = 100;
        this.health = this.__maxHealth__;
        //this.speed = 2f;
        //this.coinsDropped = 10f;
        this.movementPath = LevelManager.Instance.GetEnemyTravelPath();
        GetInitialEnemyMovement();
    }

    protected void Update() {
        if (CheckIfAtGridPosition()) {
            this.canMove = false;
            GetEnemyMovement();
            transform.rotation = Quaternion.LookRotation((GridMechanics.Instance.GetWorldPosition(this.toPosition) - transform.position).normalized);
            this.canMove = true;
        }
        //if(transform.rotation < )
         //   GetEnemyMovement();
         //   transform.rotation = Quaternion.LookRotation((GridMechanics.Instance.GetWorldPosition(this.toPosition) - transform.position).normalized);
        //Debug.Log(transform.rotation + " " + this.toPosition);
        if(this.canMove){
            transform.Translate(Vector3.forward * this.speed * Time.deltaTime);
        }
    }

    protected void Death() {
        EnemyManager.Instance.EnemyDeath();
        Destroy(gameObject);
    }

    public void DamageTaken(int damage) {
        this.health -= damage;
        if (this.health <= 0) {
            this.health = 0;
            PaymentSystem.Instance.AddCoins(this.coinsDropped);
            Death();
        }
        float healthValue = (float)this.health / (float)this.__maxHealth__;
        this.healthBar.value = healthValue;
    }

    public bool CheckIfAtGridPosition() {
        float overBlub = .3f;
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

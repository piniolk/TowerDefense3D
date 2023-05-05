using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour {

    protected GridPosition gridPosition;
    protected int damage;
    protected int towerCost;
    protected int towerLevel;
    protected int maxLevel;
    protected float attackRadiusScale;
    protected float rateOfFire;
    protected float timer;
    protected bool canFire = false;
    //protected string towerName;
    //private string towerName = "Basic Tower";
    [SerializeField] protected GameObject attackRadius;
    [SerializeField] protected GameObject towerInfoUI;
    [SerializeField] protected TowerAttackRangeCollider attackRange;
    //private List<GameObject> enemiesInRange;

    protected virtual void Awake() {
        this.damage = 20;
        this.towerCost = 100;
        this.towerLevel = 1;
        this.maxLevel = 5;
        this.attackRadiusScale = 5f;
        this.rateOfFire = 1f;
        this.timer = this.rateOfFire;
    }

    protected virtual void Update() {
        if (canFire) {
            //this.enemiesInRange = attackRange.GetEnemiesInRange();
            if (attackRange.GetLength() != 0) {
                AttackClosestEnemy();
            }
        } else {
            timer -= Time.deltaTime;
        }
        if (timer <= 0) {
            canFire = true;
        }
    }

    public virtual string GetTowerName() {
        return "Basic Tower";
    }

    public int GetDamageDealt() {
        return this.damage;
    }

    public void HandleTowerInfo() {
        //towerInfoUI.SetActive(!towerInfoUI.activeSelf);
        //attackRadius.GetComponent<MeshRenderer>().enabled = !attackRadius.GetComponent<MeshRenderer>().enabled;
        TowerSystem.Instance.ToggleTowerUIObject();

        attackRadius.GetComponent<MeshRenderer>().enabled = !attackRadius.GetComponent<MeshRenderer>().enabled;

    }

    public int GetTowerCost() {
        return this.towerCost;
    }

    protected void AttackClosestEnemy() {
        //find closest enemy
        GameObject closestEnemy = attackRange.GetClosestEnemy();
        if (closestEnemy == null) {
            return;
        }
        //attack enemy
        closestEnemy.GetComponent<EnemyAI>().DamageTaken(this.damage);
        timer = rateOfFire;
        canFire = false;

    }

    public void ChangeTowerCost() {
        //if tower was bought or upgraded
        this.towerCost += Mathf.RoundToInt(this.towerCost / 2);
    }

    public void UpgradeTower() {
        if (PaymentSystem.Instance.GetCoins() > this.towerCost && this.towerLevel < this.maxLevel) {
            PaymentSystem.Instance.BuyTower(this.towerCost);
            ChangeTowerCost();
            this.towerLevel++;
            this.damage += Mathf.RoundToInt(this.damage / 2);
            this.rateOfFire += Mathf.RoundToInt(this.rateOfFire / 2);
            this.attackRadiusScale += this.attackRadiusScale / 4;
            ExpandRadius();
        } 
        if(this.towerLevel == this.maxLevel) {
            gameObject.GetComponent<TowerUIMenu>().DeleteUpgradeButton();
        }
    }

    protected void ExpandRadius() {
        attackRadius.transform.localScale = new Vector3(this.attackRadiusScale, this.attackRadiusScale, this.attackRadiusScale);
    }

    public string[] GetUpgradeInfo() {
        if (this.towerLevel < this.maxLevel) {
            int newLevel = this.towerLevel;
            newLevel++;
            int newDamage = this.damage + Mathf.RoundToInt(this.damage / 2);
            float newROF = this.rateOfFire + Mathf.RoundToInt(this.rateOfFire / 2);
            float newRadius = this.attackRadiusScale + this.attackRadiusScale / 2;
            string[] upgradeInfo = {
            newLevel.ToString(),
            newDamage.ToString(),
            newROF.ToString(),
            newRadius.ToString()
        };
            return upgradeInfo;
        }
        return null;
    }

    public string[] GetTowerInfo() {
        string[] upgradeInfo = {
            this.towerLevel.ToString(),
            this.damage.ToString(),
            this.rateOfFire.ToString(),
            this.attackRadiusScale.ToString()
        };
        return upgradeInfo;
    }
}

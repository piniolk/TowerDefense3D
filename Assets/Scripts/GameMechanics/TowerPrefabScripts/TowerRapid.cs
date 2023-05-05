using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRapid : TowerBase {
    protected void Awake() {
        this.damage = 5;
        this.towerCost = 150;
        this.towerLevel = 1;
        this.maxLevel = 5;
        this.attackRadiusScale = 5f;
        this.rateOfFire = .5f;
        this.timer = this.rateOfFire;
    }


    public override string GetTowerName() {
        return "Rapid Tower";
    }
}

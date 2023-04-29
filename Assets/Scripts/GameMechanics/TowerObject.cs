using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "Tower Object", menuName = "ScriptableObjects/TowerObject")]
public class TowerObject : ScriptableObject {
    public GameObject towerModel;
    public GameObject towerPlacingModel;

}

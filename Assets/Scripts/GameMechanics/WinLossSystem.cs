using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLossSystem : MonoBehaviour {
    [SerializeField] private GameObject defeatScreenObject;
    [SerializeField] private GameObject winScreenObject;
    [SerializeField] private GameObject gameUIObject;

    public static WinLossSystem Instance { get; private set; }

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("There's more than one WinLossSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void WinGame() {
        gameUIObject.SetActive(false);
        winScreenObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoseGame() {
        gameUIObject.SetActive(false);
        defeatScreenObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReplayLevel() {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void BackToTitleScreen() {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void BackToLevelSelectScreen() {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}

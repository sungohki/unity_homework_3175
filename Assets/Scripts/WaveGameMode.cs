using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveGameMode : MonoBehaviour
{
    [SerializeField] private ObjectLife playerLife;
    [SerializeField] private ObjectLife playerBaseLife;

    void Start() {
        playerLife.onDeath.AddListener(OnPlayerOrBaseDied);
        playerBaseLife.onDeath.AddListener(OnPlayerOrBaseDied);
        EnemyManager.instance.onChanged.AddListener(CheckWinCondition);
        WavesManager.instance.onChanged.AddListener(CheckWinCondition);
    }

    void OnPlayerOrBaseDied()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    void CheckWinCondition() {
        if (EnemyManager.instance.enemies.Count <= 0 && WavesManager.instance.waves.Count <= 0)
            SceneManager.LoadScene("WinScreen");
    } 
}

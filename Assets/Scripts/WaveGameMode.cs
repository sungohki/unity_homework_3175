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
    }

    void OnPlayerOrBaseDied()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    void CheckWinCondition() {

    } 
}

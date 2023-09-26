using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int amount;

    void Awake() {
        if (instance == null){
            instance = this;
        }
        else {
            print("Duplicated ScoreManager, Ignoring this one");
        }
    }
}
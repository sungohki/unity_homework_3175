using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private int score = 10;

    void Awake() {
        if (instance == null){
            instance = this;
        }
        else {
            print("Duplicated ScoreManager, Ignoring this one");
        }
    }

    public int getAmount() {
        return score;
    }

    public void addAmount(int num) {
        score += num;
    } 
}
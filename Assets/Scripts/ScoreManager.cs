using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private int amount = 10;

    void Awake() {
        if (instance == null){
            instance = this;
        }
        else {
            print("Duplicated ScoreManager, Ignoring this one");
        }
    }

    public int getAmount() {
        return amount;
    }

    public void addAmount(int num) {
        amount += num;
    } 
}
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
	private void Awake() {
		var life = GetComponent<ObjectLife>();
		life.onDeath.AddListener(GivePoints);
	}
	
	void GivePoints() {
		// 리스너 함수
        ScoreManager.instance.addAmount(1);
		// ScoreManager.instance.amount += 1;
	}
}

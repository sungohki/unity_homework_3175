using UnityEngine;
using UnityEngine.Events;

public class ObjectLife : MonoBehaviour
{
	public float amount;
	public UnityEvent onDeath;

	void Update() {
		if (amount <= 0) {
			onDeath.Invoke();       // Death Event Occur
			Destroy(gameObject);    // Destory object ownself
		}
	}
}

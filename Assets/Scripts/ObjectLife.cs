using UnityEngine;
using UnityEngine.Events;

public class ObjectLife : MonoBehaviour
{
	[SerializeField] private float lifePoint = 10.0f;
	 
	public UnityEvent onDeath;

	void Update() {
		if (lifePoint <= 0)
			LifeZero();
	}

	void LifeZero() {
		Destroy(gameObject);    // Destory object ownself
		onDeath.Invoke();       // Death Event Occur
	}

	public void addLifePoint(float num) {
		lifePoint += num;
	}

	public void setLifePoint(float num) {
		lifePoint = num;
	}
}

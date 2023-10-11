using UnityEngine;

public class PlayerCollector: MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		var collectable = other.GetComponent<Collectable>();
		if (collectable == null) return;
		collectable.Collect();

	}
}
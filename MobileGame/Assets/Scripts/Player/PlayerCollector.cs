using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
	[SerializeField] private bool _canCollect;

	public bool CanCollect
	{
		get => _canCollect;
		set => _canCollect = value;
	}

	private void OnTriggerEnter(Collider other)
	{
		var collectable = other.GetComponent<Collectable>();
		if (collectable == null || !_canCollect) return;
		collectable.Collect();

	}
}
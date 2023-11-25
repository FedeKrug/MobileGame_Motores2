
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
	public bool playerDetected;
	private void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag("Player")) return;

		playerDetected = true;
	}
	private void OnTriggerExit(Collider other)
	{
		if (!other.CompareTag("Player")) return;

		playerDetected = false;
	}
}

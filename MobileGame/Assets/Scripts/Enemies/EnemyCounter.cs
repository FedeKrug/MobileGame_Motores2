using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
	[SerializeField] private int _enemyCant = 1;
	public bool enemiesInLevel = true;
	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<Enemy>())
		{
			_enemyCant--;
			CheckEnemyCant();

		}
	}

	[ContextMenu("CheckEnemyCant")]
	private void CheckEnemyCant()
	{
		//Funciona, pero solo si el enemigo sale fisicamente del trigger, no si se desactiva -> TODO: Revisar
		if (_enemyCant <= 0)
		{
			//Dejar de disparar

			//Permitir el paso al siguiente nivel, si es que hay uno.
			enemiesInLevel = false;
			//Recoger monedas y exp que hayan dropeado los enemigos
			Debug.Log($"<color=yellow>No hay mas enemigos</color>");
		}
	}

}

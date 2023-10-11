using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Image _interactableButtonIndicator;
    [SerializeField] private List<Interactable> _interactables = new();
	[SerializeField] private bool _canInteract;
	private void OnTriggerEnter(Collider other)
	{
		var interactable = other.GetComponent<Interactable>();
		if ( interactable == null) return;
		_interactableButtonIndicator.enabled = true;
		_interactables.Add(interactable);
		_canInteract = true;
		//other.GetComponent<Interactable>().Interact();
	}
	private void OnTriggerExit(Collider other)
	{
		var interactable = other.GetComponent<Interactable>();
		if (interactable == null) return;
        _interactableButtonIndicator.enabled = false;
		_interactables.Remove(interactable);
		_canInteract = false;
		//other.GetComponent<Interactable>().Interact();
	}
	public void InteractWithObjects()
	{
        if (_interactables.Count <= 0 || !_canInteract) return;
		_interactables[_interactables.Count - 1]?.Interact();
	}

}

using UnityEngine;

public class StateManager : MonoBehaviour
{
	private State _currentState;
	
	private void Update()
	{
		RunStateMachine();
	}
	private void RunStateMachine()
	{
		State nextState = _currentState?.RunCurrentState();

		if (nextState != null)
		{
			//Switch state
			SwitchToNextState(nextState);
		}

	}

	private void SwitchToNextState(State nextState)
	{
		_currentState = nextState;
	}
}

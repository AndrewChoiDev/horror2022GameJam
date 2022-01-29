using UnityEngine;
using UnityEngine.Events;


public abstract class GameEventListenerGeneric<T, H> : MonoBehaviour, IGameEventListenerGeneric<T> 
	where H : GameEventGeneric<T> {

	[SerializeField] private H gameEvent;
	[SerializeField] private UnityEvent<T> unityEvent;

	public void RaiseEvent(T input) {
		unityEvent.Invoke(input); 
		// Debug.Log("name: " + this.gameEvent.name + ", input: " + input);
	}
	private void Awake() => gameEvent.Register(this);
	private void OnDestroy() => gameEvent.Deregister(this);
}
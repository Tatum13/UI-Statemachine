using UnityEngine;
using UnityEngine.Events;

public class GamePlayMenuState : UIBaseState
{
    [SerializeField] private UnityEvent onPause = new UnityEvent();
    [SerializeField] private UnityEvent onPressedResume = new UnityEvent();
    [SerializeField] private UnityEvent onUnpause = new UnityEvent();

    private bool _isPaused;

    protected override void EnterState(){}
    
    private void Update() => GetPauseState();

    private void GetPauseState()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && OwningStateMachine.CurrentState is GamePlayMenuState or PauseMenuState)
        {
            Resume();
        }
    }

    public void Resume()
    {
        if(!_isPaused) onPause?.Invoke();
        else onUnpause?.Invoke();
        _isPaused = !_isPaused;
    }

    protected override void ExitState(){}
}

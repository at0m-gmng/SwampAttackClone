using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    
    private Player _target;
    private State _currentState;

    public State CurrentState => _currentState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Reset(_firstState);
    }

    private void Update()
    {
        if(_currentState==null)
            return;
        var nextState = _currentState.GetNext(); // проверяем следующее состояние
        if (nextState != null)
            Transit(nextState); // производим переход
    }

    private void Reset(State firstState) // запускаем стартовое состояние через Reset
    {
        _currentState = firstState;
        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState != null) 
            _currentState.Exit();

        _currentState = nextState;
        if(_currentState != null)
            _currentState.Enter(_target);
    }
}

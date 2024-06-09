using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    protected GameStateManager _gameStateManager;

    public virtual void Init(GameStateManager gameStateManager)
    {
        _gameStateManager = gameStateManager;
    }

    private bool _wasSet;
    public virtual void EnterFirstTime()
    {

    }
    public virtual void Enter ()
    {
        if(_wasSet == false)
        {
            EnterFirstTime();
            _wasSet = true;
        }
    }

    public virtual void Exit ()
    {

    }
}

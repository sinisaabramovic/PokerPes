using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPresenter : IButton
{
    private GameManager _gameManager;
    private bool _enabled;
    public GameManager GameManager { get { return _gameManager; } set { _gameManager = value; } }

    public bool Enabled { get { return _enabled; } }

    public void Disable()
    {
        _enabled = false;
    }

    public void Enable()
    {
        _enabled = true;
    }

    public void Pressed(Action onCompletion)
    {
        if (_enabled)
        {
            if(onCompletion != null)
            {
                onCompletion();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IButton  
{
    GameManager GameManager { get; set; }
    bool Enabled { get;}
    void Pressed(Action onCompletion);
    void Enable();
    void Disable();

}

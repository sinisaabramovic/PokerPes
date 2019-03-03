using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImmutableGameObject 
{
    private Vector3 position;

    public ImmutableGameObject(Vector3 vector)
    {
        this.position = vector;
    }

    public ImmutableGameObject setPosition(Vector3 position)
    {
        return new ImmutableGameObject(this.position + position);
    }
}

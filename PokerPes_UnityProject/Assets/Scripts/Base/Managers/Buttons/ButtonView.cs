using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonView : MonoBehaviour 
{
    public GameManager gameManager;

    ButtonPresenter ButtonPresenter;

    private void Awake()
    {
        ButtonPresenter = new ButtonPresenter();
        ButtonPresenter.GameManager = gameManager;
        ButtonPresenter.Enable();
    }

    private void OnMouseDown()
    {
        Debug.Log("Pressed1");

        ButtonPresenter.Pressed(() => {
            ButtonPresenter.GameManager.DrawCards();
        });
    }
}

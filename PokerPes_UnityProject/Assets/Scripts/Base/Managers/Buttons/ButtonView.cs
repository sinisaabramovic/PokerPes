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
        ButtonPresenter.Pressed(() => {
            if(ButtonPresenter.GameManager.managerState == ManagerState.CanDraw)
            {
                ButtonPresenter.GameManager.DrawCards();
            }
        });
    }
}

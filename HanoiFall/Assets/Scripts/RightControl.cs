using System;
using UnityEngine;

public class RightControl : MonoBehaviour
{
    public event Action<int> ButtonClicked;


    public void LeftButtonClicked()
    {
        ButtonClicked?.Invoke(((int)ButtonType.Left));
    }

    public void RightButtonClicked()
    {
        ButtonClicked?.Invoke(((int)ButtonType.Right));
    }

    public void AButtonClicked()
    {
        ButtonClicked?.Invoke(((int)ButtonType.A));
    }

    public void BButtonClicked()
    {
        ButtonClicked?.Invoke(((int)ButtonType.B));
    }

}

enum ButtonType
{
    Left,
    Right,
    A,
    B
}

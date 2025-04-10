using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class changeAppearance : MonoBehaviour
{

    public Image image;

    public void MouseIsOver()
    {
        image.color = Color.yellow;
    }

    public void MouseNotOver()
    {
        image.color = Color.gray;
    }
}


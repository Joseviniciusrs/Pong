using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorBase : MonoBehaviour
{
    public Color color;


    [Header("References")]

    public Image UiImage;
    
    public Player myPlayer;

    private void OnValidate()
    {
        UiImage = GetComponent<Image>();
    }
    public void Start()
    {
        UiImage.color = color;
    }

    public void OnClick()
    {
        myPlayer.ChangeColor(color);
    }
}

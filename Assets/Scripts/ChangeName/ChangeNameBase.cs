using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeNameBase : MonoBehaviour
{

    [Header("References")]

    public TextMeshProUGUI uiTextName;
    public TMP_InputField  uiInputField;
    public GameObject changeNameInput;
    public Player player;

    private string PlayerName;


   public void ChangeName()
    {
        PlayerName = uiInputField.text;
        uiTextName.text = PlayerName;
        changeNameInput.SetActive(false);
        player.SetName(PlayerName);
    }
}

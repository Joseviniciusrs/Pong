using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;

    public Player playerHighScore;

    private string keyToSave = "keyHighscore";

    [Header("References")]

    public TextMeshProUGUI uiHighscore;


    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        UpdateText();

    }

    private void UpdateText()
    {
        uiHighscore.text = PlayerPrefs.GetString(keyToSave, "Sem highscore");

    }

    public void SavePlayerWin(Player p)
    {
        if (p.playerName == "") return;
        PlayerPrefs.SetString(keyToSave, p.playerName);
        UpdateText();
    }
}

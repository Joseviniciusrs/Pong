using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int MaxPoints = 2;
    public float speed = 10f;
    public Image uiPLayer;
    public string playerName;


    [Header("Key Setup")]
    public KeyCode upKeyCode = KeyCode.UpArrow;
    public KeyCode downKeyCode = KeyCode.DownArrow;

    public Rigidbody2D myRigidBody2D;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uTextPoints;
    [SerializeField] TextMeshProUGUI MenuHighScore;

    private void Awake()
    {
        ResetPlayer();
        UpdateHighScoreMenu();
    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI(); 
    }

    void Update()
    {
        if (Input.GetKey(upKeyCode))

            myRigidBody2D.MovePosition(transform.position + transform.up * speed);
        //transform.Translate(transform.up * speed);
        else if (Input.GetKey(downKeyCode))

            myRigidBody2D.MovePosition(transform.position + transform.up * -speed);
        //transform.Translate(transform.up * speed * -1);
    }

    public void AddPoint()
    {
        currentPoints++;
        UpdateUI();
        CheckMaxPoints();
        Debug.Log(currentPoints);
        ShowMenuScore();
    }

    public void ChangeColor(Color c)
    {
        uiPLayer.color = c;
    }

    private void UpdateUI()
    {
        uTextPoints.text = currentPoints.ToString();
    }

    public void CheckMaxPoints()
    {
        if(currentPoints >= MaxPoints)
        {
            GameManager.Instance.EndGame();
            HighScoreManager.Instance.SavePlayerWin(this);
            
        }
    }

    private void ShowMenuScore()
    {
        if (currentPoints > PlayerPrefs.GetInt("Pontuacao", 0))
        {
            PlayerPrefs.SetInt("Pontuacao", currentPoints);
        }
    }

    void UpdateHighScoreMenu()
    {
        MenuHighScore.text = $" Pontuacao : {PlayerPrefs.GetInt("Pontuacao", 0)}";
    }

}

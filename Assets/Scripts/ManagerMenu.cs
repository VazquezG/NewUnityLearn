using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ManagerMenu : MonoBehaviour
{
    [SerializeField]
    TMP_InputField NamePlayer;
    [SerializeField]
    TextMeshProUGUI highscore;
    
    void Start()
    {
        highscore.text = "High Score: " + MyManager.Instance.playerName + " : " + MyManager.Instance.maxScore;
        NamePlayer.text = MyManager.Instance.playerName;
    }

    public void PlayGame()
    {
        MyManager.Instance.holdName = NamePlayer.text;
        SceneManager.LoadScene(1);
    }

    public void backMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        MyManager.Instance.playerName = "";
        MyManager.Instance.maxScore = 0;
        MyManager.Instance.SaveInfo();
        EditorApplication.ExitPlaymode();

        //Application.Quit();
    }
}

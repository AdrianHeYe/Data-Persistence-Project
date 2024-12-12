using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TMP_InputField inputField;

    public Button resetButton;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(DataManager.Instance.highScorePlayerName);
        SetHighScoreText();
        if(inputField != null)
        {
            inputField.onValueChanged.AddListener(OnInputValueChanged);
        }
        resetButton.onClick.AddListener(SetHighScoreText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHighScoreText()
    {
        if (DataManager.Instance && DataManager.Instance.highScorePlayerName != "")
        {
            highScoreText.text = "Best Score: " + DataManager.Instance.highScorePlayerName + ": " + DataManager.Instance.highScore;
        }
        else
        {
            highScoreText.text = "Best Score";
        }
    }

    void OnInputValueChanged(string input)
    {
        DataManager.Instance.currentPlayerName = input;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}

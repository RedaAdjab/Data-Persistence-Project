using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;

    void Start()
    {
        SetHighScore();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif        
    }

    public void ReadName(string name)
    {
        DataManager.Instance.playerName = name;
    }
    public void SetHighScore()
    {
        DataManager.Instance.LoadHighScore();
        highScoreText.text = "Best Score : " + DataManager.Instance.highScoreName + " : " + DataManager.Instance.highScore;
    }
}

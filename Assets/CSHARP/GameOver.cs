using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    //儲存分數的欄位
    string SaveScore = "SVScore";
    public Text ScoreText;
    string SaveHighScore = "SVHighScore";
    string SaveLevelID = "SVLevelID";
    public Text HighScoreText;
    public Button Next;

    void Start()
    {
        ScoreText.text = "Score:" + PlayerPrefs.GetFloat(SaveScore);
        HighScoreText.text = "High Score:" + PlayerPrefs.GetFloat(SaveHighScore + PlayerPrefs.GetFloat(SaveLevelID));
        if (PlayerPrefs.GetFloat(SaveHighScore + PlayerPrefs.GetFloat(SaveLevelID)) > PlayerPrefs.GetFloat(SaveScore))
        {
            Next.interactable = false;
        }
        else
        {
            Next.interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //設定九個關卡的最高分數

        /*如果第一筆最高得分 = null，將得分直接儲存在最高得分
          如果得分!= null，if 得分<最高得分，挑戰失敗，重新開始
          如果得分!= null，if 得分>最高得分，挑戰成功，開啟下一關*/
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void NextButton()
    {
        LEVEL.OpenLevelID++;
        SceneManager.LoadScene("Level");
    }
}

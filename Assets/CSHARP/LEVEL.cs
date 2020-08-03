using UnityEngine;
using UnityEngine.UI;

public class LEVEL : MonoBehaviour
{
    public string NextSceneName;
    public int LevelID;
    public Text Leveltext;
    [Header("設定每個關卡最高分數")]
    public float SetHighScore;
    //儲存每個關卡最高分數
    string SaveHighScore = "SVHighScore";
    string SaveLevelID = "SVLevelID";

    static public int OpenLevelID = 1;
    //抓取所有LEVEL頁面所有關卡按鈕
    public GameObject[] LevelButton;

    private void Start()
    {
        if (Application.loadedLevelName == "Level" && GetComponentInChildren<Text>() != null)
        {
            //抓取子物件
            Leveltext = GetComponentInChildren<Text>();
            //字串調整成數值
            LevelID = int.Parse(Leveltext.text);
        }
       // LevelButton = GameObject.FindGameObjectsWithTag("LevelButton");

        for (int i = 0; i <= OpenLevelID - 1; i++)
        {
            LevelButton[i].GetComponent<Button>().interactable = true;
        }
    }


    public void NextScene()
    {
        if (NextSceneName == "Menu")
        {
            Destroy(GameObject.Find("BGM").gameObject);
        }
   

        if (NextSceneName == "Video")
        {
            GameObject.Find("BGM").GetComponent<AudioSource>().enabled = false;
        }


        if (NextSceneName == "GAME")
        {
            PlayerPrefs.SetFloat(SaveLevelID, LevelID);
            //關卡跳進GAME之前，將先將每關最高得分儲存
            PlayerPrefs.SetFloat(SaveHighScore + LevelID, SetHighScore); ;
            GameObject.Find("BGM").GetComponent<AudioSource>().enabled = true;
        }
        Application.LoadLevel(NextSceneName);
    }
}

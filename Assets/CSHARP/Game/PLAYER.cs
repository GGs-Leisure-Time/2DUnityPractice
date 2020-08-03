using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLAYER : MonoBehaviour
{
    [Range(0f, 1f)] public float Speed;
    // Start is called before the first frame update
    [Header("選擇操控玩家的方式")]
    public ControlType Control;
    [Header ("手機搖桿物件")]
    public GameObject Joystickobject;
    bool MouseClick;
    //判斷是否有使用手機搖桿
    bool UseJoystick;
    public enum ControlType 
    {
        鍵盤 = 0, 手機陀螺 = 1, 滑鼠 = 2, 手機搖桿 = 3
    }
    [Header("玩家血量")]
    public float PlayerHP;
    //程式中計算玩家的血量數值
    float scriptHP;
    [Header("玩家血條")]
    public Image HPBar;
    [Header("打死敵機加分")]
    public float AddScore;
    float ScripScore;
    public Text ScoreText;
    //儲存分數的欄位
    string SaveScore = "SVScore";


    //子彈打到玩家 玩家扣血
    public void Hurt(float hurt)
    {
        scriptHP -= hurt;
        scriptHP = Mathf.Clamp(scriptHP, 0, PlayerHP);
        HPBar.fillAmount = scriptHP / PlayerHP; 
        if (scriptHP <= 0)
        {
            PlayerPrefs.SetFloat(SaveScore, ScripScore);
            Application.LoadLevel("End Scene");
        }
    }

    public void Score()
    {
        ScripScore += AddScore;
        ScoreText.text = "Score:" + ScripScore;
    }

    void Start()
    {
        //程式中的血量=屬性面板中調整的玩家血量數值
        scriptHP = PlayerHP;
    }

    // Update is called once per frame
    void Update()
    {
        /*//Input.GetKey("a")按下A鍵if條件內的腳本持續進行
        if (Input.GetKey("a")) 
        {
            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        }
        //Input.GetKeyDown("d")按下D鍵且放開，if條件內的腳本執行一次
        //Input.GetKeyUp("d")按下D鍵且放開，if條件內的腳本執行一次
        if (Input.GetKeyUp("d"))
        {
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        }
        */
//#if UNITY_STANDALONE
        if((int)Control == 0)
        transform.Translate(Speed * Input.GetAxis("Horizontal"), Speed * Input.GetAxis("Vertical"), 0f);

        //#endif
        //#if UNITY_ANDROID
        if ((int)Control == 1)
            transform.Translate(Speed*Input.acceleration.x, Speed *Input.acceleration.y, 0f);
        #region 滑鼠說明
        //滑鼠左鍵ID=0右鍵=1中間滾輪=2
        //if(Input.GetMouseButtonDown(0))按下滑鼠左鍵，if條件裡面的程式只會執行一次
        //if(Input.GetMouseButton(1))按下滑鼠右鍵，if條件裡面的程式持續執行，直到放開右鍵停止
        //if(Input.GetMouseButtonUp(2))按下滑鼠中鍵且放開，if條件裡面的程式只會執行一次
        #endregion
        if ((int)Control == 2)
        {
            if (Input.GetMouseButton(0))
            {
                //Input.mousePosition 抓取滑鼠座標位置
                Debug.Log(Input.mousePosition);
                //紀錄轉換後的座標值
                Vector3 Point;
                //Camera.main透過遊戲主攝影機(TAG要叫MAINCAMERA)
                //ScreenToViewportPoint將遊戲視窗螢幕的座標轉換成在遊戲編輯器內的三為座標數值
                Point = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                transform.position = new Vector3(Point.x, Point.y, transform.position.z);
                Cursor.visible = false;
            }
            if ((int)Control == 3)
            {
                Joystickobject.SetActive(true);
            }
            else
            {
                Joystickobject.SetActive(false);
            }
        if (Input.GetMouseButtonUp(0))
            {
                //鼠標顯示
                Cursor.visible = true;

            }
        }

        //#endif
        /*/if (transform.position.x >= 2.6f)
             //transform.position = new Vector3(2.6f, transform.position.y, transform.position.z);
         //if (transform.position.x < -2.6f)
             //transform.position = new Vector3(-2.6f, transform.position.y, transform.position.z);
        */


        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.6f, 2.6f), Mathf.Clamp(transform.position.y, -4.8f, 4.8f), transform.position.z);
    }

    public void UsingJoystick() 
    {
        UseJoystick = true;
    }
        public void UnUsingJoystick() 
    {
        UseJoystick = false;
    } 
    public void IsUsingJoystick(Vector3 pos) 
    {
        if (UseJoystick)
            transform.Translate(Speed * pos.x, Speed * pos.y, 0f);
    }
    private void OnMouseDown()
    {
        MouseClick = true;
    }
    private void OnMouseUp()
    {
        MouseClick = false;
    }



}

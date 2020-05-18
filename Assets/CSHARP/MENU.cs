using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MENU : MonoBehaviour
{
    #region 下一關
    public void NextScene()
    {
        //Application.LoadLevel("場景名稱");
        //Application.LoadLevel(場景名稱ID);
        //Application.loadLevel-->讀取當前關卡名稱
        //Application.LoadLevel(Application.loadedLevel); 重新遊戲關卡
        Application.LoadLevel(1);

    }
    public void BackScene()
    {

        Application.LoadLevel(0);

    }

    #endregion
    #region 遊戲關閉
    public void Quit()
    {
        //輸出成遊戲執行檔才可以進行遊戲
        Application.Quit();

    }

    #endregion

    #region 遊戲聲音

    bool Sound = true;
    [Header("聲音按鈕")]
    public Image SoundButtonImage;
    [Header("聲音開啟")]
    public Sprite SoundOpenSprite;
    [Header("聲音關閉")]
    public Sprite SoundCloseSprite;
    [Header("聲音音軌")]
    public Slider SoundSlider;
    [Header("下拉選單")]
    public Dropdown ScreeSize;

    private void Start()
    {
        sound();
        SoundSlider.value = 1f;
        AudioListener.volume = SoundSlider.value;
    }

    private void Update()
    {
        AudioListener.volume = SoundSlider.value;
        if (ScreeSize.value == 0)
        {
            Screen.SetResolution(1080, 1920, false);
        } 
        if (ScreeSize.value == 1)
        {
            Screen.SetResolution(720, 1080, false);
        } 
        if (ScreeSize.value == 2)
        {
            Screen.SetResolution(480, 800, false);
        }

    }
    
    public void sound()
    {

        Sound = !Sound;
        if (Sound == true)
        {
            //AudioListener.pause = false;整體遊戲聲音開啟
            AudioListener.pause = false;
            SoundButtonImage.sprite = SoundOpenSprite;
        }
        else
        {
            //AudioListener.pause = true;整體遊戲聲音關閉
            AudioListener.pause = true;
            SoundButtonImage.sprite = SoundCloseSprite;
        }
    }
    #endregion

    public void ChangeAudioSlider()
    {
        if (SoundSlider.value == 0)
        {
            Sound = true;
            sound();
        }
        else 
        {
            Sound = false;
            sound();
        }
    
    }
}


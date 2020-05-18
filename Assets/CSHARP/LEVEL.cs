using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEVEL : MonoBehaviour
{
    public string NextSceneName;
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

        if (NextSceneName == "UI")
        {
            GameObject.Find("BGM").GetComponent<AudioSource>().enabled = true;
        }
        Application.LoadLevel(NextSceneName);
    }
}

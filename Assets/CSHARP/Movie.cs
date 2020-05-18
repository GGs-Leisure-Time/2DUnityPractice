using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Movie : MonoBehaviour
{
    public VideoPlayer Movie_;
    float Timer;
    void Start()
    {
        InvokeRepeating("CheckMovie", 3f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckMovie()
    {
        if (Movie_.isPlaying == false)
        {
            Application.LoadLevel("Game");
        }
    }
}

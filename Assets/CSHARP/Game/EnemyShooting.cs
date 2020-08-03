using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [Header ("設定幾秒產生一顆子彈")]
    public float CreateTime;
    [Header ("子彈物件")]
    public GameObject Bullet;
    [Header("子彈生成點")]
    public Transform CreateObject;
    [Header("音效")]
    public AudioSource ShootingSound;
    // Start is called before the first frame update
    void Start()
    {
        ShootingSound = GameObject.Find("Shoot2").GetComponent<AudioSource>();
        InvokeRepeating("CreateBullet",CreateTime,CreateTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateBullet()
    {
        //動態生成Instantiate(要生成的物件,生成後的物件位置,生成後的物件角度);   
        Instantiate(Bullet,CreateObject.position,CreateObject.rotation);
        ShootingSound.Play();
    }
}

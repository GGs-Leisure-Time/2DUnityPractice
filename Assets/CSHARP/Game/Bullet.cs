using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    [Header("多久時間被刪除")]
    public float DeleteTime;

    void Start()
    {
        Destroy(gameObject, DeleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3.up=(0,1,0), Vector3.down = (0,-1,0), Vector3.forward = (1,0,0)
        //transform.Translate(0, Speed, 0);
        transform.Translate(Vector3.down * Speed);
    }
    /*
    OnTriggerEnter、OnTriggerStay、OnTriggerExit
    OnCollisionEnter、OnCollisionStay、OnCollisionExit
    Enter 兩個物件碰撞，Fuction內的物件只會執行一次
    Stay 兩個物件碰撞沒有分開，Function內的物件會持續進行，直到物件分離
    Exit 兩個物件碰撞且分開，Function內的物件只會執行一次
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}

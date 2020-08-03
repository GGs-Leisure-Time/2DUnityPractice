using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float Speed;
    [Header("多久時間被刪除")]
    public float DeleteTime;
    [Header("爆炸特效")]
    public GameObject Effect;

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
    穿透型碰撞OnTriggerEnter、OnTriggerStay、OnTriggerExit
    不穿透型碰撞OnCollisionEnter、OnCollisionStay、OnCollisionExit
    Enter 兩個物件碰撞，Fuction內的物件只會執行一次
    Stay 兩個物件碰撞沒有分開，Function內的物件會持續進行，直到物件分離
    Exit 兩個物件碰撞且分開，Function內的物件只會執行一次
    */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collider2D>().tag == "Enemy" && gameObject.tag == "PlayerBullet")
        {
            Instantiate(Effect, other.transform.position, other.transform.rotation);
            //玩家子彈打到敵機，玩家加分
            GameObject.FindGameObjectWithTag("Player").GetComponent<PLAYER>().Score();
            //敵機消滅
            Destroy(other.gameObject);
            //子彈消滅
            Destroy(gameObject);



        }
        if (other.GetComponent<Collider2D>().tag == "EnemyBullet" && gameObject.tag == "PlayerBullet")
        {
            Instantiate(Effect, other.transform.position, other.transform.rotation);         
            Destroy(other.gameObject);        
            Destroy(gameObject);

        }
        if (other.GetComponent<Collider2D>().tag == "Player" && gameObject.tag == "EnemyBullet")
        {
            other.GetComponent<PLAYER>().Hurt(10f);

        }
    }

}

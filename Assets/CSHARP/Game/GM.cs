using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    [Header ("所有敵機物件")]
    public GameObject[] Enemy;
    [Header ("設定每幾秒產出敵機")]
    public float CreateTime;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", CreateTime, CreateTime);
    }

    void CreateEnemy()
    {
        Vector3 pos = new Vector3(Random.Range(-2.6f, 2.6f), Random.Range(5.0f, 5.3f), transform.position.z);

        Instantiate(Enemy[Random.Range(0, Enemy.Length)],  pos, transform.rotation);
    }
}

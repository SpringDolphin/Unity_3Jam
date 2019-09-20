using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{

    //GameManagerからgetcomponentで弾の状況を受け取る。
    public GameObject gamemaster;

    private Vector3 velocity = new Vector3(0, 0, 0);



    //定数群

    //ボールの投げるスピード
    private const float throwspeed = 1.0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ThrowInit()
    {
        Rigidbody rd = this.GetComponent<Rigidbody>();

        this.velocity = new Vector3(0, 0, throwspeed);
        rd.useGravity = true;
    }

    
    //ここからはボールの状況によって処理が変更されます。
    public void Throwing()
    {
        this.transform.position += velocity;

    }

}

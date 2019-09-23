﻿using System.Collections;
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

    //ボールの曲げ具合
    private readonly Vector3 ballAccel = new Vector3(1.0f, 1.0f, 0);



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

        Vector3 accel = new Vector3(0, 0, 0);




        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5)
        {
            accel.x = ballAccel.x * Mathf.Sign(Input.GetAxisRaw("Horizontal"));
            //Debug.Log("x");
        }

        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5)
        {
            accel.y = ballAccel.y * Mathf.Sign(Input.GetAxisRaw("Vertical"));
            //Debug.Log("y");
        }



        //vの後身
        velocity += accel;


        //位置の更新
        this.transform.position += velocity;

    }

}

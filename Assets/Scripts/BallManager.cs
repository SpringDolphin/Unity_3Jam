using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{

    //GameManagerからgetcomponentで弾の状況を受け取る。
    public GameObject gamemaster;



    //定数群

    //ボールの投げるスピード
    [SerializeField] float throwspeed = 40f;

    //ボールの曲げ具合
    private readonly Vector3 ballAccel = new Vector3(0.2f, 0.4f, 0);

    //ボールの初期位置
    private readonly Vector3 ballInitPos = new Vector3(0, 10, 0);



    // Start is called before the first frame update
    void Start()
    {
        BallInit();
    }

    // Update is called once per frame
    void Update()
    {

    }


    //ボールの初期化
    public void BallInit()
    {
        Rigidbody rd = this.GetComponent<Rigidbody>();

        this.transform.position = ballInitPos;
        rd.velocity = Vector3.zero;
        rd.useGravity = false;
    }
    public void ThrowInit()
    {
        Rigidbody rd = this.GetComponent<Rigidbody>();

        rd.velocity = new Vector3(0, 0, throwspeed);
        rd.useGravity = true;

    }


    //ここからはボールの状況によって処理が変更されます。
    public void Throwing()
    {

        Rigidbody rd = this.GetComponent<Rigidbody>();
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
        rd.velocity += accel;


        //位置の更新
        //this.transform.position += velocity;

    }

}

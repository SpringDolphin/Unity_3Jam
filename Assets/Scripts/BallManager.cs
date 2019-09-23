using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{

    //GameManagerからgetcomponentで弾の状況を受け取る。
    public GameObject gamemaster;
    public GameObject canvas;


    //判定がすんだかどうか
    private bool judgeF;



    //定数群

    //ボールの投げるスピード
    [SerializeField] float throwspeed = 40f;

    //ボールの曲げ具合
    private readonly Vector3 ballAccel = new Vector3(0.2f, 0.4f, 0.2f);

    //ボールの初期位置
    private readonly Vector3 ballInitPos = new Vector3(0, 10, 0);



    // Start is called before the first frame update
    void Start()
    {
        gamemaster = GameObject.Find("GameMaster");
        canvas = GameObject.Find("Canvas");
        BallInit();
    }

    // Update is called once per frame
    void Update()
    {

    }






    //衝突の判定について
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);



        if (judgeF) return;


        switch (other.gameObject.name)
        {
            case "ThrowArea":

                gamemaster.GetComponent<GameManager>().BallJudge("Strike");
                judgeF = true;

                break;

            case "BallArea":

                gamemaster.GetComponent<GameManager>().BallJudge("Ball");
                judgeF = true;

                break;
        }
    }



    //ボールの初期化
    public void BallInit()
    {
        Rigidbody rd = this.GetComponent<Rigidbody>();

        this.transform.position = ballInitPos;
        rd.velocity = Vector3.zero;
        rd.useGravity = false;
        judgeF = false;
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



        //vの更新
        rd.velocity += accel;


        //位置の更新
        //this.transform.position += velocity;

    }


    public void Fly()
    {

        Rigidbody rd = this.GetComponent<Rigidbody>();
        Vector3 accel = new Vector3(0, 0, 0);


        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5)
        {
            //最初の時と比べてカメラの向きが180度変化することに注意する。
            accel.x = ballAccel.x * -Mathf.Sign(Input.GetAxisRaw("Horizontal"));
            //Debug.Log("x");
        }

        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5)
        {
            accel.z = ballAccel.z * Mathf.Sign(Input.GetAxisRaw("Vertical"));
            //Debug.Log("y");
        }


        //vの更新
        rd.velocity += accel;
    }

    public Vector3 CameraDirectionAtFlying()
    {
        Vector3 vectors = this.GetComponent<Rigidbody>().velocity;

        //基準
        Vector3 answer = new Vector3(0, 180, 0);

        //実際の計算
        //Vector3 answer = new vector3(Mathf.Atan2(vectors.z, vectors.y),Mathf.Atan2(vectors.x, vectors.z),Mathf.Atan2(vectors.y, vectors.x));

        return answer;
    }
}

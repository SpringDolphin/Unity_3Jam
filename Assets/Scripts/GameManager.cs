using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ボールの状態
    public enum BallStatus
    {
        //待機中
        waiting,
        //投げられた
        throwed,
        //当たるか当たらないかの瀬戸際の時
        dodging,
        //バットから逃れた
        avoided,
        //打たれて飛ばされているとき
        flying
    };
    BallStatus ballstatus;


    GameObject ballObj;


    Camera mainCamera;


    //デバッグモードかどうか
    public bool IsDebugging = false;



    //定数群





    // Start is called before the first frame update
    void Start()
    {
        ballObj = GameObject.Find("Ball");

        mainCamera = Camera.main;



        ballstatus = BallStatus.waiting;

        mainCamera.transform.position = new Vector3(0, 10, -10);

        IsDebugging = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        switch (ballstatus)
        {
            case BallStatus.waiting:
                if (Input.GetButtonDown("Throw"))
                {
                    ballstatus = BallStatus.throwed;
                    ballObj.GetComponent<BallManager>().ThrowInit();
                }
                break;

            case BallStatus.throwed:
                ballObj.GetComponent<BallManager>().Throwing();
                break;

            case BallStatus.flying:
                ballObj.GetComponent<BallManager>().Fly();

                break;
            default:
                Debug.Log("You are an idiot!");
                break;
        }





        //デバッグモード中
        if (IsDebugging)
        {
            //カメラについて
            //mainCamera.transform.eulerAngles += new Vector3(0, 1, 0);

            if (Input.GetButtonDown("DirectionX"))
            {
                mainCamera.transform.eulerAngles = new Vector3(0, -90, 0);
                mainCamera.transform.position = new Vector3(100, 10, 30);
            }
            if (Input.GetButtonDown("DirectionY"))
            {
                mainCamera.transform.eulerAngles = new Vector3(90, 0, 0);
                mainCamera.transform.position = new Vector3(0, 65, 30);
            }
            if (Input.GetButtonDown("DirectionZ"))
            {
                mainCamera.transform.eulerAngles = new Vector3(0, 180, 0);
                mainCamera.transform.position = new Vector3(0, 10, 100);
            }
            //リセットだ
            if (Input.GetButtonDown("Reset"))
            {
                ballObj.GetComponent<BallManager>().BallInit();
                ballstatus = BallStatus.waiting;
            }
        }
        else
        {
            Vector3 ballPos = ballObj.transform.position;

            switch (ballstatus)
            {
                case BallStatus.waiting:

                    break;

                case BallStatus.throwed:
                    mainCamera.transform.position = ballPos;
                    mainCamera.transform.eulerAngles = new Vector3(0, 0, 0);

                    break;

                case BallStatus.flying:
                    mainCamera.transform.position = ballPos;
                    mainCamera.transform.eulerAngles = ballObj.GetComponent<BallManager>().CameraDirectionAtFlying();

                    break;

                default:
                    Debug.Log("You are an idiot!");
                    break;

            }
        }


        //デバッグモードの操作
        if (Input.GetButtonDown("DebugButton"))
        {
            IsDebugging = !IsDebugging;
            Debug.Log("debug is switching!");
        }
    }
}

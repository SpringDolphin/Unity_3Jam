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



    // Start is called before the first frame update
    void Start()
    {
        ballObj = GameObject.Find("Ball");

        mainCamera = Camera.main;



        ballstatus = BallStatus.waiting;

        mainCamera.transform.position = new Vector3(0, 10, -10);
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

            default:
                Debug.Log("You are an idiot!");
                break;
        }
    }
}

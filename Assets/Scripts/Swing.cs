using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public float minAngle = 0.0F;
    public float maxAngle = 180.0F;
    float startTime=1000;
    float passTime=0.0f;
    float swingStart = 0.0f;
    public float swingMin=0.0f;
    public float swingMax=1.0f;
    public float swingSpeed = 1.0f;
    bool swingMode = false;
    //バットの初期位置
    private Vector3 batInitPos;
    private Quaternion batInitRot;



    // Start is called before the first frame update
    void Start()
    {

        batInitPos = new Vector3(7, this.transform.position.y, 49);
        batInitRot = this.transform.rotation;
        BatInit();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Throw"))
        {
            startTime = Random.Range(swingMin, swingMax);
            if (!swingMode)
            {
                swingMode = true;
                swingStart = Time.time;
                passTime = 0;
            }
        }

        if ((passTime += Time.deltaTime) >= startTime)
        {
            float angle = Mathf.LerpAngle(minAngle, maxAngle, (Time.time - (swingStart+startTime)) * swingSpeed);
            transform.eulerAngles = new Vector3(90, -angle, 0);
            if (angle >= 180)
            {
                startTime = 1000;
                swingMode = false;
            }
        }
    }
    
    //バットの初期化
    public void BatInit()
    {
        Rigidbody rd = this.GetComponent<Rigidbody>();

        this.transform.position = batInitPos;
        this.transform.rotation = batInitRot;
    }
    }

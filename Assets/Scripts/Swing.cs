using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    float minAngle = 0.0F;
    float maxAngle = 180.0F;
    float startTime;
    float passTime=0.0f;
    public float swingMin=0.0f;
    public float swingMax=1.0f;
    public float swingSpeed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
         startTime = Random.Range(swingMin, swingMax);
    }

    // Update is called once per frame
    void Update()
    {
        if ((passTime += Time.deltaTime) >= startTime)
        {
            float angle = Mathf.LerpAngle(minAngle, maxAngle, (Time.time-startTime)*swingSpeed);
            transform.eulerAngles = new Vector3(90, angle, 0);
        }
    }
}

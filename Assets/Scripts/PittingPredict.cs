using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PittingPredict : MonoBehaviour
{
    public GameObject preLineRenderer;
    public GameObject preBullet;
    private GameObject objLineRenderer;
    private LineRenderer lineRenderer;
    private int count = 0;
    private float mass = 1f, drag = 1f, x = 0f, y = 0f, initVel = 10f, angle = 0f, step = 0.05f, time = 0;
    private float gravity = 9.80665f;
    private Vector3 vel;

    // Use this for initialization
    void Start()
    {
        angle = 30f * Mathf.Deg2Rad;
        vel = new Vector3(initVel * Mathf.Cos(angle), initVel * Mathf.Sin(angle), 0);

        objLineRenderer = Instantiate(preLineRenderer, gameObject.transform);
        objLineRenderer.transform.localPosition = Vector3.zero;
        lineRenderer = objLineRenderer.GetComponent<LineRenderer>();

        Time.timeScale = 0.2f;
    }

    void DisZeroDrag()
    {
        if (y >= 0)
        {
            x = vel.x * time;
            y = vel.y * time - 0.5f * gravity * (time * time + time * Time.fixedDeltaTime);
            lineRenderer.positionCount = count + 1;
            lineRenderer.SetPosition(count, new Vector3(x, y, 0));
            count++;
            time += step;
        }
    }


    // Update is called once per frame
    void Update()
    {
        DisZeroDrag();
    }
}

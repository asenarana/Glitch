using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    float rotateAmount;
    int frameCount;
    bool status;
    float angleX;
    float angleY;
    bool actionType;
    ControllerScript controllerScript;
    
    void Start()
    {
        rotateAmount = 0;
        frameCount = 0;
        status = false;
        controllerScript = GameObject.FindWithTag("controller").GetComponent<ControllerScript>();
    }

    void Update()
    {
        if(status)
        {
            if(frameCount > 0)
            {
                if(actionType)
                {
                    angleX += rotateAmount;
                    SetRotation(new Vector3(angleX, 0, 0));
                }
                else
                {
                    angleY += rotateAmount;
                    SetRotation(new Vector3(0, angleY, 0));
                }
                frameCount--;
            }
            else
            {
                status = false;
                controllerScript.SetStatus(gameObject.tag);
            }
        }
    }

    public void SetPosition(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }

    public void SetRotation(Vector3 rot)
    {
        gameObject.transform.eulerAngles = rot;
    }

    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }

    public Vector3 GetRotation()
    {
        return gameObject.transform.eulerAngles;
    }

    public void RotateDown(float amount, int count)
    {
        angleX = gameObject.transform.eulerAngles.x;
        rotateAmount = amount;
        frameCount = count;
        actionType = true;
        status = true;
    }

    public void RotateLeft(float amount, int count)
    {
        angleY = gameObject.transform.eulerAngles.y;
        rotateAmount = amount;
        frameCount = count;
        actionType = false;
        status = true;
    }
}

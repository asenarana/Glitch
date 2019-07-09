using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLightScript : MonoBehaviour
{
    private int switchCount;
    private float waitTime;
    private bool status;
    private bool timer;
    private bool control;
    ControllerScript controllerScript;
    GameObject cameraLight;
    

    void Start()
    {
        status = false;
        switchCount = 0;
        timer = false;
        control = false;
        waitTime = 0;
        controllerScript = GameObject.FindWithTag("controller").GetComponent<ControllerScript>();
        cameraLight = gameObject.transform.Find("light").gameObject;
    }
    
    void Update()
    {
        if(status)
        {
            if(switchCount > 0)
            {
                switch(control)
                {
                    case false:
                        StartCoroutine(Wait());
                        control = true;
                        break;
                    case true:
                        if(timer)
                        {
                            if(switchCount != 1)
                            {
                                cameraLight.SetActive(!cameraLight.activeSelf);
                            }
                            control = false;
                            timer = false;
                            switchCount--;
                        }
                        break;
                    default:
                        switchCount--;
                        break;
                }
                
            }
            else
            {
                cameraLight.SetActive(true);
                status = false;
                controllerScript.SetStatus(gameObject.tag);
            }
        }
    }

    public void Blink(float time, int count)
    {
        switchCount = count;
        waitTime = time;
        status = true;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        timer = true;
    }
}

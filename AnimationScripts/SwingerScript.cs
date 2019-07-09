using UnityEngine;

public class SwingerScript : MonoBehaviour
{
    private Transform swinger;

    private ControllerScript controllerScript;
    private bool status;

    private int swingCount;
    private float swingRate;
    private float swingAngle;
    private int frameCount;
    private int counter;
    private float angleX;
    private float angleY;

    private enum Action
    {
        IDLE,
        WAIT,
        SWING_FRONT,
        SWING_BACK
    }
    private Action action;

    void Start()
    {
        status = false;
        action = Action.IDLE;
        swinger = gameObject.transform.Find("SwingPivot");
        gameObject.transform.position = new Vector3(5.15f, 0.7f, 2.3f);
        gameObject.transform.eulerAngles = new Vector3(0, -100, 0);
        controllerScript = GameObject.FindWithTag("controller").GetComponent<ControllerScript>();
    }
    
    void Update()
    {
        if(status)
        {
            if (swingCount > 0)
            {
                switch (action)
                {
                    case Action.SWING_FRONT:
                        if (counter > 0)
                        {
                            angleX -= swingRate;
                            swinger.eulerAngles = new Vector3(angleX, angleY, 0);
                            counter--;
                        }
                        else
                        {
                            angleX = -1 * swingAngle;
                            swinger.eulerAngles = new Vector3(angleX, angleY, 0);
                            swingCount--;
                            counter = frameCount;
                            action = Action.SWING_BACK;
                        }
                        break;
                    case Action.SWING_BACK:
                        if (counter > 0)
                        {
                            angleX += swingRate;
                            swinger.eulerAngles = new Vector3(angleX, angleY, 0);
                            counter--;
                        }
                        else
                        {
                            angleX = swingAngle;
                            swinger.eulerAngles = new Vector3(angleX, angleY, 0);
                            swingCount--;
                            counter = frameCount;
                            action = Action.SWING_FRONT;
                        }
                        break;
                }
            }
            else
            {
                action = Action.IDLE;
                status = false;
                controllerScript.SetStatus(gameObject.tag);
            }
        }
    }
    
    public void SetSwingAngle(float angle)
    {
        angleX = angle;
        angleY = swinger.eulerAngles.y;
        swinger.eulerAngles = new Vector3(angleX, angleY, 0);
    }

    public void Swing(float totalAngle, float rate, int count, bool control)
    {
        swingAngle = totalAngle;
        swingRate = rate;
        swingCount = count;
        frameCount = (int)(2 * totalAngle / rate);
        counter = frameCount;
        if(control)
        {
            action = Action.SWING_BACK;
            angleX = -1 * swingAngle;
        }
        else
        {
            action = Action.SWING_FRONT;
            angleX = swingAngle;
        }
        angleY = swinger.eulerAngles.y;
        swinger.eulerAngles = new Vector3(angleX, angleY, 0);
        status = true;
    }

    public void StopAction()
    {
        status = false;
        frameCount = 0;
        counter = 0;
        swingCount = 0;
        action = Action.IDLE;
        controllerScript.SetStatus(gameObject.tag);
    }
}

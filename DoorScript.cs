using UnityEngine;

public class DoorScript : MonoBehaviour
{
    
    private int frameCount;
    private float actionAmount;
    private bool status;
    ControllerScript controllerScript;

    private enum Action
    {
        OPEN,
        CLOSE
    }
    private Action action;

    void Start()
    {
        status = false;
        frameCount = 0;
        actionAmount = 0;
        controllerScript = GameObject.FindWithTag("controller").GetComponent<ControllerScript>();
        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if(status)
        {
            if (frameCount > 0)
            {
                switch (action)
                {
                    case Action.OPEN:
                        gameObject.transform.eulerAngles = new Vector3(0, gameObject.transform.eulerAngles.y + actionAmount, 0);
                        break;
                    case Action.CLOSE:
                        gameObject.transform.eulerAngles = new Vector3(0, gameObject.transform.eulerAngles.y - actionAmount, 0);
                        break;
                    default:
                        break;
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

    public void OpenDoor( float amount, int count)
    {
        actionAmount = amount;
        frameCount = count;
        action = Action.OPEN;
        status = true;
    }

    public void CloseDoor(float amount, int count)
    {
        actionAmount = amount;
        frameCount = count;
        action = Action.CLOSE;
        status = true;
    }
}

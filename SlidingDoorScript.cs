using UnityEngine;

public class SlidingDoorScript : MonoBehaviour
{
    private GameObject leftDoor;
    private GameObject rightDoor;

    private int frameCount;
    private float openAmount;

    private float leftX;
    private float rightX;

    private bool status;
    private bool action;

    void Start()
    {
        leftDoor = gameObject.transform.Find("Left").gameObject;
        rightDoor = gameObject.transform.Find("Right").gameObject;
        frameCount = 0;
        status = false;
    }
    
    void Update()
    {
        if (status)
        {
            if (frameCount > 0)
            {
                if(action)
                {
                    leftX += openAmount;
                    rightX -= openAmount;
                }
                else
                {
                    leftX -= openAmount;
                    rightX += openAmount;
                }
                leftDoor.transform.localPosition = new Vector3(leftX, 0, 0);
                rightDoor.transform.localPosition = new Vector3(rightX, 0, 0);
                frameCount--;
            }
            else
            {
                status = false;
            }
        }
    }

    public void Open(float amount, int count)
    {
        frameCount = count;
        openAmount = amount;
        leftX = leftDoor.transform.position.x;
        rightX = rightDoor.transform.position.x;
        action = true;
        status = true;
    }
    public void Close(float amount, int count)
    {
        frameCount = count;
        openAmount = amount;
        leftX = leftDoor.transform.position.x;
        rightX = rightDoor.transform.position.x;
        action = false;
        status = true;
    }
}

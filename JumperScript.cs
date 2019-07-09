using UnityEngine;

public class JumperScript : MonoBehaviour
{
    private ControllerScript controllerScript;
    private int frameCount;
    private bool status;

    private float fallDistance;

    private Animator animController;
    private readonly int fallHash = Animator.StringToHash("fall");
    private readonly int impactHash = Animator.StringToHash("impact");
    private readonly int flailHash = Animator.StringToHash("flail");

    void Start()
    {
        status = false;
        frameCount = 0;
        gameObject.transform.position = new Vector3(56, 0.25f, -3);
        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        controllerScript = GameObject.FindWithTag("controller").GetComponent<ControllerScript>();
        animController = GetComponent<Animator>();
    }
    
    void Update()
    {
        if(status)
        {
            if(frameCount > 0)
            {
                gameObject.transform.position -= new Vector3(0, fallDistance, 0);
                frameCount--;
            }
            else
            {
                status = false;
                controllerScript.SetStatus(gameObject.tag);
            }
        }
    }
    
    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }

    public Vector3 GetRotation()
    {
        return gameObject.transform.eulerAngles;
    }

    public void SetPosition(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }

    public void SetRotation(Vector3 rot)
    {
        gameObject.transform.eulerAngles = rot;
    }

    public void Fall(float distance, int count)
    {
        frameCount = count;
        fallDistance = distance;
        animController.SetTrigger(fallHash);
        status = true;
    }

    public void Impact(bool flail)
    {
        animController.SetBool(flailHash, flail);
        animController.SetTrigger(impactHash);
    }
}

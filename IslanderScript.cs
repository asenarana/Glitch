using UnityEngine;

public class IslanderScript : MonoBehaviour
{
    private Animator animController;
    private int sitHash;

    void Start()
    {
        gameObject.transform.position = new Vector3(-10, -20, -921);
        gameObject.transform.eulerAngles = new Vector3(0, 45, 0);
        animController = GetComponent<Animator>();
        sitHash = Animator.StringToHash("sit");
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

    public void Sit()
    {
        animController.SetTrigger(sitHash);
    }
}

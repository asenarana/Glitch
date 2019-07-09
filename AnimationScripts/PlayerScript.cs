using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector3 startPos;
    private float angleX;
    private float angleY;
    private float scaleY;
    private int frameCount;
    private float bodyAmount;
    private float headHorizontalAmount;
    private float headVerticalAmount;
    private float eyeAmount;

    private float waitTime;
    private bool waiting;
    private bool timer;

    private GameObject humanoid;
    private GameObject avatar;
    private Transform head;
    private Transform eyes;

    private bool status;
    private ControllerScript controllerScript;

    private Animator animController;
    private bool slowDown;
    private float slowDownSpeed;
    private float slowDownCur;
    
    private readonly float speedWalk = 1.5f;
    private readonly float speedWalkStart = 1.5f;
    private readonly float speedWalkStop = 1.3f;
    private readonly float speedRun = 1f;
    private readonly float speedRunStart = 1f;
    private readonly float speedRunStop = 1f;
    private readonly float speedTurn = 1.2f;
    
    private readonly int startWalkHash = Animator.StringToHash("startWalk");
    private readonly int walkHash = Animator.StringToHash("walk");
    private readonly int sadWalkHash = Animator.StringToHash("sadWalk");
    private readonly int runHash = Animator.StringToHash("run");
    private readonly int runAwayHash = Animator.StringToHash("runAway");
    private readonly int stopHash = Animator.StringToHash("stop");
    private readonly int turnLeftHash = Animator.StringToHash("turnLeft");
    private readonly int turnRightHash = Animator.StringToHash("turnRight");
    private readonly int stopTurnHash = Animator.StringToHash("stopTurn");
    private readonly int lookAroundHash = Animator.StringToHash("lookAround");
    private readonly int sadLookHash = Animator.StringToHash("sadLook");
    private readonly int runToWalkHash = Animator.StringToHash("runToWalk");
    private readonly int lookUpHash = Animator.StringToHash("lookUp");

    private enum Action
    {
        IDLE,
        WAIT,
        MOVE_FWD,
        TURN_LEFT,
        TURN_RIGHT,
        LOOK_RIGHT_UP,
        LOOK_LEFT_UP,
        LOOK_RIGHT_DOWN,
        LOOK_LEFT_DOWN,
        LOOK_UP,
        LOOK_DOWN,
        LOOK_LEFT_UP_WALK,
        LOOK_RIGHT_UP_WALK,
        LOOK_LEFT_DOWN_WALK,
        LOOK_RIGHT_DOWN_WALK,
        LOOK_LEFT_WALK,
        LOOK_RIGHT_WALK,
        LOOK_UP_WALK,
        LOOK_DOWN_WALK,
        SHRINK_EYES,
        GROW_EYES,
        ANIM
    }
    private Action action;

    void Start()
    {
        SetStartTransform();
        action = Action.IDLE;
        status = false;
        slowDown = false;
        frameCount = 0;
        humanoid = gameObject.transform.Find("Humanoid").gameObject;
        avatar = gameObject.transform.Find("Avatar").gameObject;
        head = humanoid.transform.Find("Hips").Find("SpineLowest").Find("SpineHighest").Find("NeckPivot").Find("HeadRotatorPivot").Find("HeadPivot");
        eyes = head.Find("Head").Find("Eyes");
        controllerScript = GameObject.FindWithTag("controller").GetComponent<ControllerScript>();
        animController = GetComponent<Animator>();
        SetAvatarVisible();
    }

    void Update()
    {
        if(slowDown)
        {
            slowDownCur -= slowDownSpeed;
            animController.SetFloat(runToWalkHash, slowDownCur);
            if(slowDownCur <= 0)
            {
                slowDown = false;
                controllerScript.SetStatus(gameObject.tag);
            }
        }
        else if (status)
        {
            if (action == Action.WAIT)
            {
                if(!waiting)
                {
                    StartCoroutine(Wait());
                    waiting = true;
                }
                else
                {
                    if(timer)
                    {
                        status = false;
                        controllerScript.SetStatus(gameObject.tag);
                        action = Action.IDLE;
                    }
                }
            }
            else
            {
                if (frameCount > 0)
                {
                    switch (action)
                    {
                        case Action.MOVE_FWD:
                            gameObject.transform.position += gameObject.transform.forward * bodyAmount;
                            break;
                        case Action.TURN_LEFT:
                            angleY -= bodyAmount;
                            gameObject.transform.eulerAngles = new Vector3(0, angleY, 0);
                            break;
                        case Action.TURN_RIGHT:
                            angleY += bodyAmount;
                            gameObject.transform.eulerAngles = new Vector3(0, angleY, 0);
                            break;
                        case Action.LOOK_RIGHT_UP:
                            angleX -= headVerticalAmount;
                            angleY += headHorizontalAmount;
                            head.eulerAngles = new Vector3(angleX, angleY, 0);
                            break;
                        case Action.LOOK_LEFT_UP:
                            angleX -= headVerticalAmount;
                            angleY -= headHorizontalAmount;
                            head.eulerAngles = new Vector3(angleX, angleY, 0);
                            break;
                        case Action.LOOK_RIGHT_DOWN:
                            angleX += headVerticalAmount;
                            angleY += headHorizontalAmount;
                            head.eulerAngles = new Vector3(angleX, angleY, 0);
                            break;
                        case Action.LOOK_LEFT_DOWN:
                            angleX += headVerticalAmount;
                            angleY -= headHorizontalAmount;
                            head.eulerAngles = new Vector3(angleX, angleY, 0);
                            break;
                        case Action.LOOK_UP:
                            angleX -= headVerticalAmount;
                            head.eulerAngles = new Vector3(angleX, angleY, 0);
                            break;
                        case Action.LOOK_DOWN:
                            angleX += headVerticalAmount;
                            head.eulerAngles = new Vector3(angleX, angleY, 0);
                            break;
                        case Action.LOOK_LEFT_UP_WALK:
                            angleX -= headVerticalAmount;
                            angleY -= headHorizontalAmount;
                            head.eulerAngles = new Vector3(angleX, angleY, 0);
                            gameObject.transform.position += gameObject.transform.forward * bodyAmount;
                            break;
                        case Action.LOOK_RIGHT_UP_WALK:
                            angleX -= headVerticalAmount;
                            angleY += headHorizontalAmount;
                            head.eulerAngles = new Vector3(angleX, angleY, 0);
                            gameObject.transform.position += gameObject.transform.forward * bodyAmount;
                            break;
                        case Action.LOOK_LEFT_DOWN_WALK:
                            angleX += headVerticalAmount;
                            angleY -= headHorizontalAmount;
                            head.eulerAngles = new Vector3(angleX, angleY, 0);
                            gameObject.transform.position += gameObject.transform.forward * bodyAmount;
                            break;
                        case Action.LOOK_RIGHT_DOWN_WALK:
                            angleX += headVerticalAmount;
                            angleY += headHorizontalAmount;
                            head.eulerAngles = new Vector3(angleX, angleY, 0);
                            gameObject.transform.position += gameObject.transform.forward * bodyAmount;
                            break;
                        case Action.LOOK_LEFT_WALK:
                            angleY -= headHorizontalAmount;
                            head.eulerAngles = new Vector3(angleX, angleY, 0);
                            gameObject.transform.position += gameObject.transform.forward * bodyAmount;
                            break;
                        case Action.LOOK_RIGHT_WALK:
                            angleY += headHorizontalAmount;
                            head.eulerAngles = new Vector3(angleX, angleY, 0);
                            gameObject.transform.position += gameObject.transform.forward * bodyAmount;
                            break;
                        case Action.LOOK_UP_WALK:
                            angleX -= headVerticalAmount;
                            head.eulerAngles = new Vector3(angleX, angleY, 0);
                            gameObject.transform.position += gameObject.transform.forward * bodyAmount;
                            break;
                        case Action.LOOK_DOWN_WALK:
                            angleX += headVerticalAmount;
                            head.eulerAngles = new Vector3(angleX, angleY, 0);
                            gameObject.transform.position += gameObject.transform.forward * bodyAmount;
                            break;
                        case Action.SHRINK_EYES:
                            scaleY -= eyeAmount;
                            eyes.localScale = new Vector3(1, scaleY, 1);
                            break;
                        case Action.GROW_EYES:
                            scaleY += eyeAmount;
                            eyes.localScale = new Vector3(1, scaleY, 1);
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
    }

    // Misc
    public void SetAvatarVisible()
    {
        humanoid.SetActive(false);
        avatar.SetActive(true);
        SetAnimSpeed();
    }

    public void SetHumanoidVisible()
    {
        humanoid.SetActive(true);
        avatar.SetActive(false);
    }

    public void StopAction()
    {
        status = false;
        frameCount = 0;
        timer = false;
        action = Action.IDLE;
        controllerScript.SetStatus(gameObject.tag);
    }

    public void Wait(float time)
    {
        waitTime = time;
        frameCount = 2;
        action = Action.WAIT;
        waiting = false;
        timer = false;
        status = true;
    }

    // Animations
    private void SetAnimSpeed()
    {
        animController.SetFloat("walkSpeed", speedWalk);
        animController.SetFloat("startWalkSpeed", speedWalkStart);
        animController.SetFloat("stopWalkSpeed", speedWalkStop);
        animController.SetFloat("runSpeed", speedRun);
        animController.SetFloat("startRunSpeed", speedRunStart);
        animController.SetFloat("stopRunSpeed", speedRunStop);
        animController.SetFloat("turnSpeed", speedTurn);
    }

    public void StartWalk()
    {
        action = Action.ANIM;
        animController.SetTrigger(startWalkHash);
    }
    public void Walk()
    {
        action = Action.ANIM;
        animController.SetTrigger(walkHash);
    }

    public void SadIdle()
    {
        action = Action.ANIM;
        animController.Play("Base Layer.SadIdle", -1, 0);
    }

    public void SadLook()
    {
        action = Action.ANIM;
        animController.SetTrigger(sadLookHash);
    }

    public void SadWalk()
    {
        action = Action.ANIM;
        animController.Play("Base Layer.SadWalk", -1, 0);
    }

    public void StartSadWalk()
    {
        action = Action.ANIM;
        animController.SetTrigger(sadWalkHash);
    }

    public void TurnLeftWalk()
    {
        action = Action.ANIM;
        animController.SetTrigger(turnLeftHash);
    }

    public void TurnRightWalk()
    {
        action = Action.ANIM;
        animController.SetTrigger(turnRightHash);
    }

    public void StopTurn()
    {
        action = Action.ANIM;
        animController.SetTrigger(stopTurnHash);
    }

    public void StopWalking()
    {
        action = Action.ANIM;
        animController.SetTrigger(stopHash);
    }

    public void LookAround()
    {
        action = Action.ANIM;
        animController.SetTrigger(lookAroundHash);
    }

    public void LookUpwards()
    {
        action = Action.ANIM;
        animController.SetTrigger(lookUpHash);
    }

    public void RunToWalk(float speed)
    {
        action = Action.ANIM;
        slowDown = true;
        slowDownSpeed = speed;
        slowDownCur = 1;
        animController.SetFloat(runToWalkHash, 1f);
        animController.SetTrigger(walkHash);
    }

    public void Run()
    {
        action = Action.ANIM;
        animController.Play("Base Layer.Run", -1, 0.5f);
    }

    public void StartRunning()
    {
        action = Action.ANIM;
        animController.SetTrigger(runHash);
    }

    public void RunAway()
    {
        action = Action.ANIM;
        animController.SetTrigger(runAwayHash);
    }

    public void StopRunning()
    {
        action = Action.ANIM;
        animController.SetTrigger(stopHash);
    }

    // Set Transform
    public void SetPosition(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }

    public void SetRotation(Vector3 rot)
    {
        gameObject.transform.eulerAngles = rot;
    }

    public void SetHeadRotation( Vector3 rot)
    {
        head.localEulerAngles = rot;
    }

    public void SetEyeScale(Vector3 scl)
    {
        eyes.localScale = scl;
    }

    public void TurnAt(Vector3 pos)
    {
        gameObject.transform.LookAt(pos);
    }

    // Get Transform
    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }

    public Vector3 GetRotation()
    {
        return gameObject.transform.rotation.eulerAngles;
    }

    // Body Movements
    public void MoveForward(float amount, int count)
    {
        frameCount = count;
        bodyAmount = amount;
        action = Action.MOVE_FWD;
        status = true;
    }

    public void TurnLeft(float amount, int count)
    {
        frameCount = count;
        bodyAmount = amount;
        action = Action.TURN_LEFT;
        angleY = gameObject.transform.eulerAngles.y;
        status = true;
    }

    public void TurnRight(float amount, int count)
    {
        frameCount = count;
        bodyAmount = amount;
        action = Action.TURN_RIGHT;
        angleY = gameObject.transform.eulerAngles.y;
        status = true;
    }

    // Head Movements
    public void LookRightUp(float horizontalAmount, float verticalAmount, int count)
    {
        frameCount = count;
        headHorizontalAmount = horizontalAmount;
        headVerticalAmount = verticalAmount;
        action = Action.LOOK_RIGHT_UP;
        angleX = head.eulerAngles.x;
        angleY = head.eulerAngles.y;
        status = true;
    }

    public void LookLeftUp(float horizontalAmount, float verticalAmount, int count)
    {
        frameCount = count;
        headHorizontalAmount = horizontalAmount;
        headVerticalAmount = verticalAmount;
        action = Action.LOOK_LEFT_UP;
        angleX = head.eulerAngles.x;
        angleY = head.eulerAngles.y;
        status = true;
    }

    public void LookRightDown(float horizontalAmount, float verticalAmount, int count)
    {
        frameCount = count;
        headHorizontalAmount = horizontalAmount;
        headVerticalAmount = verticalAmount;
        action = Action.LOOK_RIGHT_DOWN;
        angleX = head.eulerAngles.x;
        angleY = head.eulerAngles.y;
        status = true;
    }

    public void LookLeftDown(float horizontalAmount, float verticalAmount, int count)
    {
        frameCount = count;
        headHorizontalAmount = horizontalAmount;
        headVerticalAmount = verticalAmount;
        action = Action.LOOK_LEFT_DOWN;
        angleX = head.eulerAngles.x;
        angleY = head.eulerAngles.y;
        status = true;
    }

    public void LookUp(float verticalAmount, int count)
    {
        frameCount = count;
        headVerticalAmount = verticalAmount;
        action = Action.LOOK_UP;
        angleX = head.eulerAngles.x;
        angleY = head.eulerAngles.y;
        status = true;
    }

    public void LookDown(float verticalAmount, int count)
    {
        frameCount = count;
        headVerticalAmount = verticalAmount;
        action = Action.LOOK_DOWN;
        angleX = head.eulerAngles.x;
        angleY = head.eulerAngles.y;
        status = true;
    }

    // Head + Body Movements
    public void LookLeftUpWalk(float horizontalAmount, float verticalAmount, float walkAmount, int count)
    {
        frameCount = count;
        bodyAmount = walkAmount;
        headHorizontalAmount = horizontalAmount;
        headVerticalAmount = verticalAmount;
        action = Action.LOOK_LEFT_UP_WALK;
        angleX = head.eulerAngles.x;
        angleY = head.eulerAngles.y;
        status = true;
    }

    public void LookRightUpWalk(float horizontalAmount, float verticalAmount, float walkAmount, int count)
    {
        frameCount = count;
        bodyAmount = walkAmount;
        headHorizontalAmount = horizontalAmount;
        headVerticalAmount = verticalAmount;
        action = Action.LOOK_RIGHT_UP_WALK;
        angleX = head.eulerAngles.x;
        angleY = head.eulerAngles.y;
        status = true;
    }

    public void LookLeftDownWalk(float horizontalAmount, float verticalAmount, float walkAmount, int count)
    {
        frameCount = count;
        bodyAmount = walkAmount;
        headHorizontalAmount = horizontalAmount;
        headVerticalAmount = verticalAmount;
        action = Action.LOOK_LEFT_DOWN_WALK;
        angleX = head.eulerAngles.x;
        angleY = head.eulerAngles.y;
        status = true;
    }
    public void LookRightDownWalk(float horizontalAmount, float verticalAmount, float walkAmount, int count)
    {
        frameCount = count;
        bodyAmount = walkAmount;
        headHorizontalAmount = horizontalAmount;
        headVerticalAmount = verticalAmount;
        action = Action.LOOK_RIGHT_DOWN_WALK;
        angleX = head.eulerAngles.x;
        angleY = head.eulerAngles.y;
        status = true;
    }
    public void LookLeftWalk(float horizontalAmount, float walkAmount, int count)
    {
        frameCount = count;
        bodyAmount = walkAmount;
        headHorizontalAmount = horizontalAmount;
        action = Action.LOOK_LEFT_WALK;
        angleX = head.eulerAngles.x;
        angleY = head.eulerAngles.y;
        status = true;
    }
    public void LookRightWalk(float horizontalAmount, float walkAmount, int count)
    {
        frameCount = count;
        bodyAmount = walkAmount;
        headHorizontalAmount = horizontalAmount;
        action = Action.LOOK_RIGHT_WALK;
        angleX = head.eulerAngles.x;
        angleY = head.eulerAngles.y;
        status = true;
    }

    public void LookUpWalk(float verticalAmount, float walkAmount, int count)
    {
        frameCount = count;
        bodyAmount = walkAmount;
        headVerticalAmount = verticalAmount;
        action = Action.LOOK_UP_WALK;
        angleX = head.eulerAngles.x;
        angleY = head.eulerAngles.y;
        status = true;
    }

    public void LookDownWalk(float verticalAmount, float walkAmount, int count)
    {
        frameCount = count;
        bodyAmount = walkAmount;
        headVerticalAmount = verticalAmount;
        action = Action.LOOK_DOWN_WALK;
        angleX = head.eulerAngles.x;
        angleY = head.eulerAngles.y;
        status = true;
    }
    // eye movements
    public void ShrinkEyes(float amount, int count)
    {
        eyeAmount = amount;
        frameCount = count;
        action = Action.SHRINK_EYES;
        scaleY = eyes.localScale.y;
        status = true;
    }
    public void GrowEyes(float amount, int count)
    {
        eyeAmount = amount;
        frameCount = count;
        action = Action.GROW_EYES;
        scaleY = eyes.localScale.y;
        status = true;
    }

    // privates
    private void SetStartTransform()
    {
        Transform doorTransform = GameObject.FindWithTag("door").transform;
        float startPosX = doorTransform.position.x - (float)1.3;
        float startPosY = 0;
        float startPosZ = doorTransform.position.z + (float)1.15;
        float startAngleY = 145;
        gameObject.transform.position = new Vector3(startPosX, startPosY, startPosZ);
        gameObject.transform.eulerAngles = new Vector3(0, startAngleY, 0);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        timer = true;
    }
}

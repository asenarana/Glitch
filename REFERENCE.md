# Glitch

### Animation
- [Blinking Light Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#blinking-light-script)
- [Camera Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#camera-script)
- [Death Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#death-script)
- [Door Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#door-script)
- [Eye Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#eye-script)
- [Islander Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#islander-script)
- [Jumper Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#jumper-script)
- [Lamp Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#lamp-script)
- [Player Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#player-script)
- [Screen Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#screen-script)
- [Sliding Door Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#sliding-door-script)
- [Swinger Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#swinger-script)

### Model
- [Capture Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#capture-script)
- [Mesh Combiner](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#mesh-combiner)
- [Mesh Combiner Editor](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#mesh-combiner-editor)

#
# Blinking Light Script
### public void Blink(float time, int count);

#
# Camera Script

### public void RotateDown(float amount, int count);
### public void RotateLeft(float amount, int count);
### public Vector3 GetPosition();
### public void SetPosition(Vector3 pos);
### public Vector3 GetRotation();
### public void SetRotation(Vector3 rot);

#
# Death Script
### public void Die();
### public void SetDead();

#
# Door Script
### public void OpenDoor( float amount, int count);
### public void CloseDoor(float amount, int count);

#
# Eye Script
### public void OpenEyes();
### public void CloseEyes();

#
# Islander Script
### public void SetPosition(Vector3 pos);
### public Vector3 GetPosition();
### public void SetRotation(Vector3 rot);
### public Vector3 GetRotation();
### public void Sit();

#
# Jumper Script
### public void SetPosition(Vector3 pos);
### public Vector3 GetPosition();
### public void SetRotation(Vector3 rot);
### public Vector3 GetRotation();
### public void Fall(float distance, int count);
### public void Impact(bool flail);

#
# Lamp Script
### public void TurnOff();
### public void TurnOn();

#
# Player Script
### public void SetAvatarVisible();
### public void SetHumanoidVisible();
### public void SetPosition(Vector3 pos);
### public Vector3 GetPosition();
### public void SetRotation(Vector3 rot);
### public Vector3 GetRotation();
### public void TurnAt(Vector3 pos);
### public void Wait(float time);
### public void MoveForward(float amount, int count);
### public void TurnLeft(float amount, int count);
### public void TurnRight(float amount, int count);

## Humanoid Functions
### public void StopAction();
### public void SetHeadRotation( Vector3 rot);
### public void SetEyeScale(Vector3 scl);
### public void LookRightUp(float horizontalAmount, float verticalAmount, int count);
### public void LookLeftUp(float horizontalAmount, float verticalAmount, int count);
### public void LookRightDown(float horizontalAmount, float verticalAmount, int count);
### public void LookLeftDown(float horizontalAmount, float verticalAmount, int count);
### public void LookUp(float verticalAmount, int count);
### public void LookDown(float verticalAmount, int count);
### public void LookLeftUpWalk(float horizontalAmount, float verticalAmount, float walkAmount, int count);
### public void LookRightUpWalk(float horizontalAmount, float verticalAmount, float walkAmount, int count);
### public void LookLeftDownWalk(float horizontalAmount, float verticalAmount, float walkAmount, int count);
### public void LookRightDownWalk(float horizontalAmount, float verticalAmount, float walkAmount, int count);
### public void LookLeftWalk(float horizontalAmount, float walkAmount, int count);
### public void LookRightWalk(float horizontalAmount, float walkAmount, int count);
### public void LookUpWalk(float verticalAmount, float walkAmount, int count);
### public void LookDownWalk(float verticalAmount, float walkAmount, int count);
### public void ShrinkEyes(float amount, int count);
### public void GrowEyes(float amount, int count);

## Avatar Functions
### public void RunToWalk(float speed);
### public void StartWalk();
### public void Walk();
### public void SadIdle();
### public void SadLook();
### public void SadWalk();
### public void StartSadWalk();
### public void TurnLeftWalk();
### public void TurnRightWalk();
### public void StopTurn();
### public void StopWalking();
### public void LookAround();
### public void LookUpwards();
### public void Run();
### public void StartRunning();
### public void RunAway();
### public void StopRunning();

#
# Screen Script
### public void ShowFeed();

#
# Sliding Door Script
### public void Open(float amount, int count);
### public void Close(float amount, int count);

#
# Swinger Script
### public void SetSwingAngle(float angle);
### public void Swing(float totalAngle, float rate, int count, bool control);
### public void StopAction();

# 
# Capture Script
### public void Capture(string name);

#
# Mesh Combiner
### public void CombineMeshBasic();
### public void CombineMeshAdvanced();
### public void SaveMesh();

#
# Mesh Combiner Editor
### public override void OnInspectorGUI();

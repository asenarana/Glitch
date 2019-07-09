# Glitch

- [Blinking Light Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#blinking-light-script)
- [Camera Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#camera-script)
- [Door Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#door-script)
- [Eye Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#eye-script)
- [Lamp Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#lamp-script)
- [Player Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#player-script)
- [Screen Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#screen-script)
- [Sliding Door Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#sliding-door-script)
- [Swinger Script](https://github.com/asenarana/Glitch/blob/master/REFERENCE.md#swinger-script)


# Blinking Light Script
### public void Blink(float time, int count);
__time:__ waiting time between the light switches in seconds

__count:__ number of switches

Activates and deactivates the "Light" object.
It calls the SetStatus() function of the ControllerScript when the action is done.

# Camera Script

### public void RotateDown(float amount, int count);
__amount:__ amount to rotate in each frame given as euler angles

__count:__ number of frames to perfom the action

Rotates the camera downwards.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void RotateLeft(float amount, int count);
__amount:__ amount to rotate in each frame given as euler angles

__count:__ number of frames to perfom the action

Rotates the camera to left.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public Vector3 GetPosition();
Returns the position of the camera object relative to the world.

### public void SetPosition(Vector3 pos);
__pos:__ desired position to set to the object.

Sets the position of the camera object relative to the world.

### public Vector3 GetRotation();
Returns the rotation of the camera object as euler angles.

### public void SetRotation(Vector3 rot)
__rot:__ desired rotation to set to the object

Sets the rotation of the camera object as euler angles.

# Door Script
Script must be attached to the pivot object.
### public void OpenDoor( float amount, int count);
__amount:__ amount to rotate in each frame given as euler angles

__count:__ number of frames to perfom the action

Rotates the door object on the y-axis in positive direction.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void CloseDoor(float amount, int count);
__amount:__ amount to rotate in each frame given as euler angles

__count:__ number of frames to perfom the action

Rotates the door object on the y-axis in negative direction.
It calls the SetStatus() function of the ControllerScript when the action is done.


# Eye Script
### public void OpenEyes();
Changes the material of the eye objects in order to create the illusion of open eyes.

### public void CloseEyes();
Changes the material of the eye objects in order to create the illusion of closed eyes.


# Lamp Script
### public void TurnOff();
Changes the material of the lamp object in order to turn the light off.

### public void TurnOn();
Changes the material of the lamp object in order to turn the light on.

# Player Script
Player object has two child objects called Avatar and Humanoid. Avatar object is the rigged version of the Humanoid object.
### public void SetAvatarVisible();
Activates the Avatar object and deactivates the Humanoid object.

### public void SetHumanoidVisible();
Activates the Humanoid object and deactivates the Avatar object.

### public void SetPosition(Vector3 pos);
__pos:__ desired position to set to the object.

Sets the position of the player object relative to the world.

### public Vector3 GetPosition();
Returns the position of the player object relative to the world.

### public void SetRotation(Vector3 rot);
__rot:__ desired rotation to set to the object

Sets the rotation of the player object as euler angles.

### public Vector3 GetRotation();
Returns the rotation of the player object as euler angles.

### public void TurnAt(Vector3 pos);
__pos:__ desired position to face the object

Rotates the player object to look at the given position.

### public void Wait(float time);
__time:__ amount to wait in seconds

Waits for the given time and calls the SetStatus() function of the ControllerScript.

### public void MoveForward(float amount, int count);
__amount:__ amount to move in each frame given as positional difference

__count:__ number of frames to perfom the action

Moves the object in the forward direction relative to the object itself.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void TurnLeft(float amount, int count);
__amount:__ amount to rotate in each frame given as euler angles

__count:__ number of frames to perfom the action

Rotates the object to the left.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void TurnRight(float amount, int count);
__amount:__ amount to rotate in each frame given as euler angles

__count:__ number of frames to perfom the action

Rotates the object to the right.
It calls the SetStatus() function of the ControllerScript when the action is done.


## Humanoid Functions
These functions are intended to work when the Humanoid object is active only.
### public void StopAction();
Sets the object state to IDLE and calls the SetStatus() function of the ControllerScript.

### public void SetHeadRotation( Vector3 rot);
__rot:__ desired rotation to set to the head pivot object.

Sets the rotation of the head object as euler angles.

### public void SetEyeScale(Vector3 scl);

__scl:__ desired scale to set to the eyes object

Sets the scale of the eyes object.

### public void LookRightUp(float horizontalAmount, float verticalAmount, int count);
__horizontalAmount:__ amount to rotate the head object on the y-axis in each frame given as euler angles

__verticalAmount:__ amount to rotate the head object on the x-axis in each frame given as euler angles

__count:__ number of frames to perfom the action

Rotates the head object on x-axis in negative direction and on y-axis in positive direction.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void LookLeftUp(float horizontalAmount, float verticalAmount, int count);
__horizontalAmount:__ amount to rotate the head object on the y-axis in each frame given as euler angles

__verticalAmount:__ amount to rotate the head object on the x-axis in each frame given as euler angles

__count:__ number of frames to perfom the action

Rotates the head object on x-axis in negative direction and on y-axis in negative direction.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void LookRightDown(float horizontalAmount, float verticalAmount, int count);
__horizontalAmount:__ amount to rotate the head object on the y-axis in each frame given as euler angles

__verticalAmount:__ amount to rotate the head object on the x-axis in each frame given as euler angles

__count:__ number of frames to perfom the action

Rotates the head object on x-axis in positive direction and on y-axis in positive direction.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void LookLeftDown(float horizontalAmount, float verticalAmount, int count);
__horizontalAmount:__ amount to rotate the head object on the y-axis in each frame given as euler angles

__verticalAmount:__ amount to rotate the head object on the x-axis in each frame given as euler angles

__count:__ number of frames to perfom the action

Rotates the head object on x-axis in positive direction and on y-axis in negative direction.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void LookUp(float verticalAmount, int count);
__verticalAmount:__ amount to rotate the head object on the x-axis in each frame given as euler angles

__count:__ number of frames to perfom the action

Rotates the head object on x-axis in negative direction.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void LookDown(float verticalAmount, int count);
__verticalAmount:__ amount to rotate the head object on the x-axis in each frame given as euler angles

__count:__ number of frames to perfom the action

Rotates the head object on x-axis in positive direction.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void LookLeftUpWalk(float horizontalAmount, float verticalAmount, float walkAmount, int count);
__horizontalAmount:__ amount to rotate the head object on the y-axis in each frame given as euler angles

__verticalAmount:__ amount to rotate the head object on the x-axis in each frame given as euler angles

__walkAmount:__ amount to move the player object in each frame given as positional difference

__count:__ number of frames to perfom the action

Rotates the head object on x-axis in negative direction and on y-axis in negative direction, while moving the player object in the forward direction relative to the object itself.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void LookRightUpWalk(float horizontalAmount, float verticalAmount, float walkAmount, int count);
__horizontalAmount:__ amount to rotate the head object on the y-axis in each frame given as euler angles

__verticalAmount:__ amount to rotate the head object on the x-axis in each frame given as euler angles

__walkAmount:__ amount to move the player object in each frame given as positional difference

__count:__ number of frames to perfom the action

Rotates the head object on x-axis in negative direction and on y-axis in positive direction, while moving the player object in the forward direction relative to the object itself.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void LookLeftDownWalk(float horizontalAmount, float verticalAmount, float walkAmount, int count);
__horizontalAmount:__ amount to rotate the head object on the y-axis in each frame given as euler angles

__verticalAmount:__ amount to rotate the head object on the x-axis in each frame given as euler angles

__walkAmount:__ amount to move the player object in each frame given as positional difference

__count:__ number of frames to perfom the action

Rotates the head object on x-axis in positive direction and on y-axis in negative direction, while moving the player object in the forward direction relative to the object itself.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void LookRightDownWalk(float horizontalAmount, float verticalAmount, float walkAmount, int count);
__horizontalAmount:__ amount to rotate the head object on the y-axis in each frame given as euler angles

__verticalAmount:__ amount to rotate the head object on the x-axis in each frame given as euler angles

__walkAmount:__ amount to move the player object in each frame given as positional difference

__count:__ number of frames to perfom the action

Rotates the head object on x-axis in positive direction and on y-axis in positive direction, while moving the player object in the forward direction relative to the object itself.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void LookLeftWalk(float horizontalAmount, float walkAmount, int count);
__horizontalAmount:__ amount to rotate the head object on the y-axis in each frame given as euler angles

__walkAmount:__ amount to move the player object in each frame given as positional difference

__count:__ number of frames to perfom the action

Rotates the head object on y-axis in negative direction, while moving the player object in the forward direction relative to the object itself.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void LookRightWalk(float horizontalAmount, float walkAmount, int count);
__horizontalAmount:__ amount to rotate the head object on the y-axis in each frame given as euler angles

__walkAmount:__ amount to move the player object in each frame given as positional difference

__count:__ number of frames to perfom the action

Rotates the head object on y-axis in positive direction, while moving the player object in the forward direction relative to the object itself.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void LookUpWalk(float verticalAmount, float walkAmount, int count);
__verticalAmount:__ amount to rotate the head object on the x-axis in each frame given as euler angles

__walkAmount:__ amount to move the player object in each frame given as positional difference

__count:__ number of frames to perfom the action

Rotates the head object on x-axis in negative direction, while moving the player object in the forward direction relative to the object itself.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void LookDownWalk(float verticalAmount, float walkAmount, int count);
__verticalAmount:__ amount to rotate the head object on the x-axis in each frame given as euler angles

__walkAmount:__ amount to move the player object in each frame given as positional difference

__count:__ number of frames to perfom the action

Rotates the head object on x-axis in positive direction, while moving the player object in the forward direction relative to the object itself.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void ShrinkEyes(float amount, int count);
__amount:__ amount to scale down the eyes object

__count:__ number of frames to perfom the action

Decreases the scale of the eyes object on y-axis.
It calls the SetStatus() function of the ControllerScript when the action is done.

### public void GrowEyes(float amount, int count);
__amount:__ amount to scale up the eyes object

__count:__ number of frames to perfom the action

Increases the scale of the eyes object on y-axis.
It calls the SetStatus() function of the ControllerScript when the action is done.


## Avatar Functions
These functions are intended to work when the Avatar object is active only.
### public void RunToWalk(float speed);
__speed:__ amount to slow down in each frame

Triggers the corresponding parameters of the Animator in order to play the animation.
Additionally, reduces the speed of the animation continuously until the speed is zero. It calls the SetStatus() function of the ControllerScript when the speed is less than or equal to zero.

### public void StartWalk();
Triggers the corresponding parameters of the Animator in order to play the animation.

### public void Walk();
Triggers the corresponding parameters of the Animator in order to play the animation.

### public void SadIdle();
Triggers the corresponding parameters of the Animator in order to play the animation.

### public void SadLook();
Triggers the corresponding parameters of the Animator in order to play the animation.

### public void SadWalk();
Triggers the corresponding parameters of the Animator in order to play the animation.

### public void StartSadWalk();
Triggers the corresponding parameters of the Animator in order to play the animation.

### public void TurnLeftWalk();
Triggers the corresponding parameters of the Animator in order to play the animation.

### public void TurnRightWalk();
Triggers the corresponding parameters of the Animator in order to play the animation.

### public void StopTurn();
Triggers the corresponding parameters of the Animator in order to play the animation.

### public void StopWalking();
Triggers the corresponding parameters of the Animator in order to play the animation.

### public void LookAround();
Triggers the corresponding parameters of the Animator in order to play the animation.

### public void LookUpwards();
Triggers the corresponding parameters of the Animator in order to play the animation.

### public void Run();
Triggers the corresponding parameters of the Animator in order to play the animation.

### public void StartRunning();
Triggers the corresponding parameters of the Animator in order to play the animation.

### public void RunAway();
Triggers the corresponding parameters of the Animator in order to play the animation.

### public void StopRunning();
Triggers the corresponding parameters of the Animator in order to play the animation.


# Screen Script
### public void ShowFeed();
Changes the material of the screen object continuously in order to create the illusion of showing a video on the screen.
It calls the SetStatus() function of the ControllerScript when the pre-set materials are all shown.

# Sliding Door Script
### public void Open(float amount, int count);
__amount:__ amount to move in each frame given as positional difference

__count:__ number of frames to perfom the action

Moves the door objects on the x-axis in opposing directions away from each other.

### public void Close(float amount, int count);
__amount:__ amount to move in each frame given as positional difference

__count:__ number of frames to perfom the action

Moves the door objects on the x-axis in opposing directions towards each other.

# Swinger Script
### public void SetSwingAngle(float angle);
__angle:__ desired angle to start swinging at

Sets the initial angle to start swinging.

### public void Swing(float totalAngle, float rate, int count, bool control);
__totalAngle:__ the angle which the direction of swinging changes

__rate:__ amount of angle to rotate in each frame given as euler angles

__count:__ number of frames to perfom the action

__control:__ if true, starting angle is __totalAngle__; if false, it is __(-1 * totalAngle)__

Rotates the object in x-axis in order to create the illusion of swinging. 
It calls the SetStatus() function of the ControllerScript when the action is done.

This function can be modified to change the speed of rotation continuously in order to create a more smooth and realistic swinging effect.

### public void StopAction();
Sets the object state to IDLE and calls the SetStatus() function of the ControllerScript.

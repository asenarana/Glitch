# Glitch
C# scripts of the short animation film "Glitch".

- [Blinking Light Script](https://github.com/asenarana/Glitch#blinking-light-script)
- [Camera Script](https://github.com/asenarana/Glitch#camera-script)
- [Door Script](https://github.com/asenarana/Glitch#door-script)
- [Eye Script](https://github.com/asenarana/Glitch#eye-script)


## TODO
Will add scripts as soon as possible.
### main scripts
- ControllerScript
- HangerScript
- SlidingDoorScript
- IslanderScript
- JumperScript
- LampScript
- PlayerScript
- ScreenScript
### extras
- CapturerScript
- CaptureScript
- MeshCombineEditor
- MeshCombiner
- DeathScript

### NOTE
This project was completed in a 10-week duration. Efficiency of the code was not a concern. Due to this, the code provided here can be made more efficient.


## Blinking Light Script
### public void Blink(float time, int count);
__time:__ waiting time between the light switches in seconds

__count:__ number of switches

Activates and deactivates the "Light" object.
It calls the SetStatus() function of the ControllerScript when the blinking is done.

## Camera Script

### public void RotateDown(float amount, int count);
__amount:__ amount to rotate in each frame given as euler angles

__count:__ number of frames to perfom rotation

Rotates the camera downwards.
It calls the SetStatus() function of the ControllerScript when the rotation is done.

### public void RotateLeft(float amount, int count);
__amount:__ amount to rotate in each frame given as euler angles

__count:__ number of frames to perfom rotation

Rotates the camera to left.
It calls the SetStatus() function of the ControllerScript when the rotation is done.

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

## Door Script
Script must be attached to the pivot object.
### public void OpenDoor( float amount, int count);
__amount:__ amount to rotate in each frame given as euler angles

__count:__ number of frames to perfom rotation

Rotates the door object on the y-axis in positive direction.
It calls the SetStatus() function of the ControllerScript when the rotation is done.

### public void CloseDoor(float amount, int count);
__amount:__ amount to rotate in each frame given as euler angles

__count:__ number of frames to perfom rotation

Rotates the door object on the y-axis in negative direction.
It calls the SetStatus() function of the ControllerScript when the rotation is done.


## Eye Script
### public void OpenEyes();
Changes the material of the eye objects in order to create the illusion of open eyes.

### public void CloseEyes();
Changes the material of the eye objects in order to create the illusion of closed eyes.

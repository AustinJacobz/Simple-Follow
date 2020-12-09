//Thank you for using Simple-Follow!
//https://github.com/AustinJacobz/Simple-Follow/

using System;
using System.Collections;
using UnityEngine;


[Serializable]
public enum UpdateMethod
{
    PhysicsUpdate,
    FrameUpdate,
    LateUpdate
}

public class Simple_Follow : MonoBehaviour
{
    public Transform target; //Target you want to track.

    public Vector3 offset; //Offset between Object and Target.
    
    [SerializeField] float smoothAmount = 0.2f; //Smooth Speed.

    public UpdateMethod smoothOnTick; //Which Update type to smooth objects on.

    private Vector3 velocity; //Current velocity calculated on UpdateMethod.

    private Vector3 lastPos;
    private Vector3 currentPos;

    private void SmoothPos()
    {
        currentPos = target.position;
        velocity = lastPos - currentPos; //Gets Velocity
        Vector3 localTarget = target.position + offset; //Position to smooth to.
        transform.position = Vector3.SmoothDamp(transform.position, localTarget, ref velocity, smoothAmount); //Smoothing to position.
        lastPos = currentPos; //Resets last position.
    }

    private void FixedUpdate() //Physics Update.
    {
        if (smoothOnTick == UpdateMethod.PhysicsUpdate)
        {
            SmoothPos();
        }
    }
    private void Update() //Graphics Update.
    {
        if (smoothOnTick == UpdateMethod.FrameUpdate)
        {
            SmoothPos();
        }
    }
    private void LateUpdate() //Late Update.
    {
        if (smoothOnTick == UpdateMethod.LateUpdate)
        {
            SmoothPos();
        }
    }
}

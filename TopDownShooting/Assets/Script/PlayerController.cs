using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Vector3 mVelocity;
    Rigidbody mRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 velocity)
    {
        mVelocity = velocity;
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 eyeLevelPosition = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(eyeLevelPosition);
    }

    public void FixedUpdate()
    {
        Vector3 nextPosition = mRigidbody.position + mVelocity * Time.fixedDeltaTime;
        mRigidbody.MovePosition(nextPosition);
    }
}

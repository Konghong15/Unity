using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : MonoBehaviour
{
    public float mMoveSpeed = 5;
    PlayerController mController;
    GunController mGunController;
    Camera mViewCamera;

    void Start()
    {
        mController = GetComponent<PlayerController>();
        mGunController = GetComponent<GunController>();
        mViewCamera = Camera.main;
    }

    void Update()
    {
        // Movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * mMoveSpeed;
        mController.Move(moveVelocity);

        // Look input
        Ray ray = mViewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            // Debug.DrawLine(ray.origin, point, Color.red);
            mController.LookAt(point);
        }

        // Weapon input
        if (Input.GetMouseButton(0))
        {
            mGunController.Shoot();
        }
    }
}

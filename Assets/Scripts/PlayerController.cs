using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Kapcsolodo tutorial: https://youtu.be/4HpC--2iowE
public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6;
    public Transform GFX;
    public float turnSmoothTime = 0.1f;
    public Transform cam;

    float turnSmoothVelocity;
    bool canCameraTurn = true;

    void Update()
    {
        float turnCam = Input.GetAxisRaw("Turn Camera");
        if (turnCam != 0)
        {
            if (canCameraTurn)
            {
                transform.Rotate(Vector3.up, 90 * turnCam);
                canCameraTurn = false;
            }
        }
        else canCameraTurn = true;


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(GFX.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            GFX.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed;
    public Transform Marionette;

    Vector3 moveDiraction = new Vector3();
    bool canCameraTurn= true;

    void Start()
    {
        
    }

    void Update()
    {
        moveDiraction.x = Input.GetAxis("left_right");
        moveDiraction.z = Input.GetAxis("back_forward");
        moveDiraction.Normalize();
        //Debug.Log("moveDiraction " + moveDiraction);

        float turn = Input.GetAxis("turn_camera");
        Debug.Log("turn:" + turn);
        if (canCameraTurn){
            if (turn < -0.9f) {
                transform.Rotate(Vector3.up, -90);
                canCameraTurn = false;
            }
            if (turn > 0.9f) {
                transform.Rotate(Vector3.up, 90);
                canCameraTurn = false;
            }
        } else {
            if (turn > -0.1 && turn < 0.1) canCameraTurn = true;
        }

        if (moveDiraction != Vector3.zero) {
            Marionette.LookAt(transform.position + 10 * moveDiraction + 33 * Vector3.up);
            
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(speed * moveDiraction);
    }
}

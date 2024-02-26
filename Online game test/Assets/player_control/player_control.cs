using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{/*
   

    void Update()
    {


        
        

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //transform.Rotate(Vector3.up, mouseX * rotationSpeed);
        
        verticalRotation -= mouseY * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        transform.localEulerAngles = new Vector3(verticalRotation, transform.localEulerAngles.y, 0f);

        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        controlledObject.transform.Rotate(Vector3.up, mouseX * rotationSpeed);
        controlledObject.transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self);

/*
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPosition = touch.position;
                isRotating = true;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isRotating = false;
            }
            else if (touch.phase == TouchPhase.Moved && isRotating)
            {
                Vector2 deltaPosition = touch.position - lastTouchPosition;
                transform.Rotate(Vector3.up, deltaPosition.x * rotationSpeed * Time.deltaTime);
                lastTouchPosition = touch.position;
            }
        }*/

    }/*
    void FixedUpdate()
    {
        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity = moveDirection * moveSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    */


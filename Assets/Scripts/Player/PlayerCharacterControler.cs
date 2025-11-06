using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCharacterControler : MonoBehaviour
{
    public float playerCharacter_WalkSpeed;
    public float playerCharacter_RunSpeed;

    public float mouseSensitivity = 100f;

    public Camera mainCamera;
    public Animator playeranimator;

    private float xRotation = 0f;

    // Update is called once per frame
    void Update()
    {
        MouseLook();
        KeybordMove();
    }

    void MouseLook()
    {
        if( mainCamera == null) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }

    void KeybordMove()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        float playerWalkOrRun = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? playerCharacter_RunSpeed : playerCharacter_WalkSpeed;

        Vector3 plyaerDerection = transform.right * HorizontalInput + transform.forward * VerticalInput;

        Vector3 playermove = plyaerDerection * playerCharacter_WalkSpeed * Time.deltaTime;
        transform.position += playermove;
    }
}

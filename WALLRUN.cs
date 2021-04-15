using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class WALLRUN : MonoBehaviour
{
    bool IsWallRunning;

    bool WallOnLeft;
    bool WallOnRight;

    public Transform Orentation;
    public LayerMask Wallrunable;
    public float WallRunSpeed;
    public float WallSwitchStrength;
    public float WallStickStrength;
    public float Reach;
    public Rigidbody rb;

    void Update()
    {
        CheckForWR();
        WallRunInput();
        

        rb = GetComponent<Rigidbody>();
    }

    private void CheckForWR()
    {
        WallOnLeft = Physics.Raycast(transform.position, Orentation.right, Reach, Wallrunable);
        WallOnRight = Physics.Raycast(transform.position, -Orentation.right, Reach, Wallrunable);
        if (!WallOnLeft && !WallOnRight) StopWR();
        if (WallOnLeft) StartWR();

        if (WallOnRight) StartWR();

    }

    private void WallRunInput()
    {
        if (WallOnLeft) StartWR();

        if (WallOnRight) StartWR();
        
    }

    private void StopWR()
    {
        IsWallRunning = false;
        rb.useGravity = true;
    }

    private void StartWR()
    {


        
        rb.useGravity = false;
        IsWallRunning = true;
        rb.AddForce(Orentation.forward * WallRunSpeed * Time.deltaTime);

        if (WallOnRight)
        {
            rb.AddForce(Orentation.right * WallSwitchStrength / 5 * Time.deltaTime);
        }
        if (WallOnLeft)
        {
            rb.AddForce(-Orentation.right * WallSwitchStrength / 5 * Time.deltaTime);
        }
        else if (!WallOnLeft)
        {
            StopWR();
        }
        else if (!WallOnRight)
        {
            StopWR();
        }



    }

}
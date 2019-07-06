using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{

    private Animator myAnimator;

    private Rigidbody myRidgebody;

    private float forwardForce = 800.0f;

    void Start()
    {
        this.myAnimator = GetComponent<Animator>();
        this.myAnimator.SetFloat("Speed", 1);

        this.myRidgebody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        this.myRidgebody.AddForce(this.transform.forward * this.forwardForce);

    }
}

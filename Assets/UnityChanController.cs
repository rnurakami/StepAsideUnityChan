using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{

    private Animator myAnimator;

    private Rigidbody myRidgebody;

    private float forwardForce = 800.0f;

    private float turnForce = 500.0f;

    private float movableRange = 3.4f;

    void Start()
    {
        this.myAnimator = GetComponent<Animator>();
        this.myAnimator.SetFloat("Speed", 1);

        this.myRidgebody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        this.myRidgebody.AddForce(this.transform.forward * this.forwardForce);

        if (Input.GetKey(KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x)
        {
            this.myRidgebody.AddForce(-this.turnForce, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.movableRange > this.transform.position.x)
        {
            this.myRidgebody.AddForce(this.turnForce, 0, 0);
        }

    }
}

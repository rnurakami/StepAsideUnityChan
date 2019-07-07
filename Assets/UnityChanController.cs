using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{

    private Animator myAnimator;

    private Rigidbody myRidgebody;

    private float forwardForce = 800.0f;

    private float turnForce = 500.0f;

    private float upForce = 500.0f;

    private float movableRange = 3.4f;

    private float coefficent = 0.95f;

    private bool isEnd = false;


    void Start()
    {
        this.myAnimator = GetComponent<Animator>();
        this.myAnimator.SetFloat("Speed", 1);

        this.myRidgebody = GetComponent<Rigidbody>();

    }

    void Update()
    {

        if (this.isEnd)
        {
            this.forwardForce *= this.coefficent;
            this.turnForce *= this.coefficent;
            this.upForce *= this.coefficent;
            this.myAnimator.speed *= this.coefficent;
        }
        
        this.myRidgebody.AddForce(this.transform.forward * this.forwardForce);

        if (Input.GetKey(KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x)
        {
            this.myRidgebody.AddForce(-this.turnForce, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.movableRange > this.transform.position.x)
        {
            this.myRidgebody.AddForce(this.turnForce, 0, 0);
        }

        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f)
        {
            this.myAnimator.SetBool("Jump", true);
            this.myRidgebody.AddForce(this.transform.up * this.upForce);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarTag" ||
            other.gameObject.tag == "TrafficConeTag")
        {
            this.isEnd = true;
        }

        if (other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
        }

        if (other.gameObject.tag == "CoinTag")
        {
            Destroy(other.gameObject);
        }
    }
}

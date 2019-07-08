using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{

    private GameObject unitychan;

    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
    }

    void Update()
    {
        if( this.transform.position.z + 3 < unitychan.transform.position.z)
        {
            Destroy(this.gameObject);
        }

    }
}

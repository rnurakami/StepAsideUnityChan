using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;

    private int startPos = -160;
    private int goalPos = 120;

    private float posRange = 3.4f;

    private GameObject unitychan;

    private int alreadyCreatedLine_z = 0;

    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
    }

    void Update()
    {
        int targetLine_z = (int) unitychan.transform.position.z + 50;

        if (targetLine_z == alreadyCreatedLine_z)
        {
            return;
        }

        if (startPos < targetLine_z && targetLine_z < goalPos && targetLine_z % 15 == 0)
        {
            CreateObstaclesLine(targetLine_z);
        }

        alreadyCreatedLine_z = targetLine_z;
    }

    void CreateObstaclesLine(int z)
    {
        int num = Random.Range(1, 11);
        if (num <= 2)
        {
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab) as GameObject;
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, z);
            }
        }
        else
        {
            for (int j = -1; j <= 1; j++)
            {
                int item = Random.Range(1, 11);
                int offsetZ = Random.Range(-5, 6);
                if (1 <= item && item <= 6)
                {
                    GameObject coin = Instantiate(coinPrefab) as GameObject;
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, z + offsetZ);
                }
                else if (7 <= item && item <= 9)
                {
                    GameObject car = Instantiate(carPrefab) as GameObject;
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, z + offsetZ);
                }
            }
        }
    }
}

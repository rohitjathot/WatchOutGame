using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour {
    
    public float speed = 0.5f;
    public GameObject[] enemy;
    public float frequency=0.5f;
    float counter = 0.0f;
    public Transform challangeSpawnPoint;

	// Use this for initialization
	void Start () {
        GenerateRandmChallenge();
	}
	
	// Update is called once per frame
	void Update () {

        if (counter <= 0.0)
        {
            GenerateRandmChallenge();
        }else
        {
            counter -= Time.deltaTime * frequency;
        }

        for(int i = 0; i < transform.childCount; i++)
        {
            moveLeft(transform.GetChild(i).gameObject);
        }

	}

    void moveLeft(GameObject gameObject)
    {
        gameObject.transform.position  -= Vector3.right * speed * Time.deltaTime;
        if (gameObject.transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }

    void GenerateRandmChallenge()
    {
        GameObject newEnemy = Instantiate(enemy[Random.Range(0, enemy.Length)], challangeSpawnPoint.position, Quaternion.identity) as GameObject;
        newEnemy.transform.parent = transform;
        counter = 1.0f;
    }

}

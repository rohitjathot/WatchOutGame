using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJump : MonoBehaviour {

    public float jumpForce = 0.5f;
    public GameObject panel;
    Rigidbody2D myRigidBody;
    bool isGrounded = false;
    float postion=0.0f;

	// Use this for initialization
	void Start () {
        myRigidBody = transform.GetComponent<Rigidbody2D>();
        postion = transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            if(isGrounded)
            myRigidBody.AddForce(Vector3.up * jumpForce * myRigidBody.mass * myRigidBody.gravityScale * 20.0f);
        }

        if(transform.position.x < postion)
        {
            GameOver();
        }

	}

   public void GameOver()
    {

        //over.SetGameOver();
        panel.SetActive(true);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "stage")
        {
            isGrounded=true;
        }
        if (collision.collider.tag == "spike")
        {
            GameOver();
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "stage")
        {
            isGrounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "stage")
        {
            isGrounded = true;
        }
    }

}

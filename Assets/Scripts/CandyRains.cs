using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyRains : MonoBehaviour
{

    private Rigidbody2D candyRigidBody;
    public float candyVelocity;
    private float candyRandomDirection;

    // Start is called before the first frame update
    void Start()
    {
        candyRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            throwCandy();
        }



    }


    void createCandy()
    {

    }

    void throwCandy()
    {
        candyVelocity = Random.Range(10f, 20f);
        candyRigidBody.AddForce(transform.up * candyVelocity, ForceMode2D.Impulse);
        candyVelocity = Random.Range(20f, 40f);
        candyRandomDirection = Random.Range(-1f, 1f);
        candyRigidBody.AddForce(transform.right * candyVelocity*candyRandomDirection, ForceMode2D.Impulse);

    }

}

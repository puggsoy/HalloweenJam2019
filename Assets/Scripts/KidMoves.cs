using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidMoves : MonoBehaviour
{
    public float kidMoveSpeed;
    private Rigidbody kidRigidBody;
    private Vector3 kidVector3;

    // Start is called before the first frame update
    void Start()
    {
        kidMoveSpeed = 10f;
        kidRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        kidVector3 = transform.TransformDirection(hAxis, 0, 0) * kidMoveSpeed * Time.deltaTime;
        kidRigidBody.MovePosition(transform.position + kidVector3);
    }

}

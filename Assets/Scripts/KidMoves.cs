using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidMoves : MonoBehaviour
{
    public float kidMoveSpeed;
    private Rigidbody2D kidRigidBody;
    private Vector2 kidVector2;

    // Start is called before the first frame update
    void Start()
    {
        kidMoveSpeed = 10f;
        kidRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        kidVector2 = transform.TransformDirection(hAxis, 0,0) * kidMoveSpeed * Time.deltaTime;
        Vector2 whereLegs = transform.position;
        kidRigidBody.MovePosition(whereLegs + kidVector2);
    }

}

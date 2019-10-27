using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandMa : MonoBehaviour
{

    public float armSpeed;
    private Rigidbody2D grandMaRigidBody;
    private float rotationSpeed = 0f;


    // Start is called before the first frame update
    void Start()
    {
        grandMaRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grandMaSwing();
    }

    void grandMaSwing()
    {
        rotationSpeed -= armSpeed;
        grandMaRigidBody.SetRotation(rotationSpeed);
    }


}

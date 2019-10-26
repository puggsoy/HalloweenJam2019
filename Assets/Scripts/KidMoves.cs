using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidMoves : MonoBehaviour
{
	public float kidMoveSpeed = 3;
    private Rigidbody2D kidRigidBody;
    private Vector2 kidVector2;
	private Animator animator;

    void Start()
    {
        kidRigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
    }

    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        kidVector2 = transform.TransformDirection(hAxis, 0,0) * kidMoveSpeed * Time.deltaTime;
        Vector2 whereLegs = transform.position;
        kidRigidBody.MovePosition(whereLegs + kidVector2);

		animator?.SetBool("OnOff", hAxis != 0);

		Vector3 scale = transform.localScale;

		if (hAxis > 0)
		{
			transform.localScale = new Vector2(Mathf.Abs(scale.x) * -1, scale.y);
		}
		else if (hAxis < 0)
		{
			transform.localScale = new Vector2(Mathf.Abs(scale.x) * 1, scale.y);
		}
	}
}
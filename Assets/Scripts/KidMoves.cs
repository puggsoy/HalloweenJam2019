using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidMoves : MonoBehaviour
{
	public float kidMoveSpeed = 3;
	public float jumpForce = 10;
    public int kidNumber;

    private Rigidbody2D kidRigidBody;
    private Vector2 kidVector2;
	private Animator animator;

	private bool jumpDown = false;

	private void Start()
    {
        kidRigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
    }

	private void FixedUpdate()
    {
        if (kidNumber == 0)
        {
            return;
        }
        float hAxis = Input.GetAxis("Horizontal_P"+kidNumber.ToString());
		kidVector2 = transform.TransformDirection(hAxis, 0, 0) * kidMoveSpeed * Time.fixedDeltaTime;
		//Vector2 whereLegs = transform.position;
		//kidRigidBody.MovePosition(whereLegs + kidVector2);
		kidRigidBody.AddForce(kidVector2);

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

		float jumpAxis = Input.GetAxisRaw("Jump_P"+kidNumber.ToString());

		if (jumpAxis > 0 && !jumpDown)
		{
			Jump();
		}

		jumpDown = jumpAxis > 0;
	}



	private void Jump()
	{
		kidRigidBody.AddForce(new Vector2(0, jumpForce));
	}
}
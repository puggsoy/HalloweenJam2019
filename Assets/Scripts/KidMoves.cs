using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidMoves : MonoBehaviour
{
	public event Action<int, int> OnCandyCollect;

	private const string horizPrefix = "Horizontal_P";
	private const string jumpPrefix = "Jump_P";

	public float kidMoveSpeed = 3;
	public float jumpForce = 240;
    public int kidNumber;

    private Rigidbody2D kidRigidBody;
	private Animator animator;

    private float kidVelocity = 0;
    private float maxVelocity = 30;

	private bool jumpDown = false;
	private bool isTouchingGround = false;

	private int score = 0;

	private void Start()
    {
        kidRigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
    }

	private void FixedUpdate()
    {
		string horizString = horizPrefix + kidNumber.ToString();
		string jumpString = jumpPrefix + kidNumber.ToString();

        try
		{
			float foo = Input.GetAxis(horizString);
			float bar = Input.GetAxis(jumpString);
		}
		catch (Exception)
		{
			return;
		}

		float hAxis = Input.GetAxisRaw(horizString);
        //float hAxis = Input.GetKey(KeyCode.RightArrow) ? 1 : 0;
        float acceleration = hAxis * kidMoveSpeed;// * Time.fixedDeltaTime;
        kidVelocity += acceleration;
        if (Mathf.Abs(kidVelocity) > maxVelocity)
        {
            kidVelocity = Mathf.Sign(kidVelocity) * maxVelocity;
        }
		//Vector2 whereLegs = transform.position;
		//kidRigidBody.MovePosition(whereLegs + kidVector2);
		//kidRigidBody.AddForce(kidVector2);
		kidRigidBody.velocity = new Vector2(kidVelocity, kidRigidBody.velocity.y);

        kidVelocity *= 0.95f;

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

		float jumpAxis = Input.GetAxisRaw(jumpString);

		if (jumpAxis > 0 && !jumpDown && isTouchingGround)
		{
			Jump();
		}

		jumpDown = jumpAxis > 0;
	}

	private void Jump()
	{
		kidRigidBody.AddForce(new Vector2(0, jumpForce));
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Floor"))
		{
			isTouchingGround = true;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Floor"))
		{
			isTouchingGround = false;
		}
	}

	public void CollectCandy()
	{
		score++;

		OnCandyCollect?.Invoke(kidNumber, score);
	}
}
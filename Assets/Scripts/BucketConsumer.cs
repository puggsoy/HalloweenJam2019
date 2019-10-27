using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketConsumer : MonoBehaviour
{
	public KidMoves kidScript;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Candy"))
		{
			kidScript.CollectCandy();
			Destroy(collision.gameObject);
		}
	}
}
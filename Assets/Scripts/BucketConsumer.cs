using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketConsumer : MonoBehaviour
{
	public KidMoves kidScript;
    private GameObject gameObjectAM;
    private AudioManager AM;

    private void Start()
    {
        gameObjectAM = GameObject.FindGameObjectWithTag("AudioManager");
        Debug.Log(gameObjectAM.ToString());
        AM = gameObjectAM.GetComponent("AudioManager") as AudioManager;
    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Candy"))
		{
            AM.SFXkid();
            kidScript.CollectCandy();
			Destroy(collision.gameObject);

		}
	}
}
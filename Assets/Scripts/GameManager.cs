using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public int playerNum = 3;
	public KidMoves[] kidPrefabs;

	private KidMoves[] kids;

	private void Awake()
	{
		kids = new KidMoves[playerNum];
	}

	private void Start()
	{
		for (int i = 0; i < kids.Length; i++)
		{
			kids[i] = Instantiate<KidMoves>(kidPrefabs[i], new Vector2(i * 9, -9), Quaternion.identity, transform);
			kids[i].kidNumber = i + 1;
			kids[i].transform.localScale = new Vector2(1, 1);
		}
	}
}

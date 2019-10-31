using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	private const int WINNER_AMOUNT = 20;

	public int playerNum = 3;
	public KidMoves[] kidPrefabs;
	public Text[] kidPointsTexts;

	public Text winText;

	private KidMoves[] kids;

	private bool gameEnded = false;
	private bool continueToEnd = false;

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

			kids[i].OnCandyCollect += OnScoreChange;

			kidPointsTexts[i].text = "0";
		}
	}

	private void Update()
	{
		if (gameEnded)
		{
			if (Input.GetButtonDown("Jump_P1"))
			{
				continueToEnd = true;
			}
		}
	}

	private void OnDestroy()
	{
		for (int i = 0; i < kids.Length; i++)
		{
			kids[i].OnCandyCollect -= OnScoreChange;
		}
	}

	private void OnScoreChange(int kidNum, int score)
	{
		kidPointsTexts[kidNum - 1].text = score.ToString();

		if (score >= WINNER_AMOUNT)
		{
			EndGame(kidNum);
		}
	}

	private void EndGame(int winnerNum)
	{
		for (int i = 0; i < kids.Length; i++)
		{
			kids[i].OnCandyCollect -= OnScoreChange;
		}

		winText.text = string.Format("Player {0} won!", winnerNum);
		winText.gameObject.SetActive(true);

		Time.timeScale = 0;
		gameEnded = true;

		StartCoroutine(GoToEndScene(3));
	}

	private IEnumerator GoToEndScene(int delay)
	{
		yield return new WaitUntil(() => continueToEnd);

		Time.timeScale = 1;
		SceneManager.LoadScene("EndScene");
	}
}

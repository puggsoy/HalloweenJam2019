using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyThrow : MonoBehaviour
{

    public int candyMin = 1;
    private int candyNumbers;
    public int candyMax = 6;
    public float candyMinSpeed = .1f;
    public float candyMaxSpeed = .2f;
    public float candyXOrigin;
    public float candyYOrigin;
    public List<GameObject> candyList;
    private int candyLength;
    public Sprite handOpen;
    private GameObject grandMaHand;
    private SpriteRenderer grandMaHandSR;



    // Start is called before the first frame update
    void Start()
    {
        candyLength = candyList.Count;
        grandMaHand = GameObject.FindGameObjectWithTag("Hand");
        grandMaHandSR = grandMaHand.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Arm")
        {
            CreateCandy();
            OpenHand();
            //Grandma SFX
        }
    }

    void CreateCandy()
    {
        candyNumbers = Random.Range(candyMin, candyMax);

        //Debug.Log("Candy to be spawned are "+candySpawns);
        do
        {
            int candyCount = SelectCandy();
            GameObject spawnedCandy = SpawnCandy(candyCount);
            ThrowCandy(spawnedCandy);
            candyNumbers -= 1;
        }
        while (candyNumbers > 0);
    }

    void OpenHand()
    {
        //open hand
        grandMaHandSR.sprite = handOpen;
    }

    int SelectCandy()
    {
        int candySelection = Random.Range(0, candyLength);
        return candySelection;
        //Debug.Log("Candy chosen is "+candy);
    }

    GameObject SpawnCandy(int candyCount)
    {
        GameObject candy = Instantiate(candyList[candyCount], new Vector2(candyXOrigin, candyYOrigin), Quaternion.identity);
        return candy;
    }

    void ThrowCandy(GameObject candy)
    {
        //direction
        float radian = Random.Range(0, Mathf.PI / 2);
        Vector2 candyDirection = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
        //throw
        float speed = Random.Range(candyMinSpeed, candyMaxSpeed);
        Rigidbody2D candyBody = candy.GetComponent<Rigidbody2D>();
        candyBody.AddForce(candyDirection*speed, ForceMode2D.Impulse);
    }

}

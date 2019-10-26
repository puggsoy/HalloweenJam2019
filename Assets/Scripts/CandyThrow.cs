using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyThrow : MonoBehaviour
{

    public int candyMin = 1;
    private int candyNumbers;
    public int candyMax = 6;
    public float candyMinSpeed = 1f;
    public float candyMaxSpeed = 10f;
    //public float candyMinDirection;
    //public float candyMaxDirection;
    public List<GameObject> candyList;
    private int candyLength;

    // Start is called before the first frame update
    void Start()
    {
        candyLength = candyList.Count;
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
            //Debug.Log("Arm Throw");
        }
    }

    void CreateCandy()
    {
        candyNumbers = Random.Range(candyMin, candyMax);

        //Debug.Log("Candy to be spawned are "+candySpawns);
        //for each candySpawns, random select prefab, spawn candy, random select direction, random select force
        int candyCount = SelectCandy();
        GameObject spawnedCandy = SpawnCandy(candyCount);
        ThrowCandy(spawnedCandy);
    }

    int SelectCandy()
    {
        int candySelection = Random.Range(0, candyLength);
        return candySelection;
        //Debug.Log("Candy chosen is "+candy);
    }

    GameObject SpawnCandy(int candyCount)
    {
        GameObject candy = Instantiate(candyList[candyCount], new Vector2(-6.5f, 1.25f), Quaternion.identity);
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

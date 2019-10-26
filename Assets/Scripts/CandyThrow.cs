using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyThrow : MonoBehaviour
{

    public int candyMin = 1;
    private int candySpawns;
    public int candyMax = 6;
    public float candyMinSpeed = 1f;
    public float candyMaxSpeed = 10f;
    public float candyMinDirection;
    public float candyMaxDirection;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arm")
        {
            Debug.Log("Arm Throw");
        }
    }

    void CreateCandy()
    {
        candySpawns = Random.Range(candyMin, candyMax);
        Debug.Log(candySpawns);
    }

    void ThrowCandy(int howManyCandy)
    {

    }

}

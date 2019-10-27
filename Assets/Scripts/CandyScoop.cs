using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScoop : MonoBehaviour
{

    public Sprite handClose;
    private GameObject grandMaHand;
    private SpriteRenderer grandMaHandSR;

    // Start is called before the first frame update
    void Start()
    {
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
            ScoopCandy();
            //Debug.Log("Hand Scoop");
        }
    }

    void ScoopCandy()
    {
        grandMaHandSR.sprite = handClose;
        //Debug.Log("close hand");
        //scoop candy
    }
}

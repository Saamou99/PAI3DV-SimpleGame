using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectBalls : MonoBehaviour
{
    public int balls;

    public TextMeshProUGUI ballText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Ball")
        {
            Debug.Log("Ball Collected");
            balls = balls + 1;
            Col.gameObject.SetActive(false);
            ballText.text = "Collected Balls: " + balls.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
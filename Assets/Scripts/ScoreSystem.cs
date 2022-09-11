using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public GameObject ScoreCount;
    public static int Score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MainPlayer"){
            Debug.Log(Score);
            Score += 10;
            ScoreCount.GetComponent<TextMeshProUGUI>().text = "" + Score;
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Debug.Log(Score);
        ScoreCount.GetComponent<TextMeshProUGUI>().text = "" + Score;
    }

    void Update()
    {
        
    }
}
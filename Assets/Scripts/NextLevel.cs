using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
  
public class NextLevel : MonoBehaviour
{
    public string NextLevelPath = "";
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other){
        if(other.tag == "MainPlayer"){
            SceneManager.LoadScene(NextLevelPath);
        }
    }
}
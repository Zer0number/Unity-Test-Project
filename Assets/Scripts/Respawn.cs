using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
  
public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other){
        if(other.tag == "MainPlayer"){
            SceneManager.LoadScene("Levels/Level1");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //Треба це все переписати по нормальному
    private static string currentLevel = "", currentDifficulty = "";

    public void StartGame(string difficulty){
        currentDifficulty = difficulty;
        Debug.Log(currentDifficulty);

        SceneManager.LoadScene("Levels/" + currentLevel);
    }

    // public void StartGameEndless(string difficulty){
    //     currentDifficulty = difficulty;
    //     Debug.Log(currentDifficulty);

    //     SceneManager.LoadScene("Levels/TestCastle");
    // }

    public void SelectDifficulty(string level){
        currentLevel = level;
        Debug.Log(currentLevel);

        SceneManager.LoadScene("Scenes/SelectDifficultyMenu");
    }

    public void SelectLevel(){
        SceneManager.LoadScene("Scenes/SelectLevelMenu");
    }

    public void Credits(){
        SceneManager.LoadScene("Scenes/CreditsMenu");
    }

    // public void Settings(){

    // }

    public void Back(){
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void Exit(){
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("EXIT!!!");
        Application.Quit();
    }
}

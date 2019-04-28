using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class gameOver : MonoBehaviour
{
    public void gotoMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void scoreLoader()
    {
        string path = "Assets/Resources/scores.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(scoreScript.scoreValue);
        writer.Close();
                
    }
}

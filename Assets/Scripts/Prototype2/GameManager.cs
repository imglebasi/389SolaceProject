using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necessary for scene management

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance for global access

    private void Awake()
    {
        // Ensure only one instance of the GameManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: keep the GameManager across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to restart the current scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

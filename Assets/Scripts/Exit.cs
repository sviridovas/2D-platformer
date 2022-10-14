using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private float levelLoadDelay = 2f;
    [SerializeField] private float levelExitSlowFactor = 0.2f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        Time.timeScale = levelExitSlowFactor;
        
        yield return new WaitForSecondsRealtime(levelLoadDelay);

        Time.timeScale = 1;
        
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}

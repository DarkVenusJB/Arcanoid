using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseImage;

    private int sceneIndex;
    private void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        } 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseImage.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void LoadNextLevel1()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadNextLevel2() 
    {
        SceneManager.LoadScene(3);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    
    public void Resume()
    {
        pauseImage.SetActive(false);
        Time.timeScale = 1;
    }

    public void FinishLevel()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void NextLevel()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }
}

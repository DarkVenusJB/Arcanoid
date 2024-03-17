using UnityEngine;
using UnityEngine.SceneManagement;
public class MUI : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
         Application.Quit();
    }
    public void InfinityLevel()
    {
        SceneManager.LoadScene(4);
    }
}

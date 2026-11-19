using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Playground");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ControlsMenu()
    {
        SceneManager.LoadScene("ControlsMenu");
    }
    public void IntroductionLetter()
    {
        SceneManager.LoadScene("IntroductionLetter");
    }
}

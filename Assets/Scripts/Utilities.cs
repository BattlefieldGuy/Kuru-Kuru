using UnityEngine;
using UnityEngine.SceneManagement;

public class Utilities : MonoBehaviour
{
    [SerializeField] private GameObject BlackCanvas;
    [SerializeField] private GameObject ResumeButton;
    [SerializeField] private GameObject LevelSelectButton;
    [SerializeField] private GameObject MenuButton;
    [SerializeField] private GameObject Toggle;
    [SerializeField] private GameObject playAgainButton;
    [SerializeField] private Rigidbody2D m_Rigidbody;

    public void GoToLevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }
    public void Training()
    {
        SceneManager.LoadScene("Training");
    }
    public void Chapter1()
    {
        SceneManager.LoadScene("Chapter 1");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LevelMenu()
    {
        Time.timeScale = 0f;
        BlackCanvas.SetActive(true);
        ResumeButton.SetActive(true);
        LevelSelectButton.SetActive(true);
        MenuButton.SetActive(true);
        Toggle.SetActive(true);
        Debug.Log("Level Menu up!");
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        BlackCanvas.SetActive(false);
        ResumeButton.SetActive(false);
        LevelSelectButton.SetActive(false);
        MenuButton.SetActive(false);
        Toggle.SetActive(false);
        Debug.Log("Level Menu Down!");
    }
    public void Info()
    {
        SceneManager.LoadScene("Info");
    }
}

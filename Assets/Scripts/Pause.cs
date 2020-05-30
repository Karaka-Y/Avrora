using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject PausePanel;

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
        }
    }

    public void Continue()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}

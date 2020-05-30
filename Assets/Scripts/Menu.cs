using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private AudioSource music;
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private GameObject catscenePanel;
    [SerializeField]
    private Text text;
    private bool catsceneStarted;

    public void ExitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if(Input.GetKey("escape") && catsceneStarted)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void NewGame()
    {
        StartCoroutine(NewGameCatscene());
    }
   
    //смена текста по таймингам в катсцене
    public IEnumerator NewGameCatscene()
    {
        music.Play();
        menuPanel.SetActive(false);
        catscenePanel.SetActive(true);
        catsceneStarted = true;
        text.text = "Однажды люди забрели слишком далеко, спустились слишко глубоко и прикоснулись к тому, что было им неподвластно.";
        yield return new WaitForSeconds(9f);
        text.text = "В недрах Запретной Горы исследователи обнаружили Тьму.";
        yield return new WaitForSeconds(8f);
        text.text = "Пробудившись, она вырвалась на поверхность, и мир накрыла Вечная Ночь.";
        yield return new WaitForSeconds(8f);
        text.text = "Теперь человечеством правит Тьма. Она превратила людей в бездушных кукол, забрав у них самое ценное - Свет.";
        yield return new WaitForSeconds(8f);
        text.text = "Аврора - девочка, которая отправляется на поиски своих родителей.";
        yield return new WaitForSeconds(8f);
        text.text = "Тех самых исследователей, которые первыми обнаружили Тьму, но так и не вернулись домой.";
        yield return new WaitForSeconds(9f);
        text.text = "Аврора не одна. С ней Светлячок - древний артефакт чистого света, подарок родителей.";
        yield return new WaitForSeconds(9f);
        text.text = "В поисках своих родных, Аврора спускается в подземелья Запретной Горы...";
        yield return new WaitForSeconds(9f);
        SceneManager.LoadScene(1);
    }
}

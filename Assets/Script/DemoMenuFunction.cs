using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoMenuFunction : MonoBehaviour
{
    public GameObject guidePanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ShopSkill()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenGamePanel()
    {
        guidePanel.SetActive(true);
    }
    public void CloseGamePanel()
    {
        guidePanel.SetActive(false);
    }
}

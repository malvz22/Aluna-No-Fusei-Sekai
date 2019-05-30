using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    public Animator loadGamePanel;
    public Animator settingPanel;

    public string selectedGameFile = "";

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CloseLoadGamePanel();
        CloseSettingPanel();
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void ClickLoadGame()
    {
        loadGamePanel.gameObject.SetActive(true);
        loadGamePanel.SetTrigger("activate");

        if (settingPanel.gameObject.activeInHierarchy)
            settingPanel.SetTrigger("deactivate");
    }

    public void ClickSettingPanel()
    {
        settingPanel.gameObject.SetActive(true);
        settingPanel.SetTrigger("activate");

        if (loadGamePanel.gameObject.activeInHierarchy)
            loadGamePanel.SetTrigger("deactivate");
    }

    public void ExitOutOfLoadGamePanel()
    {
        loadGamePanel.SetTrigger("deactivate");
    }

    public void CloseLoadGamePanel()
    {
        loadGamePanel.gameObject.SetActive(false);
    }
    
    public void CloseSettingPanel()
    {
        settingPanel.gameObject.SetActive(false);
    }

    public void StartNewGame()
    {
        selectedGameFile = "auto/autoSave";
        FileManager.SaveFile(FileManager.savPath + "savData/file", selectedGameFile);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Novel");
    }
}
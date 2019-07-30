using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public byte[] keys = new byte[3] { 23, 70, 194 };
    public static MainMenu instance;

    public Animator loadGamePanel;
    public Animator settingPanel;

    public Transform load,setting;
    public string selectedGameFile = "";

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //setting.GetComponent<Button>().interactable = false;
        CloseSettingPanel();
        CloseLoadGamePanel();
         if (!System.IO.File.Exists(FileManager.LoadFile(FileManager.savPath + "file.txt")[0]))
        {
            //load.GetComponent<Button>().interactable = false;
           
        }else
        {
            //load.GetComponent<Button>().interactable = true;
            //loadGamePanel.gameObject.SetActive(true);
        }
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void ClickLoadGame()
    {
        selectedGameFile = "auto/autoSave";
        FileManager.SaveFile(FileManager.savPath + "savData/file", selectedGameFile);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Novel");
        // loadGamePanel.gameObject.SetActive(true);
        // loadGamePanel.SetTrigger("activate");

        // if (settingPanel.gameObject.activeInHierarchy)
        //     settingPanel.SetTrigger("deactivate");
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
        FileManager.SaveEncryptedJSON(FileManager.LoadFile(FileManager.savPath + "file.txt")[0], new GAMEFILE(), keys);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Novel");

        // if (!System.IO.File.Exists())
        // {
           
        // }
    }

}
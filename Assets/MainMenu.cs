using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button lvl2;
    public Button lvl3;
    int levelComplete;

    // Start is called before the first frame update
    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        lvl2.interactable = false;
        lvl3.interactable = false;

        switch (levelComplete)
        {
            case 1:
                lvl2.interactable = true;
                break;
            case 2:
                lvl2.interactable = true;
                lvl3.interactable = true;
                break;


        }
    }

    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Reset()
    {
        lvl2.interactable = false;
        lvl3.interactable = false;
        PlayerPrefs.DeleteAll();

    }
}

using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public SceneFader fader;

    public Button[] levelButtons;

    void Start()
    {
        // highest level rechaed
        int levelReached = PlayerPrefs.GetInt("levelReached", 0);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > levelReached)
            {
               // levelButtons[i].interactable = false;
               // all should be interactable to test the game at least
            }
            
        }
    }

    public void Selected(string levelName)
    {
        fader.FadeTo(levelName);
    }

}

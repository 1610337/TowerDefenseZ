using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour {

    public GameObject aboutPopUp;
    public GameObject tutorialPopUP;
    public GameObject mainDisplays;
    public GameObject whatPopUp;

	public void toggleAboutPanel()
    {
        mainDisplays.SetActive(!mainDisplays.activeSelf);
        aboutPopUp.SetActive(!aboutPopUp.activeSelf);
    }

    public void toggleTutorial()
    {
        mainDisplays.SetActive(!mainDisplays.activeSelf);
        tutorialPopUP.SetActive(!tutorialPopUP.activeSelf);
    }

    public void togglewhatPopUp()
    {
        mainDisplays.SetActive(!mainDisplays.activeSelf);
        whatPopUp.SetActive(!whatPopUp.activeSelf);
    }


}

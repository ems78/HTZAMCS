using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject aboutPanel;
    public GameObject exitPanel;
    public GameObject soundButton;





    //ABOUT PANEL
    //------------
    public void AboutGame()
    {
        aboutPanel.SetActive(true);
    }

    public void Back() 
    {
        aboutPanel.SetActive(false);
    }
    




    //EXIT PANEL
    //-----------
    public void ExitGame()
    {
        exitPanel.SetActive(true );
    }

    public void YesExitButton()
    {
        Application.Quit();
    }

    public void NoExitButton()
    {
        exitPanel.SetActive(false);
    }
}

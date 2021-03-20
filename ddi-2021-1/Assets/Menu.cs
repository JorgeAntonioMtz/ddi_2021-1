using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Menu : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject TimerPanel;
    public GameObject coinPanel;
    public GameObject inventoryPanel;
    public GameObject mobilePanel;

    public static bool isInventoryOn;
    public static bool isGamePaused = false;
    private string menuButton = "Menu";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown(menuButton))
        {
            //toggle
            //menuUI.SetActive(!menuUI.activeSelf);
            if(isGamePaused)
                Resume();
            else
                Pause();

        }
    }

    public void Pause()
    {
        menuUI.SetActive(true);
        coinPanel.SetActive(false);
        isInventoryOn = inventoryPanel.activeSelf;
        if(isInventoryOn)
            inventoryPanel.SetActive(false);
        mobilePanel.SetActive(false);
        TimerPanel.SetActive(false);
        Time.timeScale = 0;
        isGamePaused = true;
    }
    public void Resume()
    {
        menuUI.SetActive(false);
        coinPanel.SetActive(true);
        if(isInventoryOn)
        {
            inventoryPanel.SetActive(true);
            isInventoryOn = true;
        }
        mobilePanel.SetActive(true);
        TimerPanel.SetActive(true);
        Time.timeScale = 1;
        isGamePaused = false;
    }

    public void Quit(){
        Debug.Log("Quitting game...");
    }
}

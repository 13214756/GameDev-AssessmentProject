using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject HelpPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        MenuPanel.SetActive(true);
        HelpPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMenuPanel()
    {
        MenuPanel.SetActive(true);
        HelpPanel.SetActive(false);
    }

    public void ShowHelpPanel()
    {
        MenuPanel.SetActive(false);
        HelpPanel.SetActive(true);
    }
}

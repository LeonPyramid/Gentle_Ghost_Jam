﻿/* Author : Raphaël Marczak - 2018, for Label[i]
 * 
 * This work is licensed under the CC0 License. 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This struct represents one dialog page
// (text on the current page, and its color)
[System.Serializable]
public struct DialogPage
{
    public string text;
    public Color color;
}

// This class is used to correctly display a full dialog
public class DialogManager : MonoBehaviour {

    public Text m_renderText;
    private List<DialogPage> m_dialogToDisplay;

    void Awake () {

    }

    // Sets the dialog to be displayed
    public void SetDialog(List<DialogPage> dialogToAdd)
    {
        m_dialogToDisplay = new List<DialogPage>(dialogToAdd);

        if (m_dialogToDisplay.Count > 0)
        {
            if (m_renderText != null)
            {
               m_renderText.text = "";
            }

            this.gameObject.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (m_renderText == null)
        {
            this.gameObject.SetActive(false);
        }

        // Displays the current page
		if (m_dialogToDisplay.Count > 0)
        {
            Time.timeScale = 0f;
            m_renderText.text = m_dialogToDisplay[0].text;
        } else
        {
            Time.timeScale = 1f;
            this.gameObject.SetActive(false);
        }

        // Remoeves the page when the player presses "space"
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_dialogToDisplay.RemoveAt(0);
        }
	}

    public bool IsOnScreen()
    {
        return this.gameObject.activeSelf;
    }

    public void Next(){
        m_dialogToDisplay.RemoveAt(0);
    }
}
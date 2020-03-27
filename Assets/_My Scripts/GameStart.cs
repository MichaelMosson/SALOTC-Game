using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour {

    public GameObject informationPanel;
    public Text panelHeaderText;
    public Text panelBodyText;
    public Text panelFooterText;

    public Text interationText;

    public string headerContents;
    public string bodyContents;
    public string footerContents;

    bool panelActivate;
    bool panelActivated;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("panelActivatable");
        interationText.text = "Press Q to view controls";
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (panelActivate && Input.GetKey(KeyCode.Q))
        {
            showPanel();
        }
        if (panelActivated && Input.GetKey(KeyCode.Tab) || panelActivated && Input.GetKey(KeyCode.Escape))
        {
            hidePanel();
        }
	}

    void showPanel()
    {
        interationText.text = "";

        bodyContents = "Movement: [W] [A] [S] [D] Keys \nInteraction: [E] Key \nPause Menu: [ESC] Key \n \nSearch the office for clues to who has murdered Trevor Collins.";

        informationPanel.SetActive(true);

        panelActivated = true;

        panelHeaderText.text = headerContents;
        panelBodyText.text = bodyContents;
        panelFooterText.text = footerContents;

        Time.timeScale = 0;
    }

    void hidePanel()
    {
        informationPanel.SetActive(false);

        Time.timeScale = 1;

        panelActivate = false;
        panelActivated = false;
    }

    void endCoroutine()
    {
        panelActivate = false;

        if (interationText.text == "Press Q to view controls")
        {
            interationText.text = "";
        }
        
        StopCoroutine("panelActivatable");
    }

    IEnumerator panelActivatable()
    {
        panelActivate = true;
        yield return new WaitForSeconds(15f);
        endCoroutine();
    }
}

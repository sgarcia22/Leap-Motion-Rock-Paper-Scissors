using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPSGM : MonoBehaviour {

    public LeapMotionController LPC;
    bool compRock = false, compPaper = false, compScissors = false, userRock = false, userPaper = false, userScissors = false;
    public GameObject roc, pap, sci;
    public Text UI;

    // Use this for initialization
    void Start () {
        InvokeRepeating("RPS", 0f, 10f);

    }
	
    private void RPS()
    {
        roc.SetActive(false);
        pap.SetActive(false);
        sci.SetActive(false);
        //Pick RPS
        int pick = Random.Range(0, 3);
        if (pick == 0) compRock = true;
        else if (pick == 1) compPaper = true;
        else compScissors = true;
        StartCoroutine("countdown");
        //Countdown

    }

    IEnumerator countdown ()
    {
        UI.text = "3";
        yield return new WaitForSeconds(1);
        UI.text = "2";
        yield return new WaitForSeconds(1);
        UI.text = "1";
        yield return new WaitForSeconds(1);

        if (compRock)
            roc.SetActive(true);
        if (compPaper)
            pap.SetActive(true);
        if (compScissors)
            sci.SetActive(true);


        if (userRock)
            Debug.Log("Rock");
        if (userPaper)
            Debug.Log("Paper");
        if (userScissors)
            Debug.Log("Scissors");

        //Win Conditions
        if (compRock && userRock || compScissors && userScissors || userPaper && compPaper)
            UI.text = "Tie";
        else if (compRock && userPaper || compPaper && userScissors || compScissors && userRock)
            UI.text = "Win";
        else
            UI.text = "Loss";


        yield return new WaitForSeconds(3);
        compPaper = false; compScissors = false; compRock = false;

    }


    // Update is called once per frame
    void Update () {
        userRock = LPC.rock; userPaper = LPC.paper; userScissors = LPC.scissors;
    }
}

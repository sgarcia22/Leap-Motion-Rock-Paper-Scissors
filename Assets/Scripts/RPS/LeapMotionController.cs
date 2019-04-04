using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

//Hand Controller for Rock Paper Scissors
public class LeapMotionController : MonoBehaviour {

    Controller controller;
    Frame frame;
    List<Hand> hands;
    public bool rock = false, paper = false, scissors = false;

	void Start () {
        controller = new Controller();
        frame = controller.Frame();
        hands = frame.Hands;
        Debug.Log("Starting");

	}
	
	void Update () {
        frame = controller.Frame();
        hands = frame.Hands;
        Hand primaryHand = null;
        //Get the first hand on the scene and set it as the primary hand
        if (frame.Hands.Count > 0)
        {
            Debug.Log("Entering");
            primaryHand = frame.Hands[0];
            //Detect Rock Paper or Scissors
            //Get all of the fingers
            Finger thumb, index, middle, ring, pinky; 
            thumb = primaryHand.Fingers[0];
            index = primaryHand.Fingers[1];
            middle = primaryHand.Fingers[2];
            ring = primaryHand.Fingers[3];
            pinky = primaryHand.Fingers[4];

            //Rock
            if (!thumb.IsExtended && !index.IsExtended && !middle.IsExtended && !ring.IsExtended && !pinky.IsExtended)
                rock = true;
            else
                rock = false;
            
            //Paper
            if (thumb.IsExtended && index.IsExtended && middle.IsExtended && ring.IsExtended && pinky.IsExtended)
                paper = true;
            else
                paper = false;
            //Scissors
            if (!thumb.IsExtended && index.IsExtended && middle.IsExtended && !ring.IsExtended && !pinky.IsExtended)
                scissors = true;
            else
                scissors = false;


            /*if (rock)
                Debug.Log("Rock");
            if (paper)
                Debug.Log("Paper");
            if (scissors)
                Debug.Log("Scissors");
                */
        }

        //Set booleans to false on frame end
        /*rock = false;
        paper = false;
        scissors = false;
        */
    }
}

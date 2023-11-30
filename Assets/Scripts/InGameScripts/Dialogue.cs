using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //Fields
    //Window
    public GameObject window;
    //Indicator
    public GameObject indicator;
    //Text component
    public TMP_Text dialogueText;
    //Dialogues list
    public List<string> dialogues;
    //Writing speed
    public float writingSpeed;
    //Index on dialogue
    public int index;
    //Character index
    private int charIndex;
    //Started boolean
    public bool started;
    //Wait for next boolean
    public bool waitForNext;
    //Check if that index is a quest giver
    public int questIndex; //Set to -1 if there's no quest in dialogue.

    public QuestPoint[] questPoint; 

    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }

    private void Update()
    {   

        if (questPoint != null )
        {
            foreach (QuestPoint quest in questPoint)
            {
                if (questIndex == 1) //SlimesKiller quest
                {
                    if (quest.currentQuestState.Equals(QuestState.IN_PROGRESS))
                    {
                        dialogues.Clear();
                        dialogues.Add("Well, did you take care of them yet?");

                    } 
                    else if (quest.currentQuestState.Equals(QuestState.CAN_FINISH))
                    {
                        dialogues.Clear();
                        dialogues.Add("Thanks a bunch, man. I couldn't thank you enough.");
                    }
                } 
                else if (questIndex == 2) //SunflowerCollector quest
                {   

                    if (quest.currentQuestState.Equals(QuestState.REQUIREMENTS_NOT_MET))
                    {
                        dialogues.Clear();
                        dialogues.Add("Hey, did you talk to the guy west of here yet?");
                    }
                    else if (quest.currentQuestState.Equals(QuestState.CAN_START))
                    {
                        dialogues.Clear();
                        dialogues.Add("Whoa, young man! You dealt with all those slimes by yourself?");
                        dialogues.Add("Uhh, me? I came from the village east of here.");
                        dialogues.Add("I'm looking for some sunflowers.");
                        dialogues.Add("I need it for some medicine, my wife is sick.");
                        dialogues.Add("Well, since you came from the west, you must have passed by some sunflowers.");
                        dialogues.Add("Can you go get some for me?");


                    }
                    else if (quest.currentQuestState.Equals(QuestState.IN_PROGRESS))
                    {
                        dialogues.Clear();
                        dialogues.Add("Thank you, pal.");

                    }
                    else if (quest.currentQuestState.Equals(QuestState.CAN_FINISH))
                    {
                        dialogues.Clear();
                        dialogues.Add("Thanks man, that helped me a lot");
                    }
                }
            }
        }
        
    }

    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }
    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    //Start Dialogue
    public void StartDialogue()
    {
        if (!started)
        {
            //Debug.Log("Dialogue count = " + dialogues.Count + "Index is = " + index);
            //Boolean to indicate that we have started
            started = true;
            //Show the window
            ToggleWindow(true);
            //hide the indicator
            ToggleIndicator(false);
            //Start with first dialogue
            GetDialogue(0);
        }

    }

    public void GetDialogue(int i)
    {
        //start index at zero
        index = i;
        //Reset the character index
        charIndex = 0;
        //clear the dialogue component text
        dialogueText.text = string.Empty;
        //Start writing
        StartCoroutine(Writing());
    }

    //End Dialogue
    public void EndDialogue()
    {
        index = 0;
        //Stared is disabled
        started = false;
        //Disable wait for next as well
        waitForNext = false;
        //Stop all Ienumerators
        StopAllCoroutines();
        //Hide the window
        ToggleWindow(false);

        

    }
    //Writing logic
    IEnumerator Writing()
    {
        yield return new WaitForSeconds(writingSpeed);

        string currentDialogue = dialogues[index];
        //Write the character
        dialogueText.text += currentDialogue[charIndex];
        //increase the character index 
        charIndex++;
        //Make sure you have reached the end of the sentence
        if (charIndex < currentDialogue.Length)
        {
            //Wait x seconds 
            yield return new WaitForSeconds(writingSpeed);
            //Restart the same process
            StartCoroutine(Writing());
        }
        else
        {
            //End this sentence and wait for the next one
            waitForNext = true;
        }
    }


}
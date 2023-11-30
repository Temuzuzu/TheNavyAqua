using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    prototypeChangeScene changeScene;
    public Dialogue dialogueScript;
    QuestActive questActive;
    private bool playerDetected;

    //Detect trigger with player
    void OnTriggerEnter2D(Collider2D collision)
    {
        //If we triggerd the player enable playerdeteced and show indicator
        if (collision.tag == "Player")
        {
            playerDetected = true;
            dialogueScript.ToggleIndicator(playerDetected);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //If we lost trigger  with the player disable playerdeteced and hide indicator
        if (collision.tag == "Player")
        {
            playerDetected = false;
            dialogueScript.ToggleIndicator(playerDetected);
            dialogueScript.EndDialogue();
        }
    }
    //While detected if we interact start the dialogue
    private void Update()
    {

        changeScene = FindAnyObjectByType<prototypeChangeScene>();

        if (playerDetected && Input.GetKeyDown(KeyCode.E) && !dialogueScript.waitForNext)
        {   
            dialogueScript.StartDialogue();
        }   
        else if (dialogueScript.waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            dialogueScript.waitForNext = false;
            dialogueScript.index++;
            //Debug.Log("Dialogue count = " + dialogueScript.dialogues.Count + "Index is = " + dialogueScript.index);
            //Check if we are in the scope fo dialogues List
            if (dialogueScript.index < dialogueScript.dialogues.Count)
            {
                //If so fetch the next dialogue
                dialogueScript.GetDialogue(dialogueScript.index);
            }
            else
            {
                //If not end the dialogue process
                //Debug.Log("This works");

                if (dialogueScript.questPoint != null)
                {
                    foreach (QuestPoint quest in dialogueScript.questPoint)
                    {
                        Debug.LogWarning(quest.currentQuestState + quest.questId);

                        //Start
                        if (quest.questId == "SlimesKiller") //SlimesKiller quest
                        {   

                            if (quest.currentQuestState.Equals(QuestState.CAN_START) && quest.startPoint)
                            {   
                                GameEventsManager.instance.questEvents.StartQuest("SlimesKiller");
                            }
                            else if (quest.currentQuestState.Equals(QuestState.CAN_FINISH) && quest.finishPoint)
                            {
                                GameEventsManager.instance.questEvents.FinishQuest("SlimesKiller");
                                if (changeScene != null)
                                {
                                    changeScene.quest1 = true;
                                }
                            }
                        }
                        else if (quest.questId == "SunflowerCollector") //SunflowerCollector quest
                        {
                            if (quest.currentQuestState.Equals(QuestState.CAN_START) && quest.startPoint)
                            {
                                Debug.LogWarning("Quest state: " + quest.currentQuestState);
                                GameEventsManager.instance.questEvents.StartQuest("SunflowerCollector");
                            }
                            else if (quest.currentQuestState.Equals(QuestState.CAN_FINISH) && quest.finishPoint)
                            {
                                Debug.LogWarning("Finished");
                                GameEventsManager.instance.questEvents.FinishQuest("SunflowerCollector");
                                if (changeScene != null)
                                {
                                    changeScene.quest2 = true;
                                }
                            }
                        }

                    
                    }
                }
                dialogueScript.ToggleIndicator(true);
                dialogueScript.EndDialogue();
            }   
        }
    }
}
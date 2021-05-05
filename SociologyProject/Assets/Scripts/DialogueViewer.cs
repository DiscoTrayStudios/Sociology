using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using TMPro;
using static DialogueObject;
using static PolicyObject;

public class DialogueViewer : MonoBehaviour
{
    public GameObject[] choices;

    PassageController passageController;
    public PolicyController policyController;
    public CutSceneController cutSceneController;
    public DialogueBoxController dialogueBoxController;
    DialogueController dialogueController;

    public int curChapterIndex;
    public TextAsset[] chapters;
    public GameObject[] backgrounds;
    public GameObject characterA;
    public GameObject characterB;
    public GameObject characterC;
    public GameObject characterD;
    public GameObject characterE;
    public GameObject characterF;
    public GameObject characterG;
    public GameObject characterH;
    public GameObject characterI;
    public GameObject intro;

    // Start is called before the first frame update
    void Start()
    {
        dialogueController = GetComponent<DialogueController>();
        dialogueController.onEnteredNode += OnNodeEntered;

        passageController = GetComponent<PassageController>();
        passageController.onEnteredChunk += OnChunkEntered;

        //dialogueController.InitializeDialogue();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeDialogue()
    {
        //
        curChapterIndex = 0;
        dialogueController.InitializeDialogue(chapters[curChapterIndex]);
        Debug.Log("Initialized dialogue");
        backgrounds[curChapterIndex].SetActive(true);
    }

    public void NextChapter()
    {
        if (curChapterIndex < chapters.Length - 1)
        {
            backgrounds[curChapterIndex].SetActive(false);
            dialogueController.InitializeDialogue(chapters[++curChapterIndex]);

            // Skip
            if (curChapterIndex == 1 && GameController.Instance.IsActiveSchoolPolicy("ContinueUniforms"))
            {
                dialogueController.UpdateDialogue();
            }

            backgrounds[curChapterIndex].SetActive(true);
        }
        else { GameController.Instance.EndGame(); }
    }

    public void OnNodeEntered(Node node)
    {                

        if (node.tags.Contains("Policy"))
        {
            dialogueBoxController.HideDialogue();

            policyController.OpenPolicy();
            //dialogueBoxController.policyButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            if (node.tags.Contains("Character"))
            {
                OpenCharacters(node);
                Debug.Log("Character Pop-Up!");
            }
            if (node.title == "Intro")
            {
                intro.SetActive(true);
                Debug.Log("Intro");
            }
            passageController.InitializePassage(node);
            //dialogueBoxController.policyButton.GetComponent<Button>().interactable = false; //
        }

        // Actions
        Policy policy = GameController.Instance.FindPolicy(node.title);
        if (policy != null)
        {
            Debug.Log("Activating policy: " + policy.name);
            GameController.Instance.ActivatePolicy(policy);
        }
    }

    public void OnNodeSelected(int i)
    {
        ClearCharacters();
        HideAllChoices();
        dialogueBoxController.dialogueSide.SetActive(true);

        Debug.Log("Player chose option " + i);
        if (!dialogueController.GetCurrentNode().IsEndNode())
        {
            dialogueController.ChooseResponse(i);
        }
        else
        {
            cutSceneController.CloseCutScene();
            Debug.Log("Entering next chapter");
            //GameController.Instance.NextChapter();
            NextChapter();
        }
    }

    public void OnChunkEntered(string chunk)
    {
        
        if (dialogueController.GetCurrentNode().tags.Contains("CutScene"))
        {
            dialogueBoxController.HideDialogue(); //
            cutSceneController.DisplayText(chunk);

            Debug.Log("Entered chunk with text: " + chunk);
        }
        else
        {
            
            dialogueBoxController.StartDialogue(chunk);
        }
    }

    public void Next()
    {
        if (!passageController.IsEndOfPassagage())
        {
            passageController.Next();
        }
        else
        {
            if (dialogueController.GetCurrentNode().responses.Count > 1)
            {
                
                ShowChoices(dialogueController.GetCurrentNode().responses);
                Debug.Log("Reached responses: ");
                foreach (Response response in dialogueController.GetCurrentNode().responses)
                {
                    Debug.Log(response.displayText);
                }
            }
            else { OnNodeSelected(0); } // Move on to next node


        }
    }

    

    public void ShowChoices(List<Response> responses)
    {
        //HideAllChoices();
        dialogueBoxController.dialogueSide.SetActive(false);
        Assert.IsTrue(choices.Length >= responses.Count);
        for (int i = 0; i < responses.Count; i++)
        {
            // https://answers.unity.com/questions/1271901/index-out-of-range-when-using-delegates-to-set-onc.html
            var index = responses.Count - (i + 1);
            Debug.Log("Index: " + index);
            //choices[i].GetComponent<Button>().onClick.AddListener(delegate { OnNodeSelected(index); });
            choices[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = responses[responses.Count - (i + 1)].displayText;
            
            // TODO: Add not null assertion
            if (!GameController.Instance.IsAvailable(responses[responses.Count - (i + 1)].destinationNode))
            {
                choices[i].GetComponent<Button>().interactable = false;
            }
            else
            {
                choices[i].GetComponent<Button>().interactable = true;

            }
            choices[i].SetActive(true);

        }
    }

    public void HideAllChoices()
    {
        foreach (GameObject button in choices)
        {
            button.SetActive(false);
            
        }
        
    }

    public void ClearCharacters()
    {
        characterA.SetActive(false);
        characterB.SetActive(false);
        characterC.SetActive(false);
        characterD.SetActive(false);
        characterE.SetActive(false);
        characterF.SetActive(false);
        characterG.SetActive(false);
        characterH.SetActive(false);
        characterI.SetActive(false);
        intro.SetActive(false);
    }

    public void OpenCharacters(Node node)
    {
        if (node.tags.Contains("A")) { characterA.SetActive(true); }
        if (node.tags.Contains("B")) { characterB.SetActive(true); }
        if (node.tags.Contains("C")) { characterC.SetActive(true); }
        if (node.tags.Contains("D")) { characterD.SetActive(true); }
        if (node.tags.Contains("E")) { characterE.SetActive(true); }
        if (node.tags.Contains("F")) { characterF.SetActive(true); }
        if (node.tags.Contains("G")) { characterG.SetActive(true); }
        if (node.tags.Contains("H")) { characterH.SetActive(true); }
        if (node.tags.Contains("I")) { characterI.SetActive(true); }
    }
}

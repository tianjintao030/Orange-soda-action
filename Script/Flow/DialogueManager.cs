using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Articy.Unity;
using Articy.Unity.Interfaces;


public class DialogueManager : MonoBehaviour, IArticyFlowPlayerCallbacks
{
    [Header("UI")]
    // Reference to Dialog UI
    [SerializeField]
    GameObject dialogueWidget;
    // Reference to dialogue text
    [SerializeField]
    Text dialogueText;
    // Reference to speaker
    [SerializeField]
    Text dialogueSpeaker;
    // Reference to button layout
    [SerializeField]
    RectTransform branchLayoutPanel;
    // Reference to navigation button prefab
    [SerializeField]
    GameObject branchPrefab;
    // Reference to close button prefab
    [SerializeField]
    GameObject closePrefab;
    //[SerializeField]
    //Image speakerImage;


    // To check if we are currently showing the dialog ui interface
    public bool DialogueActive { get; set; }

    private ArticyFlowPlayer flowPlayer;

    void Start()
    {
        flowPlayer = GetComponent<ArticyFlowPlayer>();
    }

    public void StartDialogue(IArticyObject aObject)
    {
        DialogueActive = true;
        dialogueWidget.SetActive(DialogueActive);
        flowPlayer.StartOn = aObject;
        Time.timeScale = 0;
    }

    public void CloseDialogueBox()
    {
        DialogueActive = false;
        dialogueWidget.SetActive(DialogueActive);
        // Completely process current object before we end dialogue
        flowPlayer.FinishCurrentPausedObject();
        Time.timeScale = 1;
    }

    // This is called every time the flow player reaches an object of interest
    public void OnFlowPlayerPaused(IFlowObject aObject)
    {
        //Clear data
        dialogueText.text = string.Empty;
        dialogueSpeaker.text = string.Empty;
        //speakerImage.sprite = null;

        // If we paused on an object that has a "Text" property fetch this text and present it
        var objectWithText = aObject as IObjectWithText;
        if (objectWithText != null)
        {
            dialogueText.text = objectWithText.Text;
        }

        // If the object has a "Speaker" property try to fetch the speaker
        var objectWithSpeaker = aObject as IObjectWithSpeaker;
        if (objectWithSpeaker != null)
        {
            // If the object has a "Speaker" property, fetch the reference
            // and ensure it is really set to an "Entity" object to get its "DisplayName"
            var speakerEntity = objectWithSpeaker.Speaker as Articy.ArticyProject.Entity;
            if (speakerEntity != null)
            {
                dialogueSpeaker.text = speakerEntity.DisplayName;
             
            }
        }

    }

    // Called every time the flow player encounters multiple branches,
    // or is paused on a node and wants to tell us how to continue
    public void OnBranchesUpdated(IList<Branch> aBranches)
    {
        // Destroy buttons from previous use, will create new ones here
        ClearAllBranches();

        // Check if any branch leads to a DialogueFragment target
        // If so, the dialogue is not yet finished
        bool dialogueIsFinished = true;
        foreach (var branch in aBranches)
        {
            if (branch.Target is IDialogueFragment)
            {
                dialogueIsFinished = false;
            }
        }

        if (!dialogueIsFinished)
        {
            // If we have branches, create a button for each of them
            foreach (var branch in aBranches)
            {
                // Instantiate a button in the Dialogue UI
                GameObject btn = Instantiate(branchPrefab, branchLayoutPanel);
                // Let the BranchChoice component fill the button content
                btn.GetComponent<BranchChoice>().AssignBranch(flowPlayer, branch);
            }
        }
        else
        {
            // Dialogue is finished, instantiate a close button
            GameObject btn = Instantiate(closePrefab, branchLayoutPanel);
            // Clicking this button will close the Dialogue UI
            var btnComp = btn.GetComponent<Button>();
            btnComp.onClick.AddListener(CloseDialogueBox);
        }
    }

    // Delete buttons from previous branches 
    void ClearAllBranches()
    {
        foreach (Transform child in branchLayoutPanel)
        {
            Destroy(child.gameObject);
        }
    }
}

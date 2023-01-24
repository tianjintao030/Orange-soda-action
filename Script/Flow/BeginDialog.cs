using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;
using Articy.Unity.Interfaces;
using Articy.ArticyProject;

public class BeginDialog : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private ArticyObject availableDialogue;
    public Collider2D coll;
    private bool haveDo;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        coll = GetComponent<Collider2D>();
        haveDo = false;
    }


    void Update()
    {
        var articyReferenceComp = coll.GetComponent<ArticyReference>();
        if (articyReferenceComp && haveDo==false)
        {
            availableDialogue = articyReferenceComp.reference.GetObject();
        }

        if (availableDialogue)
        {
            dialogueManager.StartDialogue(availableDialogue);
            availableDialogue = null;
            haveDo = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape)&& dialogueManager.DialogueActive)
        {
            dialogueManager.CloseDialogueBox();
        }
    }

   


}

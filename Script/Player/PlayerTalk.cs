using UnityEngine;
using UnityEngine.SceneManagement;
using Articy.Unity;
using Articy.Unity.Interfaces;
using Articy.ArticyProject;

public class PlayerTalk : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private ArticyObject availableDialogue;

    
    void Start()
    {
        dialogueManager =FindObjectOfType<DialogueManager>();

    }

    
    void Update()
    {
        PlayerInteraction();
    }
    void PlayerInteraction()
    {
        // Key option to start dialogue when near NPC
        if (Input.GetKeyDown(KeyCode.E) && availableDialogue)
        {
            dialogueManager.StartDialogue(availableDialogue);
        }

        // Key option to abort dialogue
        if (dialogueManager.DialogueActive && Input.GetKeyDown(KeyCode.Escape))
        {
            dialogueManager.CloseDialogueBox();
        }
    }

    // Trigger Enter/Exit used to determine if interaction with NPC is possible
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        var articyReferenceComp = collision.GetComponent<ArticyReference>();
        if (articyReferenceComp)
        {
            availableDialogue = articyReferenceComp.reference.GetObject();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ArticyReference>() != null)
        {
            availableDialogue = null;
        }
    }
}

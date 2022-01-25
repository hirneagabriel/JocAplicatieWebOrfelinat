using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialogue : Interactible
{
    public Dialogue dialogue;
    private Animator animator;
    public bool isUnlocked = false;
    private DialogueManager dialogueManager;
    public void TriggerDialogue(){
        dialogueManager.StartDialogue(dialogue);
    }
    public override void Interact()
     { 
        if(isUnlocked == false){
            TriggerDialogue();
        }
     }
    
    
    private void Start(){
        animator = GetComponent<Animator>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
    private void Update(){
        if(dialogue.isUnlocked == true){
            if(isUnlocked == false) {
                isUnlocked = true;
                Destroy(GetComponent<BoxCollider2D>());
            }
            
        }
    }
}
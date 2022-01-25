using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenableDoor : Interactible
{
    public Dialogue dialogue;
    
    public int noOfKeys = 1;
    private bool isUnlocked = false;
    private int keys = 0;
    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    public override void Interact()
     { 
        // verifica nr de chei daca avem nr de chei cheie corespunzatoare merge la urmatorul nivel
        keys = FindObjectOfType<PlayerInventory>().keys;
        if(keys == noOfKeys)
            isUnlocked = true;
        if(isUnlocked == false){
            TriggerDialogue();  
        }
        else
           {
               //incarcam scena cu nivelul urmator
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1) ;
           }
     }
    
}

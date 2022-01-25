
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public abstract class Interactible : MonoBehaviour
{
    private void Reset(){
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    public abstract void Interact();

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player")){
            //doo someting
        }
            
    }

    private void OnTriggerExit2D(Collider2D collider){
        if(collider.CompareTag("Player")){
            //doo someting
        }
            
    }
    
}

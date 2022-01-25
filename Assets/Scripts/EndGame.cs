using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
{
    public CharacterDialogue characterDialogue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(characterDialogue.isUnlocked == true){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1) ;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;
    public Text nameText;
    public Text dialogueText;

    public GameObject answer;
    private Queue<string> sentences;

    private int correctAnswer;
    
    public PlayerInventory playerInventory;
    private string ans;

    private Dialogue dialogue1;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update(){
        if(ans!=null){
            if(int.Parse(ans) == correctAnswer)
            {
                 dialogue1.isUnlocked = true;
            };
            }
         }
    // functia va afisa casuta de dialog cu elementele corespunzatoare
    public void StartDialogue(Dialogue dialogue){
        dialogue1 = dialogue;
        correctAnswer = dialogue.correctAnswer;
        animator.SetBool("InOpen", true);
        //Debug.Log("Starting Conversetion ");
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
         DisplayNextSentence();
         
         Time.timeScale = 0;
        
    }
    // functia v-a afisa pe rand fiecare propozitie din dialog
   public void DisplayNextSentence(){
       
       if(sentences.Count == 0){
           EndDialogue();
           return;
       }
       string sentence = sentences.Dequeue();
       if(sentence.Contains("?") == true){
           answer.SetActive(true);
           
       }
       else{
           answer.SetActive(false);
       }
       dialogueText.text = sentence;
   }

    // in cazul in care avem o intrepabare v-a lua raspunsul din input si v-a verifica daca este corect sau nu
   public void GetTextInput(){
       
    
        if(answer.GetComponent<InputField>().text!= null)
            ans =answer.GetComponent<InputField>().text;
        if(ans != null){
        if (int.Parse(ans) == correctAnswer){
            sentences.Enqueue("Raspuns corect!");
            playerInventory.keys += 1;
        }
        else{
            sentences.Enqueue("Raspuns gresit!");
        }
        }
        
   }
    // functie de inchidere a dialogului
   void EndDialogue(){
       animator.SetBool("InOpen", false);
       //Debug.Log("End of conversation");
       Time.timeScale = 1;
   }
}



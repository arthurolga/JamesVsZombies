using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTextGenerator : MonoBehaviour
{
    public int step =0;
    public GameObject txt;
    public GameObject btnTxt;
    public GameObject playerImg;
    public GameObject tutorialImg;
    private SpriteRenderer playerRenderer;


    // Start is called before the first frame update
    void Start()
    {
        if(playerImg){
            playerRenderer = playerImg.GetComponent<SpriteRenderer>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextStep(){
        step += 1;
        if(step == 1){
            txt.GetComponent<UnityEngine.UI.Text>().text = "The cook made some of her famous Meat Stew, after that everyone started turning into zombies";
        }
        if(step == 2){
            txt.GetComponent<UnityEngine.UI.Text>().text = "Thank god I'm vegetarian!";
            btnTxt.GetComponent<UnityEngine.UI.Text>().text = "Go to the big city";
        }
        if(step == 3){
            SceneManager.LoadScene("SecondScene");
        }

        
    }
    public void LoseNextStep(){
        step += 1;
        if(step == 1){
            txt.GetComponent<UnityEngine.UI.Text>().text = "I feel like I have a fever...";
        }
        if(step == 2){
            playerRenderer.color = Color.green;
            txt.GetComponent<UnityEngine.UI.Text>().text = "**RAWR**";
            btnTxt.GetComponent<UnityEngine.UI.Text>().text = "Restart Game";
        }
        if(step == 3){
            SceneManager.LoadScene("InitialScene");
        }

        
    }
    public void TutorialNextStep(){
        step += 1;
        if(step == 1){
            txt.GetComponent<UnityEngine.UI.Text>().text = "I better go to the <b>city</b> to find some answers";
        }
        if(step == 2){
            tutorialImg.GetComponent<UnityEngine.UI.Image>().enabled = true;
            txt.GetComponent<UnityEngine.UI.Text>().text = "But I think I know how to protect myself";
            btnTxt.GetComponent<UnityEngine.UI.Text>().text = "Understood!";
        }
        if(step == 3){
            SceneManager.LoadScene("InitialScene");
        }

        
    }
    public void EndGameStep(){
        step += 1;
        if(step == 1){
            txt.GetComponent<UnityEngine.UI.Text>().text = "It is all my fault! I guess I shouldn't have served it with that meat.. Oh, You are asking <b> Where did I get that meat?</b>";
        }
        if(step == 2){
            txt.GetComponent<UnityEngine.UI.Text>().text = "I found the meat wrapped in some sheets close to the graveyard";
        }
        if(step == 3){
            txt.GetComponent<UnityEngine.UI.Text>().text = "Now that I say it out loud it does sound stupid...";
            btnTxt.GetComponent<UnityEngine.UI.Text>().text = "Back to the Menu";
        }
        if(step == 4){
            SceneManager.LoadScene("InitialScene");
        }

        
    }
}

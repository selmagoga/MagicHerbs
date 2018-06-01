using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManangers : MonoBehaviour {

    public Image RecipeeUnroled;
    public Text RecipeeText;

    public Text CampionQuanText;
    public Text MuscariaQuanText;
    public Text BlueMushroomQuanText;
    public Text BlackthornQuanText;
    public Text RedMushQuanText;
    public Text PurpleMushQuanText;

    bool recipeeViewEnabled = true;

    public  Text sendOrderText;

    public Text HelpText;
    bool helpTextView = true;

    public void HelpButton()
    {
        if (!RecipeeIngredients.gameEnded)
        {
            helpTextView = !helpTextView;
            Debug.Log(HelpText.text);
            HelpText.enabled = helpTextView;
        }
    }

    void ExitButton()
    {
        Application.Quit();
    }


    // Update is called once per frame
    public void ViewOrderButton () {

        if (!RecipeeIngredients.gameEnded)
        {
            recipeeViewEnabled = !recipeeViewEnabled;
            RecipeeUnroled.enabled = recipeeViewEnabled;
            RecipeeText.enabled = recipeeViewEnabled;
        }
    }

    float timerSpeed = 3f; //time to X
    public void SendOrderButton()
    {
        if (!RecipeeIngredients.gameEnded)
        {

            int CampionQuan = Int32.Parse(CampionQuanText.text);
            int MuscariaQuan = Int32.Parse(MuscariaQuanText.text);
            int BlueMushroomQuan = Int32.Parse(BlueMushroomQuanText.text);
            int BlackthornQuan = Int32.Parse(BlackthornQuanText.text);
            int RedMushQuan = Int32.Parse(RedMushQuanText.text);
            int PurpleMushQuan = Int32.Parse(PurpleMushQuanText.text);

            bool allCampion = RecipeeIngredients.CampionQuan > 0 ? CampionQuan >= RecipeeIngredients.CampionQuan : true;
            bool allMuscaria = RecipeeIngredients.MuscariaQuan > 0 ? MuscariaQuan >= RecipeeIngredients.MuscariaQuan : true;
            bool allBlueMushroomQuan = RecipeeIngredients.BlueMushroomQuan > 0 ? BlueMushroomQuan>= RecipeeIngredients.BlueMushroomQuan : true;
            bool allBlackthornQuan = RecipeeIngredients.BlackthornQuan > 0 ? BlackthornQuan>= RecipeeIngredients.BlackthornQuan : true;
            bool allRedMushQuan = RecipeeIngredients.RedMushQuan > 0 ? RedMushQuan>= RecipeeIngredients.RedMushQuan : true;
            bool allPurpleMushQuan = RecipeeIngredients.PurpleMushQuan > 0 ? PurpleMushQuan>= RecipeeIngredients.PurpleMushQuan : true;

            if (allCampion && allMuscaria && allBlueMushroomQuan && allBlackthornQuan && allRedMushQuan && allPurpleMushQuan)
            {
                sendOrderText.text = "YOU WON!!!";
                sendOrderText.enabled = true;
                Time.timeScale = 0;
                RecipeeIngredients.gameEnded = true;
            }
            else
            {
                Debug.Log("NO WIN YET!!");

                Debug.Log(sendOrderText.text);
                sendOrderText.text = "Collect all ingredients for the order First!";

                Debug.Log(sendOrderText.text);
                sendOrderText.enabled = true;
                StartCoroutine(ActivateTimer());
               
                
            }
        }
      
    }

   
    private IEnumerator ActivateTimer()
    {
        yield return new WaitForSeconds(timerSpeed);
        sendOrderText.text = "";
       
        sendOrderText.enabled = false;
    }
}

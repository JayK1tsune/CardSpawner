using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardData : MonoBehaviour
{
    //get cardattributes from cardPrefab, Make sure you create a prefab for each card you wish to use for this this tool.
    public CardAttributes cardAttributes;

    //make Empty game objects and place in the below sprites required, make sure you have them set in the correct positions. 
    public SpriteRenderer backGround;
    public SpriteRenderer foxFace;
    public SpriteRenderer paws;
    public SpriteRenderer cardCost;
    
    void Start()
    {
        //set the sprites to the card attributes this can be moved to update if your card changes during the game.
        backGround.sprite = cardAttributes.background;
        foxFace.sprite = cardAttributes.FoxFace;
        paws.sprite = cardAttributes.Paws;
        cardCost.sprite = cardAttributes.cost;
    }
}

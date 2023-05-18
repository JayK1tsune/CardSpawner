using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardData : MonoBehaviour
{
    public CardAttributes cardAttributes;
    public SpriteRenderer backGround;
    public SpriteRenderer foxFace;
    public SpriteRenderer paws;
    public SpriteRenderer cardCost;
    // Start is called before the first frame update
    void Start()
    {
        backGround.sprite = cardAttributes.background;
        foxFace.sprite = cardAttributes.FoxFace;
        paws.sprite = cardAttributes.Paws;
        cardCost.sprite = cardAttributes.cost;

    }

}

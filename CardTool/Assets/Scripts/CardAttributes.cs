using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card Attributes", menuName = "Card Game/Card Attributes")]
public class CardAttributes : ScriptableObject
{
    public string cardName;
    public Sprite FoxFace;
    public Sprite Paws;
    public Sprite background;
    public Sprite cost;  

    //can add more but my cards only require these. 

    public void ModifyAttributes(string cardName, Sprite FoxFace, Sprite Paws, Sprite background, Sprite cost){
    this.cardName = cardName;
    this.FoxFace = FoxFace;
    this.Paws = Paws;
    this.background = background;
    this.cost = cost;   
    }

}


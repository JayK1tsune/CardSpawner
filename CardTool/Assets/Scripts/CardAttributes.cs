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
}


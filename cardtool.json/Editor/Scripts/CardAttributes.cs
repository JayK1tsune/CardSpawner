using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditor;
namespace cardtool
{
    [CreateAssetMenu(fileName = "New Card Attributes", menuName = "Card Game/Card Attributes")]
public class CardAttributes : ScriptableObject
{
    [SerializeField]
    private List<SerializedProperty> properties = new List<SerializedProperty>();

    public void AddProperty(SerializedProperty property)
    {
        properties.Add(property);
    }

    public string cardName;
    public Sprite FoxFace;
    public Sprite Paws;
    public Sprite background;
    public Sprite cost;  

    public void ModifyAttributes(string cardName, Sprite FoxFace, Sprite Paws, Sprite background, Sprite cost)
    {
        this.cardName = cardName;
        this.FoxFace = FoxFace;
        this.Paws = Paws;
        this.background = background;
        this.cost = cost;

        // Update the properties list
        properties.Clear();
        properties.Add(SerializedPropertyHelper.Create("cardName", cardName));
        properties.Add(SerializedPropertyHelper.Create("FoxFace", FoxFace));
        properties.Add(SerializedPropertyHelper.Create("Paws", Paws));
        properties.Add(SerializedPropertyHelper.Create("background", background));
        properties.Add(SerializedPropertyHelper.Create("cost", cost));
    }
    private SerializedProperty CreateSerializedProperty(string name, UnityEngine.Object value)
    {
        SerializedObject serializedObject = new SerializedObject(value);
        serializedObject.Update();

        SerializedProperty property = serializedObject.FindProperty(name);
        serializedObject.ApplyModifiedProperties();

        return property;
    }
}

//I had to create these classes specifically for handling string properties. It creates a temporary ScriptableObject to get a serialized object context, finds the property with the given name, and sets its value to the provided string value.
public static class SerializedPropertyHelper
{
    public static SerializedProperty Create<T>(string name, T value) where T : UnityEngine.Object
    {
        SerializedObject serializedObject = new SerializedObject(value);
        serializedObject.Update();

        SerializedProperty property = serializedObject.FindProperty(name);
        serializedObject.ApplyModifiedProperties();

        return property;
    }

    public static SerializedProperty Create(string name, string value)
    {
        SerializedObject serializedObject = new SerializedObject(new ScriptableObject());
        serializedObject.Update();

        SerializedProperty property = serializedObject.FindProperty("m_Script");
        SerializedProperty dataProperty = property.serializedObject.FindProperty(name);

        if (dataProperty != null)
            dataProperty.stringValue = value;

        serializedObject.ApplyModifiedPropertiesWithoutUndo();

        return dataProperty;
    }
}


}

using UnityEditor;
using UnityEngine;
namespace cardtool
{
    public class ModifyCardAttributesWindow : EditorWindow
{
    private CardAttributes cardAttributes;
    private Sprite foxFace;
    private Sprite paws;
    private Sprite background;
    private Sprite cost;
    public static void Open(CardAttributes attributes)
    {
        ModifyCardAttributesWindow window = GetWindow<ModifyCardAttributesWindow>("Modify Card Attributes");
        window.cardAttributes = attributes;
    }

    private void OnGUI()
    {
        // Display properties of the ScriptableObject and allow the user to modify them
        if (cardAttributes != null)
        {
            cardAttributes.cardName = EditorGUILayout.TextField("Card Name", cardAttributes.cardName);
            foxFace = (Sprite)EditorGUILayout.ObjectField("Fox Face Sprite", foxFace, typeof(Sprite), false);
            paws = (Sprite)EditorGUILayout.ObjectField("Paws Sprite", paws, typeof(Sprite), false);
            background = (Sprite)EditorGUILayout.ObjectField("Background Sprite", background, typeof(Sprite), false);
            cost = (Sprite)EditorGUILayout.ObjectField("Card Cost Sprite", cost, typeof(Sprite), false);
        }

        // Save changes to the ScriptableObject
        if (GUILayout.Button("Save Changes"))
        {
            cardAttributes.ModifyAttributes(cardAttributes.cardName,foxFace,paws,background,cost);
            EditorUtility.SetDirty(cardAttributes);
            Close();
        }
    }
}
}



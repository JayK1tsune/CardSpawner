using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class SO_Creator : EditorWindow
{
    private string cardName;
    private List<CardAttributes> createdObjects = new List<CardAttributes>();

    private void OnGUI()
    {
        GUILayout.Label("Create ScriptableObject", EditorStyles.boldLabel);

        cardName = EditorGUILayout.TextField("Card Name", cardName);

        if (GUILayout.Button("Create"))
        {
            CreateScriptableObject();
        }

        GUILayout.Space(10);

        GUILayout.Label("Created ScriptableObjects", EditorStyles.boldLabel);

        for (int i = 0; i < createdObjects.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Card Name: ", createdObjects[i].cardName);

            if (GUILayout.Button("Delete"))
            {
                DeleteScriptableObject(createdObjects[i]);
                createdObjects.RemoveAt(i);
                i--;
            }

            EditorGUILayout.EndHorizontal();
        }
    }

    private void CreateScriptableObject()
    {
        if (string.IsNullOrEmpty(cardName))
        {
            Debug.LogError("Card Name cannot be empty!");
            return;
        }

        CardAttributes newObject = ScriptableObject.CreateInstance<CardAttributes>();
        newObject.cardName = cardName;

        AssetDatabase.CreateAsset(newObject, "Assets/" + cardName + ".asset");
        AssetDatabase.SaveAssets();

        Debug.Log("Card created: " + cardName);

        createdObjects.Add(newObject);

        cardName = string.Empty;
    }

    private void DeleteScriptableObject(CardAttributes scriptableObject)
    {
        string assetPath = AssetDatabase.GetAssetPath(scriptableObject);
        AssetDatabase.DeleteAsset(assetPath);
        AssetDatabase.SaveAssets();
        Debug.Log("ScriptableObject deleted: " + scriptableObject.cardName);
    }

    [MenuItem("Window/SO Creator")]
    public static void ShowWindow()
    {
        GetWindow<SO_Creator>("SO Creator");
    }
}



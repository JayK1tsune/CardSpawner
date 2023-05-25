using UnityEngine;
using UnityEditor;
namespace cardtool
{
    public class CardSpawner : EditorWindow
{
    [SerializeField]
    private Transform spawner;
    public GameObject cardPrefab;
    private GameObject cardParent;
    private GameObject cardParentSpawner;
    private int cardCount = 1;
    private float cardScale = 1;
    public string parentName;
    public string cardName;

    public CardAttributes cardAttributes;
    

    [MenuItem("Window/Card Spawner")]
    public static void ShowWindow()
    {
        GetWindow<CardSpawner>("Card Spawner");
    }
    
	public void EmptyChild(){
		GameObject go = new GameObject(parentName);
		go.transform.parent = Selection.activeTransform;
		go.transform.localPosition = Vector3.zero;
		go.transform.localRotation = Quaternion.identity;
		go.transform.localScale = Vector3.one;
	}

    private void OnGUI()
    {
        cardAttributes = (CardAttributes)EditorGUILayout.ObjectField("Card Attributes", cardAttributes, typeof(CardAttributes), false);
        if (GUILayout.Button("Modify Card Attributes"))
            {
                ModifyCardAttributesWindow.Open(cardAttributes);
            }

        
        GUILayout.Label("Place Prefab of card here:", EditorStyles.boldLabel);
        GUILayout.Space(5);
        cardPrefab = (GameObject)EditorGUILayout.ObjectField("Card Prefab", cardPrefab, typeof(GameObject), false);
        cardName = EditorGUILayout.TextField("Card Name", cardName);
        GUILayout.Space(10);
        GUILayout.Label("Place Gameobject you wish to spawn cards into here: " + parentName, EditorStyles.boldLabel);
        cardParent = (GameObject)EditorGUILayout.ObjectField("Card Parent", cardParent, typeof(GameObject), true);
        GUILayout.Space(10);
        GUILayout.Label("Amount of cards to spawn: " + cardCount, EditorStyles.boldLabel);
        cardCount = EditorGUILayout.IntField("Card Count", cardCount);
        GUILayout.Space(10);
        cardScale = EditorGUILayout.Slider("Size of Card", cardScale, 0.5f,5f); 
        GUILayout.Space(20);
        GUILayout.Label("You can use this to create a new Parent for your cards here: ", EditorStyles.boldLabel);
        parentName = EditorGUILayout.TextField("Parent Name", parentName);

        if (GUILayout.Button("Spawn Cards"))
        {
            if (cardAttributes != null)
            {
                cardAttributes.cardName = cardName;
                EditorUtility.SetDirty(cardAttributes);
            }

            if (cardPrefab == null)
            {
                Debug.LogError("Card Prefab is null!");
                return;
            }

            if (cardParent == null)
            {
                Debug.LogError("Card Parent is null!");
                return;
            }

            for (int i = 0; i < cardCount; i++)
            {
                GameObject card = Instantiate(cardPrefab,cardParent.transform);
                card.transform.localScale = new Vector3(cardScale, cardScale, cardScale);
                card.name = cardName;
            }
        }
        if (GUILayout.Button("Create Parent")){
            if (Selection.activeGameObject == null){
                EmptyChild();
                cardParentSpawner = Selection.activeGameObject;
            }
            else{
                EmptyChild();
                cardParent = Selection.activeGameObject;
                cardParentSpawner = Selection.activeGameObject;
            }            
        }

        if (GUILayout.Button("Clear Cards"))
        {
            if (cardParent == null)
            {
                Debug.LogError("Card Parent is null!");
                return;
            }

            for (int i = 0; i < cardParent.transform.childCount; i++)
            {
                DestroyImmediate(cardParent.transform.GetChild(i).gameObject);
            }
        }

        if (GUILayout.Button("Clear Parents"))
        {
            if (cardParentSpawner == null){
                Debug.LogError("Card Parent Spawner is null!");
                return;
            }
            for (int i = 0; i < cardParentSpawner.transform.childCount; i++)
            {
                DestroyImmediate(cardParentSpawner.transform.GetChild(i).gameObject);
            }
        }
    }   
}

}

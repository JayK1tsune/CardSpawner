using UnityEngine;
using UnityEditor;

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
        

        GUILayout.Label("Card Spawner", EditorStyles.boldLabel);

        cardPrefab = (GameObject)EditorGUILayout.ObjectField("Card Prefab", cardPrefab, typeof(GameObject), false);
        cardName = EditorGUILayout.TextField("Card Name", cardName);
        GUILayout.Space(20);
        cardParent = (GameObject)EditorGUILayout.ObjectField("Card Parent", cardParent, typeof(GameObject), true);
        cardCount = EditorGUILayout.IntField("Card Count", cardCount);
        cardScale = EditorGUILayout.Slider("Size of Card", cardScale, 0.5f,5f); 
        parentName = EditorGUILayout.TextField("Parent Name", parentName);

        if (GUILayout.Button("Spawn Cards"))
        {
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

using UnityEngine;

[DefaultExecutionOrder(-10000)]
[CreateAssetMenu(fileName = "ScriptableObjectTest4", menuName = "ScriptableObjects/ScriptableObjectTest4")]
public class ScriptableObjectTest4 : ScriptableObject
{
    private static ScriptableObjectTest4 instance;
    public static ScriptableObjectTest4 Instance
    {
        get
        {
            if (instance == null)
            {
                //instance = FindObjectOfType<ScriptableObjectTest4>();
                if (instance == null)
                {
                    Debug.LogError("ScriptableObjectTest not found. Ensure it's added to Preloaded Assets in Player Settings.");
                }
            }
            
            return instance;
        }
    }

    [SerializeField] public string testValue = "Default Value";
    
    void OnEnable()
    {
        instance = this;
    }
}

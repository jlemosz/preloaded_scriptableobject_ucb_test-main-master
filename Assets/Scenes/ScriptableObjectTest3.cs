using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "ScriptableObjectTest3", menuName = "ScriptableObjects/ScriptableObjectTest3")]
public class ScriptableObjectTest3 : ScriptableObject
{
    private const string AssetPath = "Assets/Resources/ScriptableObjectTest3.asset";

    private static ScriptableObjectTest3 _instance;
    public static ScriptableObjectTest3 instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<ScriptableObjectTest3>("ScriptableObjectTest3");
                if (_instance == null)
                {
                    _instance = CreateAndSave();
                }
            }
            return _instance;
        }
    }

    public string testValue = "Default Value";

    private static ScriptableObjectTest3 CreateAndSave()
    {
        ScriptableObjectTest3 scriptableObject = ScriptableObject.CreateInstance<ScriptableObjectTest3>();

#if UNITY_EDITOR
        if (!Directory.Exists("Assets/Resources"))
        {
            Directory.CreateDirectory("Assets/Resources");
        }
        AssetDatabase.CreateAsset(scriptableObject, AssetPath);
        AssetDatabase.SaveAssets();
#endif

        return scriptableObject;
    }

    public void SetTestValue(string value)
    {
        testValue = value;

#if UNITY_EDITOR
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
#endif

        Debug.Log("ScriptableObjectTest3 value set: " + testValue);
    }
}

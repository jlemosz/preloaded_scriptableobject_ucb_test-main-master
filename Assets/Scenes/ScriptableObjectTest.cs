using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Scenes
{
    [DefaultExecutionOrder(-10000)]
    public class ScriptableObjectTest : ScriptableObject
    {
#if UNITY_EDITOR
        const string path = "Assets/" + nameof(ScriptableObjectTest) + ".asset";
        [InitializeOnLoadMethod]
        static void CheckCreated()
        {
            var settings = AssetDatabase.LoadAssetAtPath<ScriptableObjectTest>(path);
            if (settings == null)
            {
                settings = CreateInstance<ScriptableObjectTest>();
                AssetDatabase.CreateAsset(settings, path);
                AssetDatabase.SaveAssets();
            }

            var preloadedAssets = PlayerSettings.GetPreloadedAssets();
            if (!preloadedAssets.Contains(settings))
            {
                PlayerSettings.SetPreloadedAssets(preloadedAssets.Where(i => i != null).Append(settings).ToArray());
            }
        }
#endif
        public static ScriptableObjectTest instance { get; private set; }
        [SerializeField] public string testValue = "Default Value";

        void OnEnable()
        {
            instance = this;
        }
    }
}
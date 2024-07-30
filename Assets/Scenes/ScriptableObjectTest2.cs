using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
#endif

namespace Scenes
{
    [DefaultExecutionOrder(-10000)]
    public class ScriptableObjectTest2 : ScriptableObject
#if UNITY_EDITOR
        , IPreprocessBuildWithReport
#endif
    {
        const string path = "Assets/" + nameof(ScriptableObjectTest2) + ".asset";

        public static ScriptableObjectTest2 instance { get; private set; }
        [SerializeField] public string testValue = "Default Value";

#if UNITY_EDITOR
        public int callbackOrder { get { return 0; } }

        public void OnPreprocessBuild(BuildReport report)
        {
            CheckCreated();
        }

        static void CheckCreated()
        {
            var settings = AssetDatabase.LoadAssetAtPath<ScriptableObjectTest2>(path);
            if (settings == null)
            {
                settings = CreateInstance<ScriptableObjectTest2>();
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

        void OnEnable()
        {
            instance = this;
        }
    }
}
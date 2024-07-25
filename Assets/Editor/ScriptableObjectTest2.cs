using System.Linq;

#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;

namespace Scenes

{

    [DefaultExecutionOrder(-10000)]

    public class ScriptableObjectTest2 : ScriptableObject

    {

        [SerializeField] public string testValue = "Default Value";

        void OnEnable()

        {

            instance = this;

        }

        public static ScriptableObjectTest2 instance { get; private set; }

#if UNITY_EDITOR

// Pre-export method to be called by Unity Cloud Build

        public static void PreExport()

        {

            const string path = "Assets/" + nameof(ScriptableObjectTest2) + ".asset";

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

    }

}
using UnityEditor;
class MyEditorScript
{
    static void PerformBuild ()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] {"Assets/Scenes/SampleScene.unity"};
        buildPlayerOptions.target = BuildTarget.StandaloneOSX;
        buildPlayerOptions.options = BuildOptions.None;
        buildPlayerOptions.locationPathName = "OSXBuild";
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}
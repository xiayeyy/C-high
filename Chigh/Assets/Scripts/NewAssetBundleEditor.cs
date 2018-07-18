using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NewAssetBundleEditor : Editor
{



    [MenuItem("New AB Editor/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        //第一个参数获取的是AssetBundle存放的相对地址。
        BuildPipeline.BuildAssetBundles(
            AssetBundleConfig.ASSETBUNDLE_PATH.Substring(AssetBundleConfig.PROJECT_PATH.Length),
            BuildAssetBundleOptions.UncompressedAssetBundle |
            BuildAssetBundleOptions.CollectDependencies |
            BuildAssetBundleOptions.DeterministicAssetBundle,
            BuildTarget.StandaloneWindows64);
    }
}

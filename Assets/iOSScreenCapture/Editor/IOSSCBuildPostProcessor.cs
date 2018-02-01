using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System;
using System.IO;

public class IOSSCBuildPostProcessor
{
    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
    {
        if (target == BuildTarget.iOS)
        {
            OnPostProcessBuildIOS(pathToBuiltProject);
        }
    }

    public static void OnPostProcessBuildIOS(string pathToBuiltProject)
    {
#if UNITY_IOS
        string projPath = pathToBuiltProject + "/Unity-iPhone.xcodeproj/project.pbxproj";
        PBXProject proj = new UnityEditor.iOS.Xcode.PBXProject();
        proj.ReadFromString(File.ReadAllText(projPath));
        proj.AddFrameworkToProject(proj.TargetGuidByName("Unity-iPhone"), "Photos.framework", false);
        File.WriteAllText(projPath, proj.WriteToString());

        string plistPath = Path.Combine(pathToBuiltProject, "Info.plist");
        var plist = new PlistDocument();
        plist.ReadFromFile(plistPath);

        const string key = "NSPhotoLibraryUsageDescription";
        const string description = "Camera roll access permission is necessary for saving an image.";
        plist.root.SetString(key, description);

        plist.WriteToFile(plistPath);
#endif //UNITY_IOS
    }

}

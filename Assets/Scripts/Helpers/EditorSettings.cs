using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EditorSettings {

    private static string datapath = Application.dataPath;

    private static bool isDebug;
    public static bool InDebugMode
    {
        get
        {
            return isDebug;
        }
        set
        {

            isDebug = value;
        }
    }

    private static string logPath = null;
    public static string LogPath
    {
        get
        {
            logPath =  datapath+ "/Log";
                return logPath;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOfTest : MonoBehaviour
{
    private static bool isForestComplete = false;
    private static bool isLavaComplete = false;

    public static void lavaComplete () {
        isLavaComplete = true;
    }

    public static void forestComplete() {
        isForestComplete = true;
    }

    public static bool lavaLevelStatus () {
        return isLavaComplete;
    }

    public static bool forestLevelStatus () {
        return isForestComplete;
    }
    
    public static void reset () {
        isLavaComplete = false;
        isForestComplete = false;
    }
}

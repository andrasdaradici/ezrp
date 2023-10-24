using UnityEngine;
using UnityEditor;

public static class DiscordRichPresenceContextMenu
{
    [MenuItem("GameObject/Discord Rich Presence/Add RichPresence", false, 10)]
    private static void CreateRichPresenceGameObject(MenuCommand menuCommand)
    {
        // Create a new GameObject
        GameObject richPresenceObject = new GameObject("RichPresence");

        // Add the RichPresence script component to the GameObject
        DiscordRichPresence richPresenceScript = richPresenceObject.AddComponent<DiscordRichPresence>();

        // Add the RichPresence tag to the GameObject
        richPresenceObject.tag = "RichPresence";

        // Ensure the new GameObject is selected and active
        Selection.activeObject = richPresenceObject;
        EditorGUIUtility.PingObject(richPresenceObject);
    }
}
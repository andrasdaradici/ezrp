using System.Net.NetworkInformation;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Collections;
using UnityEngine;
using UnityEditor;
using System;
using EZRP;
using System.Net;
using UnityEngine.UIElements;

[CustomEditor(typeof(DiscordRichPresence))]
public class DiscordRichPresenceEditor : Editor
{
    bool ValidID;

    SerializedProperty presenceItems;

    private void OnEnable()
    {
        presenceItems = serializedObject.FindProperty("presenceItems");
    }

    public bool IsConnectedToInternet()
    {
        try
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            PingReply pingReply = ping.Send("8.8.8.8", 2000); // Google's public DNS server IP address with a timeout of 2000 milliseconds

            if (pingReply != null && pingReply.Status == IPStatus.Success)
            {
                return true;
            }
        }
        catch (SocketException)
        {
            // Handle the exception and return false (not connected to the internet)
        }

        return false;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        //base.OnInspectorGUI();
        DiscordRichPresence richPresence = (DiscordRichPresence)target;
        
        
        EditorGUILayout.Space();
        if(richPresence.status.ToLower() == "not connected") GUI.color = Color.red;
        else if (richPresence.status.ToLower().Contains("error")) GUI.color = Color.red;
        else if(richPresence.status.ToLower() == "connected") GUI.color = Color.green;
        EditorGUILayout.LabelField("Discord RichPresence state: " + richPresence.status, EditorStyles.boldLabel);
        GUI.color = Color.white;
        EditorGUILayout.Space();

        if (IsConnectedToInternet())
        {
            richPresence.CheckUpdate();
            if (richPresence.NeedToUpdate)
            {
                EditorGUILayout.LabelField("Current version: " + richPresence.version, EditorStyles.boldLabel);
                GUI.color = Color.green;
                EditorGUILayout.LabelField("Update available, newest version: " + richPresence.newestversion, EditorStyles.boldLabel);
                GUI.color = Color.white;
            }
            else
            {
                EditorGUILayout.LabelField("Current version: " + richPresence.version, EditorStyles.boldLabel);
            }
        }
        else if (IsConnectedToInternet() == false)
        {
            GUI.color = Color.yellow;
            EditorGUILayout.LabelField(new GUIContent("Current version: " + richPresence.version, "You are not connected to the internet so the asset cannot check for any updates!"), EditorStyles.boldLabel);
            GUI.color = Color.white;
        }

        Separator();

        if (richPresence.AppID == 0)
        {
            EditorGUILayout.LabelField("Please enter Application ID", EditorStyles.boldLabel);
            ValidID = false;
        }
        else
        {
            if(richPresence.AppID < 0) 
            {
                GUI.color = Color.red;
                EditorGUILayout.LabelField("Application ID cannot be negative", EditorStyles.boldLabel);
                GUI.color = Color.white;
                ValidID = false;
            }
            else if(richPresence.AppID > 0)
            {
                ValidID = true;
            }
        }
        richPresence.AppID = EditorGUILayout.LongField(new GUIContent("Application ID: ", "Example of Application ID: 1165670384549503007"), richPresence.AppID);

        if(ValidID == true)
        {
            EditorGUILayout.Space();
            if (richPresence.SceneBased == true) GUI.enabled = false;
            richPresence.Static = EditorGUILayout.Toggle("Static RichPresence", richPresence.Static);
            if (richPresence.SceneBased == true) GUI.enabled = true;

            if (richPresence.Static == true) GUI.enabled = false;
            richPresence.SceneBased = EditorGUILayout.Toggle("Scene Based RichPresence", richPresence.SceneBased);
            if (richPresence.Static == true) GUI.enabled = true;

            if (richPresence.Static == true)
            {
                Separator();
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Details and State of RichPresence", EditorStyles.boldLabel);
                richPresence.Details = EditorGUILayout.TextField(new GUIContent("Details", "Details of the game, f.e. \n• \"In the menu\" \n• \"Connecting to server\" \n• \"Slaying monsters\" "), richPresence.Details);
                richPresence.State = EditorGUILayout.TextField(new GUIContent("State", "State of the game, f.e. \n• \"Starting match\" \n• \"Displaying scores\" \n• \"Playing solo (1 out of 5)\" "), richPresence.State);
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Image assets of the RichPresence (Leave empty for no images)", EditorStyles.boldLabel);
                richPresence.LargeImageKey = EditorGUILayout.TextField(new GUIContent("Large Image Key", "Usually a \n• Game Logo \n• Player class icon \n• Map preview"), richPresence.LargeImageKey);
                richPresence.LargeImageText = EditorGUILayout.TextField(new GUIContent("Large Image Text", "Text that gets displayed when someone hovers over the large image"), richPresence.LargeImageText);
                richPresence.SmallImageKey = EditorGUILayout.TextField(new GUIContent("Small Image Key", "Usually a \n• Player class icon \n• Level number indicator \n• Game status indicator (finding lobby, connecting to match, etc)"), richPresence.SmallImageKey);
                richPresence.SmallImageText = EditorGUILayout.TextField(new GUIContent("Small Image Text", "Text that gets displayed when someone hovers over the small image"), richPresence.SmallImageText);
                EditorGUILayout.Space();
                EditorGUILayout.LabelField(new GUIContent("Elapsed time", "Show how much time the player spent in the game"), EditorStyles.boldLabel);
                richPresence.ShowElapsedTime = EditorGUILayout.Toggle("Show", richPresence.ShowElapsedTime);
            }
            if(richPresence.SceneBased == true)
            {
                Separator();
                EditorGUILayout.PropertyField(presenceItems, new GUIContent("RichPresence Items", "Add the RichPresence Items you created here. \nThe index of the item in the list represents what scene it will display it on. \n\nExample: \n• The current scene buildindex is 3 \n• The details of the RichPresence will be the same as the details of the item on the third index"), true);
                serializedObject.ApplyModifiedProperties();
                EditorGUILayout.Space();
                EditorGUILayout.LabelField(new GUIContent("Elapsed time", "Show how much time the player spent in the game"), EditorStyles.boldLabel);
                richPresence.ShowElapsedTime = EditorGUILayout.Toggle("Show", richPresence.ShowElapsedTime);
            }

            Separator();

            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.normal.textColor = HexToColor("#0000EE");
            buttonStyle.hover.textColor = HexToColor("#551A8B");
            if (GUILayout.Button(new GUIContent("Documentation", "Stuck? Need in help? \nClick to view the Documentation."), buttonStyle))
            {
                Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
            }
        }   
    }

    void Separator()
    {
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        Rect lineRect = EditorGUILayout.GetControlRect(false, 3);
        EditorGUI.DrawRect(lineRect, Color.gray);
        EditorGUILayout.Space();
        EditorGUILayout.Space();
    }

    private Color HexToColor(string hex)
    {
        Color color = new Color();
        ColorUtility.TryParseHtmlString(hex, out color);
        return color;
    }
}

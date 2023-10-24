using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine;
using Discord;
using System;
using EZRP;

public class DiscordRichPresence : MonoBehaviour
{
    #region [Main items]
    [HideInInspector]
    public long AppID;
    [HideInInspector]
    public string status = "Not connected";
    #endregion

    #region [Modes]
    [HideInInspector]
    public bool Static;
    [HideInInspector]
    public bool SceneBased;
    #endregion

    #region [Static RichPresence]
    [HideInInspector]
    public string Details;
    [HideInInspector]
    public string State;
    [HideInInspector]
    public string LargeImageKey;
    [HideInInspector]
    public string LargeImageText;
    [HideInInspector]
    public string SmallImageKey;
    [HideInInspector]
    public string SmallImageText;
    #endregion

    #region [Scene Based RichPresence]
    [HideInInspector]
    public List<RichPresenceItem> presenceItems = new List<RichPresenceItem>();
    #endregion

    #region [Time Elapsed]
    [HideInInspector]
    public bool ShowElapsedTime;
    [HideInInspector]
    private long StartTimeStamp;
    #endregion

    #region [Update Notice]
    public string version = "1.0.0";
    [HideInInspector]
    public string newestversion;
    [HideInInspector]
    public bool NeedToUpdate;
    static string VersionCheckURL = "http://www.lobby.nhely.hu/Assets/EZRP/LatestVersion.txt";
    #endregion

    public void CheckUpdate()
    {
        StartCoroutine(CheckVersion());
    }

    public IEnumerator CheckVersion()
    {
        UnityWebRequest www = UnityWebRequest.Get(VersionCheckURL);
        yield return www.SendWebRequest();
        string data = www.downloadHandler.text;
        if (version == data) NeedToUpdate = false;
        else
        {
            NeedToUpdate = true;
            newestversion = data;
        }
    }

    private Discord.Discord discord;
    void Awake()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("RichPresence");

        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != gameObject) // Don't destroy the current GameObject calling the function
            {
                Destroy(obj);
            }
        }

        discord = new Discord.Discord(AppID, (UInt64)Discord.CreateFlags.Default);
        UpdateDiscordPresence();

        StartTimeStamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        DontDestroyOnLoad(this);
    }

    void UpdateDiscordPresence()
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Activity { Instance = true };
        if (Static)
        {
            activity = new Activity
            {
                Details = Details,
                State = State,
                Assets = new ActivityAssets
                {
                    LargeImage = LargeImageKey,
                    LargeText = LargeImageText,
                    SmallImage = SmallImageKey,
                    SmallText = SmallImageText
                },
                Instance = true
            };
        }
        if (SceneBased)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            activity = new Activity
            {
                Details = presenceItems[sceneIndex].Details,
                State = presenceItems[sceneIndex].State,
                Assets = new ActivityAssets
                {
                    LargeImage = presenceItems[sceneIndex].LargeImageKey,
                    LargeText = presenceItems[sceneIndex].LargeImageText,
                    SmallImage = presenceItems[sceneIndex].SmallImageKey,
                    SmallText = presenceItems[sceneIndex].SmallImageText
                },
                Instance = true
            };
        }
        if (ShowElapsedTime)
        {
            activity.Timestamps.Start = StartTimeStamp;
        }
        activityManager.UpdateActivity(activity, result =>
        {
            if (result == Result.Ok)
            {
                Debug.Log("Discord Presence Updated Successfully");
                status = "Connected";
            }
            else
            {
                Debug.LogError("Error updating Discord Presence: " + result);
                status = "Error \n" + result;
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDiscordPresence();
        discord.RunCallbacks();
    }

    private void OnDestroy()
    {
        if (discord != null)
        {
            discord.Dispose();
        }
    }
}

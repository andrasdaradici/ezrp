using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public int PlayerCount;
    public TextMeshProUGUI TotalPlayers;
    public DiscordRichPresence rp;
    public void PlayerChange(string addorsub)
    {
        if (addorsub == "-") PlayerCount--;
        else if(addorsub == "+") PlayerCount++;
    }

    void Start()
    {
        rp = GameObject.FindGameObjectWithTag("RichPresence").GetComponent<DiscordRichPresence>();
    }

    void Update()
    {
        rp.State = "Playing solo (1 of " + PlayerCount.ToString() + ")";
        TotalPlayers.text = PlayerCount.ToString();
        if (PlayerCount < 4)
        {
            PlayerCount = 4;
        }
        if(PlayerCount > 99)
        {
            PlayerCount = 99;
        }
    }
}

﻿using UnityEngine;
using System.Collections;
using System.Linq;
using Facepunch.Steamworks;

public class SteamTest : MonoBehaviour
{
    public static Facepunch.Steamworks.Client SteamClient;

	void Start ()
    {
        //
        // Create the steam client using Rust's AppId
        //
        SteamClient = new Client( 252490 );

        //
        // Make sure we started up okay
        //
        if ( !SteamClient.IsValid )
        {
            SteamClient.Dispose();
            SteamClient = null;
            return;
        }
    }

    void OnGUI()
    {
        GUILayout.BeginArea( new Rect( 16, 16, Screen.width - 32, Screen.height - 32 ) );

        if ( SteamClient != null )
        {
            GUILayout.Label( "SteamId: " + SteamClient.SteamId );
            GUILayout.Label( "Username: " + SteamClient.Username );

            GUILayout.Label( "Friend Count: " + SteamClient.Friends.AllFriends.Count() );
            GUILayout.Label( "Online Friend Count: " + SteamClient.Friends.AllFriends.Count( x => x.IsOnline ) );
        }
        else
        {
            GUILayout.Label( "SteamClient Failed" );
        }

        GUILayout.EndArea();
    }

}
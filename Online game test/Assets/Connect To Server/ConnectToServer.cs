using System;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("1_________________");
    }

    public void OnConnectedToServer()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("2_________________");

    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
        Debug.Log("3_________________");

    }
}

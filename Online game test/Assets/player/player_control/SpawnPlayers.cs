using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    [SerializeField] private Vector3 cordinate;
    [SerializeField] private Vector3 cordinate2;
    private int count;
    private void Start()
    {
        count = PlayerPrefs.GetInt("AAA",0);
        if (count == 0)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, cordinate, Quaternion.identity);
            PlayerPrefs.SetInt("AAA",1);
        }
        if (count == 1)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, cordinate2, Quaternion.identity);
            PlayerPrefs.SetInt("AAA",0);
        }
        PlayerPrefs.Save();
        // Перевіряємо, чи цей об'єкт належить локальному гравцеві
        
        
    }
}

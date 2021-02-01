using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text roomName;

    private void Start()
    {
        Debug.Log("Connectingto Master!");
        MenuManager.Instance.OpenMenu("Loading");

        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected!");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        MenuManager.Instance.OpenMenu("Title");
        Debug.Log("Joined Lobby!");
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);
        MenuManager.Instance.OpenMenu("Loading");

    }

    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenu("Room");
        roomName.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    { 
        Menu error = MenuManager.Instance.OpenMenuAndReturn("Error");
        error.gameObject.GetComponent<ErrorMessage>().message = returnCode +  " : Room creation failed " + message ;
        Debug.LogError(message);
    }

    public void LeaveRoom() { PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("Loading");

    }
    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("Title");
    }

}

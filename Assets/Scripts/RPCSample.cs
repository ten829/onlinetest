using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RPCSample : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //if (Input.GetMouseButtonDown(0)) {
          //  photonView.RPC(nameof(RpcSendMessage), RpcTarget.All, "こんにちは");
        //}

    }
    [PunRPC]
    private void RpcSendMessage(string message, PhotonMessageInfo info)
    {
        Debug.Log($"{info.Sender.NickName}:{message}");
    }
}

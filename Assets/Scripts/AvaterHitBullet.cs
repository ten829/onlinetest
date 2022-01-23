using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class AvaterHitBullet : MonoBehaviourPunCallbacks
{
    private void OnTriggerEnter(Collider other)
    {
        if(photonView.IsMine)
        {
            if(other.TryGetComponent(out bullet bullet) == true)
            {
                if(bullet.OwnerId != PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    photonView.RPC(nameof(HitBullet), RpcTarget.All, bullet.BulletcountId, bullet.OwnerId);
                }
            }
        }
    }
    [PunRPC]
    private void HitBullet(int bulletcountId, int ownerId)
    {
        Debug.Log(bulletcountId);
        Debug.Log(ownerId);
        var bullets = FindObjectsOfType<bullet>();
        foreach (var bullet in bullets)
        {
            if (bullet.Equals(bulletcountId, ownerId))
            {
        
                Destroy(bullet.gameObject);
                break;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

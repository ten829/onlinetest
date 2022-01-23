using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class AvaterFireBullet : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public Material[] materials;
    [SerializeField]
    private bullet bulletPrefab = default;
    private int nextBulletId = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //var mousePositon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ray.direction = new Vector3(ray.direction.x, ray.direction.y, 0);
                var direction = ray.direction - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x);
               

                //FireBullet(angle,direction);
                photonView.RPC(nameof(FireBullet), RpcTarget.All, angle, direction, nextBulletId++);
            }
        }
        
    }
    [PunRPC]
    private void FireBullet(float angle,Vector3 direction,int nextBulletId) {
        var bullet = Instantiate(bulletPrefab,transform.position,Quaternion.identity);
        // bullet.Init(transform.position, angle);
        bullet.shooot(direction.normalized,nextBulletId,photonView.OwnerActorNr,materials[photonView.OwnerActorNr]);
    }

}

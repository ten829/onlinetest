using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Vector3 velocity;
    public int BulletcountId { get; private set; }
    public int OwnerId { get; private set; }
    public bool Equals(int id, int ownerId) => id == BulletcountId && ownerId == OwnerId;
    public void shooot(Vector3 direction, int bulletcountId, int ownerId,Material material)
    {
        Debug.Log(material.name);
        BulletcountId = bulletcountId;
        OwnerId =ownerId;
        //GetComponent<MeshRenderer>().materials[0]=material;
        GetComponent<MeshRenderer>().material.color = material.color;
        Rigidbody rb =  GetComponent<Rigidbody>();
        rb.AddForce(direction * 300f);
        Debug.Log(direction);
    }

    public void Init(int id,int ownerId,Vector3 origin, float angle)
    {
       
        transform.position = origin;
        velocity = 9f * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //transform.Translate(velocity * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

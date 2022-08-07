using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    [SerializeField] private List<Material> materials = new List<Material>();
    private GameObject player;
    private LineRenderer balloonLineRenderer;
    private Rigidbody balloonRigidbody;
    private int materialNum;
    private int lineLength = 4;

    void Awake()
    {
        balloonRigidbody = GetComponent<Rigidbody>();
        balloonLineRenderer = GetComponent<LineRenderer>();
        player = GameObject.Find("Player");

        materialNum = Random.Range(0, 5);
        GetComponent<MeshRenderer>().material = materials[materialNum];

        LeanTween.scale(this.gameObject, Vector3.one, 2);
    }

    private void Update() 
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < lineLength)
        {
            balloonLineRenderer.SetPosition(1, player.transform.position);
            balloonLineRenderer.SetPosition(0, transform.position);
            balloonRigidbody.AddExplosionForce(5, Vector3.one*Random.Range(-2,2), 2, 5 , ForceMode.Acceleration);
        }
        else
        {
            balloonRigidbody.constraints = RigidbodyConstraints.FreezePosition;
        }
    }
}

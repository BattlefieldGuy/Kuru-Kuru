using UnityEngine;

public class ObstaclePP : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;

    [Header("Push")]

    [SerializeField] private float pushForceL1;
    [SerializeField] private float pushForceL2;
    [SerializeField] private float pushForceL3;

    [Header("Pull")]
    [SerializeField] private float pullForceL1;
    [SerializeField] private float pullForceL2;
    [SerializeField] private float pullForceL3;

    void Start()
    {
        if (player == null)
            player = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("pushG"))
        {
            player.AddForce(other.transform.up * pushForceL1);
        }
        else if (other.gameObject.CompareTag("pushB"))
        {
            player.AddForce(other.transform.up * pushForceL2);
        }
        else if (other.gameObject.CompareTag("pushR"))
        {
            player.AddForce(other.transform.up * pushForceL3);
        }
        else if (other.gameObject.CompareTag("pullG"))
        {
            player.AddForce(-other.transform.up * pullForceL1);
        }
        else if (other.gameObject.CompareTag("pullB"))
        {
            player.AddForce(-other.transform.up * pullForceL2);
        }
        else if (other.gameObject.CompareTag("pullR"))
        {
            player.AddForce(-other.transform.up * pullForceL3);
        }
    }
}
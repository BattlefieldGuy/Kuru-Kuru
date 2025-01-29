using System.Collections;
using UnityEngine;

public class PlayerRespawnManager : MonoBehaviour
{
    [SerializeField] private AudioSource src;
    [SerializeField] private AudioClip RespawnClip;

    private Vector2 respawnPoint = Vector2.zero;

    private Rigidbody2D playerRB;

    void Start()
    {
        src = this.GetComponent<AudioSource>();
        playerRB = this.GetComponent<Rigidbody2D>();
    }
    public void Respawn()
    {
        this.gameObject.transform.position = respawnPoint;
        src.PlayOneShot(RespawnClip);
        StartCoroutine(ResetAfter());
        Time.timeScale = 1f;
    }

    private IEnumerator ResetAfter()
    {
        yield return new WaitForSeconds(1f);
        playerRB.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RespawnPoint"))
            respawnPoint = other.transform.position;
    }
}
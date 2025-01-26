using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] private Player player;

    public Vector2 RespawnPoint;

    private void Start()
    {
        RetrievePlayer();
    }

    void RetrievePlayer()
    {
        if (player == null)
        {
            if (player = FindAnyObjectByType<Player>())
            {
                Debug.Log("Player succesfully found");
            }
            else
                Debug.LogError(player);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {

        }
    }
}
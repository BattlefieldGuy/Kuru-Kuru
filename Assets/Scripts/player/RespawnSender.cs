using UnityEngine;

public class RespawnSender : MonoBehaviour
{
    private PlayerRespawnManager manager;

    void Start() => manager = FindFirstObjectByType<PlayerRespawnManager>();

    public void Respawn()
    {
        manager.Respawn();
        gameObject.SetActive(false);
    }
}
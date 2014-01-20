using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }

        if (gameController == null)
        {
            Debug.LogError("Cannot find 'GameController' script", transform);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);
        if (other.collider.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        } else
        {
            gameController.AddScore(scoreValue);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
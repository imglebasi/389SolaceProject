using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Hug hug1; // Reference to Hug component on player1
    public Hug hug2; // Reference to Hug component on player2
    public float moveSpeed = 5f;
    public float spawnAreaMinX = -10f; // Minimum X for random spawn
    public float spawnAreaMaxX = 10f;  // Maximum X for random spawn
    public float spawnAreaMinY = -10f; // Minimum Y for random spawn
    public float spawnAreaMaxY = 10f;  // Maximum Y for random spawn

    private bool isChasing = false;

    void Update()
    {
        // Check if both players are hugging (safe)
        if (hug1.isSafe && hug2.isSafe)
        {
            Despawn();
        }
        else
        {
            // Spawn if not already active
            if (!gameObject.activeSelf)
            {
                SpawnAtRandomPosition();
            }

            // Chase the nearest player
            ChaseNearestPlayer();
        }
    }

    private void ChaseNearestPlayer()
    {
        float distanceToPlayer1 = Vector2.Distance(transform.position, player1.position);
        float distanceToPlayer2 = Vector2.Distance(transform.position, player2.position);

        Transform nearestPlayer = distanceToPlayer1 < distanceToPlayer2 ? player1 : player2;

        // Move towards the nearest player
        transform.position = Vector2.MoveTowards(transform.position, nearestPlayer.position, moveSpeed * Time.deltaTime);

        // Check if the monster has reached the player
        if (Vector2.Distance(transform.position, nearestPlayer.position) < 1.5f) // Adjust as needed
        {
            // Game over - reset the scene
            GameManager.instance.RestartGame();
        }
    }

    private void SpawnAtRandomPosition()
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(spawnAreaMinX, spawnAreaMaxX),
            Random.Range(spawnAreaMinY, spawnAreaMaxY)
        );
        transform.position = randomPosition;
        gameObject.SetActive(true);
        isChasing = true;
    }

    private void Despawn()
    {
        isChasing = false;
        gameObject.SetActive(false); // Deactivate the monster
    }
}

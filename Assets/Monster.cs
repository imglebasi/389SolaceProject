using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float moveSpeed = 5f;
    public float detectionRange = 10f;
    public float despawnDistance = 30f; // Maximum distance before despawn
    public bool isChasing = false;

    private Collider2D player1Collider;
    private Collider2D player2Collider;

    void Start()
    {
        // Cache collider components
        player1Collider = player1.GetComponent<Collider2D>();
        player2Collider = player2.GetComponent<Collider2D>();

        // Ensure colliders are present
        if (player1Collider == null)
            Debug.LogError("Player1 is missing a Collider2D component!");
        if (player2Collider == null)
            Debug.LogError("Player2 is missing a Collider2D component!");
    }

    void Update()
    {
        // Skip updates if colliders are missing
        if (player1Collider == null || player2Collider == null)
            return;

        float distanceToPlayer1 = Vector2.Distance(transform.position, player1.position);
        float distanceToPlayer2 = Vector2.Distance(transform.position, player2.position);

        // Despawn if the monster is too far from both players
        if (distanceToPlayer1 > despawnDistance && distanceToPlayer2 > despawnDistance)
        {
            Despawn();
            return;
        }

        // Check if players are colliding
        bool playersColliding = player1Collider.bounds.Intersects(player2Collider.bounds);

        if (!playersColliding)
        {
            // Determine the nearest player to chase
            Transform nearestPlayer = distanceToPlayer1 < distanceToPlayer2 ? player1 : player2;
            isChasing = true;

            // Move towards the nearest player
            transform.position = Vector2.MoveTowards(transform.position, nearestPlayer.position, moveSpeed * Time.deltaTime);

            // Check if the monster has reached the player
            if (Vector2.Distance(transform.position, nearestPlayer.position) < 1.5f) // Adjust as needed
            {
                // Game over - reset the scene
                GameManager.instance.RestartGame();
            }
        }
        else
        {
            // Stop chasing if players are colliding
            isChasing = false;
        }
    }

    public void StartChase()
    {
        isChasing = true;
        gameObject.SetActive(true); // Reactivate the monster on chase start
    }

    public void StopChase()
    {
        isChasing = false;
    }

    private void Despawn()
    {
        isChasing = false;
        gameObject.SetActive(false); // Deactivate the monster when it despawns
    }
}

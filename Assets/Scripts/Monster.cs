using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float moveSpeed = 5f;
    public float detectionRange = 10f;
    public float despawnDistance = 30f; // Maximum distance before despawn
    public bool isChasing = false;

    private bool isSafe = true; // Track if players are safe or not (derived from collision)
    private bool hasSpawned = false; // To check if the monster has already been spawned

    void Start()
    {
        // Make sure both players are properly assigned
        if (player1 == null || player2 == null)
        {
            Debug.LogError("Player1 or Player2 is not assigned.");
        }
    }

    void Update()
    {
        // Check for collision between the two players
        bool playersColliding = ArePlayersColliding();

        // If players are colliding, set isSafe to true
        isSafe = playersColliding;

        // If players are safe (colliding), stop chasing and freeze monster
        if (isSafe)
        {
            StopChasing(); // Stop chasing when players are safe
            return; // Skip the rest of the logic if it's safe
        }

        // If it's not safe and the monster hasn't spawned yet, activate the monster
        if (!isSafe && !hasSpawned)
        {
            Debug.Log("Players are not colliding, spawning monster.");
            hasSpawned = true; // Mark that the monster has been spawned
        }

        // Proceed with the rest of the monster's behavior if it has been spawned
        if (hasSpawned && !isSafe)
        {
            ChasePlayers();
        }
    }

    // Method to check if the players are colliding
    private bool ArePlayersColliding()
    {
        Collider2D collider1 = player1.GetComponent<Collider2D>();
        Collider2D collider2 = player2.GetComponent<Collider2D>();

        if (collider1 != null && collider2 != null)
        {
            // Check if the two players are overlapping using their colliders
            return collider1.bounds.Intersects(collider2.bounds);
        }

        return false;
    }

    // Method to stop the monster from chasing (freeze its movement)
    private void StopChasing()
    {
        isChasing = false;
    }

    // Method to make the monster chase the players
    private void ChasePlayers()
    {
        // Determine the nearest player to chase
        float distanceToPlayer1 = Vector2.Distance(transform.position, player1.position);
        float distanceToPlayer2 = Vector2.Distance(transform.position, player2.position);

        Transform nearestPlayer = distanceToPlayer1 < distanceToPlayer2 ? player1 : player2;

        // If monster is far from both players, don't chase
        if (distanceToPlayer1 > despawnDistance && distanceToPlayer2 > despawnDistance)
        {
            StopChasing();
            return;
        }

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
}

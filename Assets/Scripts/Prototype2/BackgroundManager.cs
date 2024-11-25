using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject safeBackground; // Reference to the safe background image
    public GameObject unsafeBackground; // Reference to the unsafe background image
    public AudioSource safeMusic; // AudioSource for safe music
    public AudioSource scaryMusic; // AudioSource for scary music
    public Hug hugScript; // Reference to the Hug script to check the isSafe status

    void Update()
    {
        if (hugScript != null)
        {
            // Update background images based on isSafe
            safeBackground.SetActive(hugScript.isSafe);
            unsafeBackground.SetActive(!hugScript.isSafe);

            // Update music based on isSafe
            if (hugScript.isSafe)
            {
                PlaySafeMusic();
            }
            else
            {
                PlayScaryMusic();
            }
        }
        else
        {
            Debug.LogError("Hug script reference is missing.");
        }
    }

    private void PlaySafeMusic()
    {
        if (!safeMusic.isPlaying)
        {
            scaryMusic.Stop();
            safeMusic.Play();
        }
    }

    private void PlayScaryMusic()
    {
        if (!scaryMusic.isPlaying)
        {
            safeMusic.Stop();
            scaryMusic.Play();
        }
    }
}


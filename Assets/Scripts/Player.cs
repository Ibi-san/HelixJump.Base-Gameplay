using Assets.Scripts;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public float MaxSpeed;

    public Rigidbody Rigidbody;
    public Game Game;
    public Platform CurrentPlatform;

    public void ReachFinish()
    {
        Game.OnPlayerReachedFinish();
        Rigidbody.velocity = Vector3.zero;
    }

    public void Bounce()
    {
        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    public void Die()
    {
        Game.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        if (Rigidbody.velocity.magnitude > MaxSpeed)
        {
            Rigidbody.velocity = Rigidbody.velocity.normalized * MaxSpeed;
        }
    }
}

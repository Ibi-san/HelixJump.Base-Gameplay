using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Controls Controls;
    public Material PlayerMaterial;
    public string PropertyName;
    public ParticleSystem Confetti;
    public ParticleSystem Death;

    private float DissolveValue = 0;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }

    private void Start()
    {
        PlayerMaterial.SetFloat(PropertyName, 0);
    }

    private void Update()
    {
        if (CurrentState == State.Loss)
        {
            PlayerMaterial.SetFloat(PropertyName, DissolveValue);
            DissolveValue += Time.deltaTime;
            if (DissolveValue >= 1)
                ReloadLevel();
        }

        if (CurrentState == State.Won)
        {
            if (Confetti.isStopped) ReloadLevel();
        }
    }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        Controls.enabled = false;
        Debug.Log("Game Over! Try again!");
        PlayerPrefs.SetInt("DestroyedPlatform", 0);
        Death.Play();
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        Controls.enabled = false;
        LevelIndex++;
        Debug.Log("Next level! You are great!");
        Confetti.Play();
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string LevelIndexKey = "LevelIndex";

    private void ReloadLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);;
    }
}

using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public int scoreToWin = 5;

    [Header("Game Elements")]
    [SerializeField]
    private CinemachineCamera camera;
    [SerializeField]
    private PlayerController playerPrefab;
    [SerializeField]
    private Transform spawnHierarchyParent;
    [SerializeField]
    private Transform spawnLocation;

    [Header("UI Elements")]
    [SerializeField]
    private MovementPanel movementPanel;
    [SerializeField]
    private FontScaler fontScaler;
    [SerializeField]
    private PausePanel pausePanel;
    [SerializeField]
    private PauseButton pauseButton;

    public MovementPanel MovementPanel { get => movementPanel; }

    private List<PlayerController> spawnedPlayers = new List<PlayerController>();

    private void Start()
    {
        pausePanel.SetGameState(GameState.Prespawn);
        pausePanel.gameObject.SetActive(true);
        pausePanel.OnPlayButtonClicked += Play;
        pausePanel.OnResumeButtonClicked += Resume;
        pauseButton.OnPauseButtonClicked += Pause;
    }

    private void Play()
    {
        Time.timeScale = 1;
        SpawnPlayer();
        BindCollectors();
        pausePanel.gameObject.SetActive(false);
    }

    private void Pause()
    {
        pausePanel.SetGameState(GameState.Paused);
        pausePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void Resume()
    {
        Time.timeScale = 1;
        pausePanel.gameObject.SetActive(false);
    }

    private void SpawnPlayer()
    {
        PlayerController player = Instantiate(playerPrefab, spawnLocation.position, Quaternion.identity, spawnHierarchyParent);
        player.Initialize(movementPanel);
        spawnedPlayers.Add(player);
        camera.Follow = player.transform;
    }

    private void BindCollectors()
    {
        foreach (var player in spawnedPlayers)
        {
            var collector = player.GetComponent<Collector>();
            if (collector == null)
                return;
            collector.OnCollect += ScoreIncreased;
        }
    }

    private void ScoreIncreased(Collector sender, int newScore)
    {
        if (newScore >= scoreToWin)
        {
            Debug.Log(sender.gameObject.name + " wins with score: " + newScore);
            fontScaler.gameObject.SetActive(true);
            fontScaler.Animate();
        }
    }
}

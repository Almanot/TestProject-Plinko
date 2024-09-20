using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class GameController : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    public InputField ballsInputField;
    public Button spawnButton;
    public Button ResetButton;
    public float minSpawnInterval = 0.1f;
    public List<Target> targets;

    private void Start()
    {
        spawnButton.onClick.AddListener(StartSpawningBalls);
        ResetButton.onClick.AddListener(ResetTargets);
    }

    private void StartSpawningBalls()
    {
        int ballCount = int.Parse(ballsInputField.text);
        StartCoroutine(SpawnBalls(ballCount));
    }

    private IEnumerator SpawnBalls(int ballCount)
    {
        float spawnInterval = Mathf.Max(minSpawnInterval, 1f / ballCount);

        for (int i = 0; i < ballCount; i++)
        {
            Vector3 randomRange = new Vector3(Random.Range(-0.1f, 0.1f), 0, 0);
            Vector3 spawnPosition = spawnPoint.position + randomRange;
            Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void ResetTargets()
    {
        foreach (var target in targets)
        {
            target.ResetCount();
        }
    }
}

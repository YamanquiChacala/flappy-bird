using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject pipes;
    [SerializeField] private float pipeTime;
    [SerializeField] private float maxHeightVariance;

    private float timer = 0;

    private void Update() {
        if(timer > pipeTime) {
            SpawnPipe();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void SpawnPipe() {
        Vector3 spawnPosition = Random.Range(-maxHeightVariance, maxHeightVariance) * Vector3.up + transform.position;
        GameObject newPipe = Instantiate(pipes);
        newPipe.transform.position = spawnPosition;
    }
}

using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    public float minX = -5f; // X 축 최소값
    public float maxX = 5f;  // X 축 최대값
    public float minY = -5f; // Y 축 최소값
    public float maxY = 5f;  // Y 축 최대값
    public float spawnInterval = 5f;// 생성되는 주기(초)

    void Start()
    {
        InvokeRepeating("SpawnfallingObject", 5f, spawnInterval);
    }
    void SpawnfallingObject()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
        GameObject fallingObject = Instantiate(fallingObjectPrefab, randomPosition, Quaternion.identity);
    }
}

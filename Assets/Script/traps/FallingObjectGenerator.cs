using UnityEngine;

public class FallingObjectGenerator : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    public float minX = -5f; // X 축 최소값
    public float maxX = 5f;  // X 축 최대값
    public float minY = -5f; // Y 축 최소값
    public float maxY = 5f;  // Y 축 최대값
    // Start is called before the first frame update
    void Start()
    {
        GenerateFallingObject();
    }

    // Update is called once per frame
    void GenerateFallingObject()
    {
        // 랜덤한 위치 생성
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        GameObject fallingObject = Instantiate(fallingObjectPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);

        FallingObject fallingObjectScript = fallingObject.AddComponent<FallingObject>();
        fallingObjectScript.minX = minX;
        fallingObjectScript.maxX = maxX;
        fallingObjectScript.minY = minY;
        fallingObjectScript.maxY = maxY;
    }
}

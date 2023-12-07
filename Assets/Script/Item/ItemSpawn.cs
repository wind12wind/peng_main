using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] itemBox;
    [SerializeField] private Transform itemBoxObject;

    private float minX = -26f;
    private float maxX = 26f;
    private float minY = -41f;
    private float maxY = 6.5f;

    private float spawnTimer;
    private float itemBoxTimer;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        itemBoxTimer += Time.deltaTime;

        if (spawnTimer >= 5f)
        {
            spawnTimer = 0;
            PotionRandomSpawn();
        }

        if (itemBoxTimer >= 5f)
        {
            itemBoxTimer= 0;
            ItemBoxRandomSpawn();
        }
    }

    private void PotionRandomSpawn()
    {
        int random = Random.Range(0, 5);
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
        
        switch (random)
        {
            case 0:
                GameObject hpPotion = Instantiate(itemBox[1], randomPosition, Quaternion.identity);
                hpPotion.transform.parent = transform;
                break;
            case 1:
                GameObject mpPotion = Instantiate(itemBox[2], randomPosition, Quaternion.identity);
                mpPotion.transform.parent = transform;
                break;
            case 2:
                GameObject speedPotion = Instantiate(itemBox[3], randomPosition, Quaternion.identity);
                speedPotion.transform.parent = transform;
                break;
            default:
                //Debug.Log("²Î");
                break;
        }
    }

    private void ItemBoxRandomSpawn()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));

        GameObject randomBox = Instantiate(itemBox[0], randomPosition, Quaternion.identity);
        randomBox.transform.parent = transform;

    }
}

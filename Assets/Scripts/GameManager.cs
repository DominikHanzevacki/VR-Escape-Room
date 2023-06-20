using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    public List<GameObject> spawnedItems;

    public TextMeshPro task;

    private string secondPart = " and put it into the drawer!";

    private List<string> items = new List<string> { "a toy sword", "a fidget spinner", "a pencil" };
    private string firstPart = "Hi Player, find ";
    private int itemsFound = 0;
    private float countdown = 10f;

    public static GameManager instance;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (itemsFound == 3)
        {
            task.text = "Congratulations! You have completed the game!";
        }
    }

    public void CollisionDetected()
    {
        ItemFound();
    }

    private void StartGame()
    {
        for (int i = 0; i < spawnedItems.Count; i++)
        {
            int randomSpawnPoint = Random.Range(0, 4 - i);
            spawnedItems[i].transform.position = spawnPoints[randomSpawnPoint].transform.position;
            spawnPoints.Remove(spawnPoints[randomSpawnPoint]);
        }
        task.text = GetInstructions();
        spawnedItems[itemsFound].tag = "collectable";
    }

    private string GetInstructions()
    {
        return firstPart + items[itemsFound] + secondPart;
    }

    public void ItemFound()
    {
        itemsFound++;
        if (itemsFound < 3)
        {
            task.text = GetInstructions();
            spawnedItems[itemsFound].tag = "collectable";
        }
    }
}

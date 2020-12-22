using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator_v1 : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 1f;
    public float PLAYER_DISTANCE_UNTIL_THE_END = 5f;
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private CharacterController2D player;

    private bool gameIsOver = false;

    private Vector3 lastEndPosition;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    private float maxAxisXWidht, minAxisXWidht, maxAxisXChange, widthChange;

    private void Awake()
    {
        maxAxisXChange = .5f;
        minAxisXWidht = -1f;
        maxAxisXWidht = 2f;


        maxHeightChange = .5f;
        PLAYER_DISTANCE_UNTIL_THE_END = .2f;
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
        gameIsOver = false;
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
        int startingSpawnLevelParts = 2;

        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }
    
    private void Update()
    {
        float distanceFromEnd = Vector3.Distance(player.transform.position, lastEndPosition);

        //Debug.Log("Player: " + player.transform.position + " || End Position: " + lastEndPosition + " || Distancia: " + distanceFromEnd);
        if (!gameIsOver)
        {
            if (lastEndPosition.x >= PLAYER_DISTANCE_UNTIL_THE_END)
            {
                SpawnLastLevelPart();
                gameIsOver = true;
            }
            else
            {
                if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
                {
                    // Spawn another level part
                    SpawnLevelPart();
                }
            }
        }
    }

    private void PlatformHeight()
    {
        //Testing x variation
        widthChange = Random.Range(maxAxisXWidht, minAxisXWidht);
        if(widthChange > maxAxisXWidht)
        {
            widthChange = maxAxisXWidht;
        }
        else
        {
            if(widthChange < minAxisXWidht)
            {
                widthChange = minAxisXWidht;
            }
        }


        float randomNumber = Random.Range(maxHeightChange, -maxHeightChange);
        int roundedValue = Mathf.RoundToInt(randomNumber);
        Debug.Log("NUMERO RANDOM: " + randomNumber + " || VALOR DO rounded: " + roundedValue);
        heightChange += roundedValue;

        if (heightChange > maxHeight)
        {
            heightChange = maxHeight;
        }
        else
        {
            if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }
        }

        Debug.Log("Valor da altura: " + heightChange + "  |||| VALOR do X: " + widthChange);
    }

    private void SpawnLevelPart()
    {

        //Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count - 1)];
        //Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        //lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        PlatformHeight();
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count - 1)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, new Vector3(lastEndPosition.x + widthChange, heightChange, lastEndPosition.z));
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private void SpawnLastLevelPart()
    {
            Transform chosenLevelPart = levelPartList[levelPartList.Count-1];
            Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
            lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}

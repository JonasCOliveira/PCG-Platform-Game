using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 10f;

    [SerializeField] private Transform levelPartStart;  
    [SerializeField] private List<Transform> levelPartList;  
    [SerializeField] private CharacterController2D player;
    private Vector3 lastEndPosition;
    

    private void Awake(){
    
        lastEndPosition = levelPartStart.Find("EndPosition").position;
    
    }

    private void Update(){

        if(Vector3.Distance(player.GetPosition(),lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART){

            SpawnLevelPart();
        }

    }
    
    private void SpawnLevelPart(){

        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)]; //Algoritmo genético

       Transform lastLevelPartTransform =  SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition  = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition){

        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;

    }

}

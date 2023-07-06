using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private int _levelLenth;
    [SerializeField] private int _stageRepeatAmount;
    [SerializeField] private Transform _container;
    [Header("Block")]
    [SerializeField] private GameObject _blockTemplate;
    [SerializeField] private int _blockSpawnChance;
    [Header("Wall")]
    [SerializeField] private GameObject _wallTemplate;
    [SerializeField] private int _wallSpawnChance;
    [SerializeField] private int _wallMaxLenth;
    [Header("Bonus")]
    [SerializeField] private GameObject _bonusTemplate;
    [SerializeField] private int _bonusSpawnChance;
    [Header("FinishLine")]
    [SerializeField] private GameObject _finishLineTemplate;
    [Header("SpawnPoints")]
    [SerializeField] private Transform[] _blockSpawnPoints;
    [SerializeField] private Transform[] _wallSpawnPoints;
    [SerializeField] private Transform[] _bonusSpawnPoints;

    public void Generate(int levelLenth)
    {
        for (int i = 0; i < levelLenth; i++)
        {
            GenerateStage();
        }
        GenerateFinishLine();
    }

    private void GenerateFinishLine()
    {
        GenerateElement(transform.position, _finishLineTemplate); 
    }

    private void GenerateStage()
    {
        GenerateLine(_blockSpawnPoints, _blockTemplate.gameObject);
        for (int i = 0; i < _stageRepeatAmount; i++)
        {
            GenerateRandomLine(_bonusSpawnPoints, _bonusTemplate, _bonusSpawnChance,0);
            GenerateRandomRepeatLine(_wallSpawnPoints, _wallTemplate, _wallSpawnChance, _wallMaxLenth);
            GenerateRandomLine(_blockSpawnPoints, _blockTemplate, _blockSpawnChance);
        }
        GenerateRandomRepeatLine(_wallSpawnPoints, _wallTemplate, _wallSpawnChance, _wallMaxLenth);
    }

    private void GenerateRandomRepeatLine(Transform[] spawnPoints, GameObject generatedElement, int spawnChance, int maxRepeatAmount)
    {
        int repeatAmount = Random.Range(1, maxRepeatAmount + 1);
        Transform[] randomSpawnPoints = Array.FindAll(spawnPoints, t => CheckChance(spawnChance));
        for (int i = 0; i < repeatAmount; i++)
        {
            GenerateLine(randomSpawnPoints, generatedElement);
        }
    }

    private bool CheckChance(int chance)
    {  
        return Random.Range(0, 100) < chance;
    }

    private void GenerateLine(Transform[] spawnPoints, GameObject generatedElement)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GenerateElement(spawnPoints[i].position, generatedElement);
        }
        MoveGenerator();
    }

    private void GenerateRandomLine(Transform[] spawnPoints, GameObject generatedElement, int spawnChance, int generatorYOffset = 1)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (CheckChance(spawnChance))
            {
                GenerateElement(spawnPoints[i].position, generatedElement);
            }
        }
        MoveGenerator(generatorYOffset);
    }

    private GameObject GenerateElement(Vector3 spawnPoint, GameObject generatedElement)
    {
        return Instantiate(generatedElement, spawnPoint, Quaternion.identity, _container);
    }

    private void MoveGenerator(int yOffset = 1)
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + yOffset);
    }
}
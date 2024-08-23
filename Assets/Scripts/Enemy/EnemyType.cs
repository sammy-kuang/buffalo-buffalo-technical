using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Type", menuName = "ScriptableObjects/Enemy Type")]
public class EnemyType : ScriptableObject {
    public EnemyClass enemyClass;
    public int baseAttackPower;
    public int baseHealth;
    public int baseSpeed;
    public float baseSpawnRate; // Probability from 0-1
    public Color color; // visual purposes, can be removed
}
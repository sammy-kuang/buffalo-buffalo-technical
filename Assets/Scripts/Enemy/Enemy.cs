using UnityEngine;

public class Enemy : MonoBehaviour
{

    public EnemyType enemyType;
    public int attackPower;
    public int health;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        if (enemyType != null)
            LoadEnemyType();
        else
            Debug.LogWarning("An enemy is missing an enemy type!");
    }

    // Update is called once per frame
    // Subclasses could theoretically inherit this class if different EnemyClass demands different behaviour
    void Update()
    {

    }

    public void SetEnemyType(EnemyType n) {
        enemyType = n;
        LoadEnemyType();
    }

    void LoadEnemyType() {
        attackPower = enemyType.baseAttackPower;
        health = enemyType.baseHealth;
        speed = enemyType.baseSpeed;
        GetComponent<MeshRenderer>().material.SetColor("_Color", enemyType.color);
    }

    // Personally not a fan of having these setters, however it's the only way I can think of
    // integrating this with the Unity inspector using Unity's event (callback) system

    private void adjustByDelta(ref int value, int delta) { value += delta; }

    public void adjustAttackPower(int delta) { adjustByDelta(ref attackPower, delta); }
    public void adjustHealth(int delta) { adjustByDelta(ref health, delta); }
    public void adjustSpeed(int delta) { adjustByDelta(ref speed, delta); }

}

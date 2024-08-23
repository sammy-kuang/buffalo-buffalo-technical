using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private TimeCycle timeOfDay;

    // Start is called before the first frame update
    void Awake()
    {
        RandomizeTimeOfDay();
    }

    public static GameController GetGameController() {
        return FindObjectOfType<GameController>().GetComponent<GameController>();
    }

    public TimeCycle GetTimeOfDay() {
        return timeOfDay;
    }

    private void RandomizeTimeOfDay() {
        timeOfDay = (TimeCycle)(1 << UnityEngine.Random.Range(0, Enum.GetNames(typeof(TimeCycle)).Length));
        Debug.Log("Setting time of day to: " + timeOfDay.ToString());
    }
}

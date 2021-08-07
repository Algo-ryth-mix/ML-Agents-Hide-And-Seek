using UnityEngine;
using UnityEngine.Events;

public class Speed : MonoBehaviour
{
    public static Speed Instance;

    public float SpeedDivisor = 25;

    private void Awake()
    {
        Instance = this;
    }
}

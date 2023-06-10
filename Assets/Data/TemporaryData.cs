using UnityEngine;

public class TemporaryData : MonoBehaviour
{
    public int round;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

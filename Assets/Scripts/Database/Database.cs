using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public EnemyDatabase enemy;

    private static Database instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public static Enemy GetEnemyID(string ID)
    {
        Enemy enemy = new Enemy();

        return enemy;
    }
}

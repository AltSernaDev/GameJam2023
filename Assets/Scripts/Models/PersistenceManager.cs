using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public GenericModel savedStuff;
    [SerializeField] GameObject player;

    private void Awake()
    {
        savedStuff.Load();

        if (savedStuff.Player != null)
            player = savedStuff.Player;
        else
            savedStuff.Player = player;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            savedStuff.Save();
        }
    }
    private void OnApplicationQuit()
    {
        savedStuff.Save();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] Tower _tower;

    private void Start()
    {
        _tower.BlocksOver += onBlockOver;
    }

    private void onBlockOver()
    {
        Data.SetNextLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDisable()
    {

    }

}

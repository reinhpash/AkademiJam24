using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public GameObject player;
    public Vector3 playerPos = new Vector3(-5f, 0.03f, 0.2f);
    public CinemachineVirtualCamera virtualCamera;
    public PlayerLevelHandler levelHandler;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var a = Instantiate(player, playerPos, Quaternion.identity);

        virtualCamera.Follow = a.transform;
        levelHandler = a.GetComponent<PlayerLevelHandler>();
        levelHandler.OnLevelUp.AddListener(()=>GameObject.FindAnyObjectByType<WeaponUIManager>().ShowUI());
    }

    private void Start()
    {

    }

    public void OnNewScene()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));

    }
}

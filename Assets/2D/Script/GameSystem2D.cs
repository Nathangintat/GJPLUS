using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameSystem2D : MonoBehaviour
{
    [SerializeField] private AudioClip _screamSFX;
    [SerializeField] private AudioClip _monsterSFX;
    [SerializeField] private AudioClip _altMonsterSFX;
    public static GameSystem2D Instance;
    private AudioSource _audioSource;
    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            Destroy(this);
        }
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void MonsterSFX()
    {
        _audioSource.PlayOneShot(_monsterSFX);
    }
    public void AltMonsterSFX()
    {
        _audioSource.PlayOneShot(_altMonsterSFX);
    }
    public void ScreamSFX()
    {
        _audioSource.PlayOneShot(_screamSFX);
    }
}

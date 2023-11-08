using System;
using System.Collections;

using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private bool InPast = false;

    [SerializeField]
    [Header("Keybinds")]
    private KeyCode TeleportKey = KeyCode.F;

    [SerializeField]
    private ParticleSystem particleSys;

    [SerializeField]
    private bool _isActive = false;

    [SerializeField] private AudioSource _audioSource;

    private bool _inProgress = false;

    void Update()
    {
        Debug.Log("InPast  " + InPast);
        if(gameObject.transform.position.x < 43)
        {
            InPast = false;
        }
        else
        {
            InPast = true;
        }
        if (Input.GetKeyDown(TeleportKey) && _isActive == true && _inProgress == false)
        {
            StartCoroutine(Teleport());
        }
    }

    public void SetActiveTrue()
    {
        _isActive = true;
    }

    IEnumerator Teleport()
    {
        _inProgress = true;
        
        particleSys.Play();
        _audioSource.Play();
        yield return new WaitForSeconds(1.5f);
        particleSys.Stop();
        
        if (InPast)
        {
            gameObject.transform.position -= new Vector3(70f, 0f, 0f);
        }
        else
        {
            gameObject.transform.position += new Vector3(70f, 0f, 0f);
        }
      //  InPast = !InPast;
        _inProgress = false;
    }
}

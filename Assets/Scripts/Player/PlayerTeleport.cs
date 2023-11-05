using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private bool InPast = false;

    [SerializeField]
    [Header("Keybinds")]
    private KeyCode TeleportKey = KeyCode.F;

    [SerializeField]
    private ParticleSystem particleSys;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(TeleportKey))
        {
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        InPast = !InPast;
        particleSys.Play();
        yield return new WaitForSeconds(2.5f);
        particleSys.Stop();
        if (InPast)
        {
            gameObject.transform.position += new Vector3(80f, 0f, 0f);
        }
        else
        {
            gameObject.transform.position -= new Vector3(80f, 0f, 0f);
        }
    }
}

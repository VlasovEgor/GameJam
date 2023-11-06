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

    void Update()
    {
        if (Input.GetKeyDown(TeleportKey) && _isActive == true)
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

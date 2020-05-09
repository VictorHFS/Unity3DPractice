using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LocalPlayerIndicator : NetworkBehaviour
{
    public Vector3 location;
    public TextMesh prefab;
    private TextMesh instance;
    // Start is called before the first frame update
    public override void OnStartLocalPlayer()
    {
        this.instance = Instantiate(prefab, this.transform);
        this.instance.transform.position = this.transform.position + location;
            this.instance.color = Color.blue;
        if (!this.isLocalPlayer)
        {
            Destroy(GetComponent<AudioListener>());

        }
    }

}

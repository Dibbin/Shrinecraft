using UnityEngine;
using System.Collections;

public class Earball : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        CursorCaster.CursorCastHit hit = CursorCaster.CastCursor();
        if(hit != null) gameObject.transform.position = hit.worldPosition;
        gameObject.transform.rotation = Camera.main.gameObject.transform.rotation;
        gameObject.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
	}
}

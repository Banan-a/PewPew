using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public void DestroyMe() {
        Destroy(gameObject);
    }

    public void DestroyParent() {
        Destroy(transform.parent.gameObject);
    }

}

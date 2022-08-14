using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Effect_Controller : MonoBehaviour
{
    public void Hit()
    {
        gameObject.GetComponent<UI_Face_Camera>().UI_Move_Front();
        gameObject.transform.Find("Damage").GetComponent<Animator>().SetTrigger("Hit");
        Invoke("Set_Active_False", 1.4f);
    }

    private void Set_Active_False()
    {
        gameObject.SetActive(false);
    }
}

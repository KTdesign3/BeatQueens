using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlashScript : MonoBehaviour
{

    MeshRenderer SkinnedMeshRenderer;
    Color origColor;
    float flashTime = .15f;

    public GameObject NaviScoreIconGO;
    // Start is called before the first frame update
    void Start()
    {
        SkinnedMeshRenderer = GetComponent<MeshRenderer>();
        origColor = SkinnedMeshRenderer.material.color;
    }

    public void AttackFlash()
    {
        StartCoroutine(EFlash());
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            //StartCoroutine(EFlash());
        }
    }

    

   public void FlashStart()
    {
        SkinnedMeshRenderer.material.color = Color.white;
        Invoke("FlashStop", flashTime);
        Debug.Log("FlashStart called");
        NaviScoreIconGO.SetActive(true);

    }

    void FlashStop()
    {
        SkinnedMeshRenderer.material.color = Color.white;
        origColor = SkinnedMeshRenderer.material.color;
        NaviScoreIconGO.SetActive(true);
        Debug.Log("Navi score icon called");
    }

    public IEnumerator EFlash()
    {
        SkinnedMeshRenderer.material.color = Color.white;
        yield return new WaitForSeconds(flashTime);
        SkinnedMeshRenderer.material.color = origColor;
    }
}

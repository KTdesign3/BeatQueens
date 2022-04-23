using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaviFlashScript : MonoBehaviour
{
    
    MeshRenderer SkinnedMeshRenderer;
    Color origColor;
    float flashTime = .15f;
    public Material NaviMatOrg;
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
        if (Input.GetKeyDown(KeyCode.N))
        {
            //FlashStart();
            StartCoroutine(EFlash());
        }
    }



    public void FlashStart()
    {
        SkinnedMeshRenderer.material.color = Color.black;
        Invoke("FlashStop", flashTime);
        Debug.Log("FlashStart called");

    }

    void FlashStop()
    {
        SkinnedMeshRenderer.material.color = Color.black;
        origColor = SkinnedMeshRenderer.material.color;
    }

    public IEnumerator EFlash()
    {
        SkinnedMeshRenderer.material.color = Color.black;
        NaviScoreIconGO.SetActive(true);
        yield return new WaitForSeconds(flashTime);
        SkinnedMeshRenderer.material.color = origColor;
        NaviScoreIconGO.SetActive(false);
    }
}

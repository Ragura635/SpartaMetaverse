using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractionTrigger : MonoBehaviour
{
    public Transform player;
    public Transform npc;
    public RectTransform interactIconUI;
    public GameObject menuUI;
    public float showDistance = 3.5f;
    public float xOffset = 70f;
    
    private bool isPlayerNear = false;

    void Update()
    {
        float distance = Vector2.Distance(player.position, npc.position);
        isPlayerNear = distance < showDistance;
        interactIconUI.gameObject.SetActive(isPlayerNear);

        if (isPlayerNear)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(npc.position);
            float offsetX = player.position.x < npc.position.x ? -xOffset : xOffset;
            interactIconUI.position = screenPos + new Vector3(offsetX, 0f, 0f);
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                menuUI.SetActive(true);
            }
        }
        else
        {
            if(menuUI.activeSelf) CloseMenu();
        }
    }
    
    public void CloseMenu()
    {
        menuUI.SetActive(false);
    }
}

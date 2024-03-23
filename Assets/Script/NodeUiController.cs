using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NodeUiController : MonoBehaviour
{
    public GameObject nodeCanvas;
    public TMP_Text priceText;

    public Node currentNode;

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, float.MaxValue))
            {
                Node node = hitInfo.collider.gameObject.GetComponent<Node>();
                if (node == null)
                {
                    HideNodeUi();
                }
            }
            else
            {
                HideNodeUi();
            }
        }
    }

    public void ShowNodeUi(Node node)
    {
        currentNode = node;
        transform.position = node.transform.position;
        priceText.text = node.currentTurret.GetComponent<BaseTurret>().sellPrice + "$";
        nodeCanvas.SetActive(true);
    }
    public void OnSellBtnClick()
    {
        if(currentNode == null)
        {
            HideNodeUi();
            return;
        }

        MainGameController.instance.gold += currentNode.currentTurret.GetComponent<BaseTurret>().sellPrice;
        Destroy(currentNode.currentTurret);
        currentNode.currentTurret = null;
        HideNodeUi();
    }
    public void HideNodeUi()
    {
        nodeCanvas.SetActive(false);
    }
}

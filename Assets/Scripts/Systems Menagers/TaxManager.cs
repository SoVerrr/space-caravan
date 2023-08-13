using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxManager : MonoBehaviour
{
    [SerializeField] private SpaceGrid spaceGrid;
    [SerializeField] private PointManager pointManager;    

    [SerializeField] int basicTax;
    [SerializeField] int basicTaxIncrease;
    [SerializeField] int roadTax;
    [SerializeField] int hubPointTax;
    [SerializeField] int materialPointTax;
    [SerializeField] int sellPointTax;
    [SerializeField] int processingPointTax;

    public void BasicTaxIncrease()
    {
        basicTax += basicTaxIncrease;
    }



    public int Tax()
    {
        GameManager.Instance.score-=basicTax;
        GameManager.Instance.score-=roadTax*spaceGrid.roadCounter;
        GameManager.Instance.score-=materialPointTax*pointManager.materialPointCounter;
        GameManager.Instance.score-=hubPointTax*pointManager.hubPointCounter;
        GameManager.Instance.score-=processingPointTax*pointManager.processingPointCounter;
        GameManager.Instance.score-=sellPointTax*pointManager.sellPointCounter;

        return GameManager.Instance.score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] Text score;
    [SerializeField] private SpaceGrid spaceGrid;
    public bool isUIOpen = false;

    [SerializeField] int basicTax;
    [SerializeField] int roadTax;
    [SerializeField] int hubPointTax;
    [SerializeField] int materialPointTax;
    [SerializeField] int sellPointTax;
    [SerializeField] int processingPointTax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = $"Score: {GameManager.Instance.score}$";
    }

    public int Tax()
    {
        GameManager.Instance.score-=basicTax;
        GameManager.Instance.score-=roadTax*spaceGrid.roadCounter;
        GameManager.Instance.score-=materialPointTax*GameManager.Instance.materialPointCounter;
        GameManager.Instance.score-=hubPointTax*GameManager.Instance.hubPointCounter;
        GameManager.Instance.score-=processingPointTax*GameManager.Instance.processingPointCounter;
        GameManager.Instance.score-=sellPointTax*GameManager.Instance.sellPointCounter;

        return GameManager.Instance.score;
    }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
}

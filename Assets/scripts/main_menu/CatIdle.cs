using UnityEngine;

public class CatIdle : MonoBehaviour
{
    [SerializeField] private GameObject snowy;
    [SerializeField] private GameObject goob;

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>(); 
    }

    private void Update()
    {
        MenuAnim();

    }
    public void MenuAnim()
    {
        string selectedChar = PlayerPrefs.GetString(charManager.SelectedCharKey,"snowy"
        );

        Debug.Log("Selected character: " + selectedChar);

        if (selectedChar == "snowy")
        {
            animator.SetBool("isSnowy", true);
        }
        else if (selectedChar == "clem")
        {
            animator.SetBool("isSnowy", false);
           //snowy.SetActive(false);
           // goob.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Unknown character: " + selectedChar);
        }
    }
}
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject painel; 

    public void AbrirPainel()
    {
        painel.SetActive(true); 
    }

    public void FecharPainel()
    {
        painel.SetActive(false); 
    }

    
    public void AlternarPainel()
    {
        painel.SetActive(!painel.activeSelf);
    }
}
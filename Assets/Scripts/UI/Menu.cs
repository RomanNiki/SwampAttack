using UnityEngine;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        public void OpenPanel(GameObject panel)
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
        
        public void ClosePanel(GameObject panel)
        {
            panel.SetActive(false);
            Time.timeScale = 1f;
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
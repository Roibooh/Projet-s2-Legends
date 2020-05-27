using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/* Author : Julien Lung Yut Fong
 *
 * Script du menu
 */
public class Menu : MonoBehaviour
{
    public void JouerMap(int i)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + i);
    }
    

    public void Quit()
    {
        Application.Quit();
    }
}

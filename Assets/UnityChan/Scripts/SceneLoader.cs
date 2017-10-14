using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	void OnGUI()
	{
		GUI.Box(new Rect(10 , Screen.height - 100 ,100 ,90), "Change Scene");
		if(GUI.Button( new Rect(20 , Screen.height - 70 ,80, 20), "Next"))
			LoadNextScene();
		if(GUI.Button(new Rect(20 ,  Screen.height - 40 ,80, 20), "Back"))
			LoadPreScene();
	}

	void LoadPreScene()
	{
        //int nextLevel = Application.loadedLevel + 1;    // obsolete
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel <= 1)
        {
            //nextLevel = Application.levelCount;  // obsolete
            nextLevel = SceneManager.sceneCountInBuildSettings;
        }

        //Application.LoadLevel(nextLevel); // obsolete
        SceneManager.LoadScene(nextLevel);
    }

	void LoadNextScene()
	{
		//int nextLevel = Application.loadedLevel + 1;  // obsolete
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        //if (nextLevel >= Application.levelCount)  // obsolete
        if (nextLevel >= SceneManager.sceneCountInBuildSettings)
        {
            nextLevel = 1;
        }

        //Application.LoadLevel(nextLevel); // obsolete
        SceneManager.LoadScene(nextLevel);
    }
}

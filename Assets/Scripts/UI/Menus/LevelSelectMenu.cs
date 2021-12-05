using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

// NOTE: This class need constant maintenance and
// addition/removal of level-loading methods as new
// ones are added and old ones are removed.
public class LevelSelectMenu : SecondaryMenu
{
    private Levels levelToLoad;
   
    public void LoadTutorialColors()
    {
        PlayTransitionAnimation();
        levelToLoad = Levels.TutorialColors;
    }

    public void LoadAlpha()
    {
        PlayTransitionAnimation();
        levelToLoad = Levels.AlphaScenev2;
    }
    
    public void LoadTut1()
    {
        PlayTransitionAnimation();
        levelToLoad = Levels.Tutorial1;
    }

    public void LoadTut15()
    {
        PlayTransitionAnimation();
        levelToLoad = Levels.Tutorial15;
    }
    
    public void LoadTut2()
    {
        PlayTransitionAnimation();
        levelToLoad = Levels.Tutorial2;
    }

    public void LoadLevel1()
    {
        PlayTransitionAnimation();
        levelToLoad = Levels.Level1;
    }

    public void LoadLevel2()
    {
        PlayTransitionAnimation();
        levelToLoad = Levels.Level2;
    }

    private void PlayTransitionAnimation()
    {
        base.transitionAnimation.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneLoader.LoadLevel(levelToLoad);
    }
}

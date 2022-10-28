using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageView : MonoBehaviour
{
    [SerializeField] private StageViewLevelButton stageViewLevelButtonPrototype;
    [SerializeField] private RectTransform contentContainer;

    private Stage stage;

    public void Set(Stage stage)
    {
        // TODO remove/recycle old buttons
        this.stage = stage;
        for (int i = 0; i < stage.levels.Count; i++)
        {
            int j = i;
            Instantiate(stageViewLevelButtonPrototype, stageViewLevelButtonPrototype.transform.parent).Set(i + 1, 0, false, () => { ButtonCallback(j); });
        }
        stageViewLevelButtonPrototype.gameObject.SetActive(false);
    }

    void Update() {

    }

    private void ButtonCallback(int index)
    {
        SceneManager.LoadScene(stage.levels[index].sceneReference);
    }
}
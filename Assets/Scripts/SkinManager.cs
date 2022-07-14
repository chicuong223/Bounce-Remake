using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour
{
    public SkinDatabase skinDatabase;

    public SpriteRenderer artworkSprite;

    private int selectedIndex;

    // Start is called before the first frame update
    private void Start()
    {
        if (!PlayerPrefs.HasKey("selectedSkin"))
        {
            selectedIndex = 0;
        }
        else
        {
            Load();
        }
        UpdateSkin(selectedIndex);
    }

    public void NextOption()
    {
        selectedIndex++;
        if (selectedIndex >= skinDatabase.SkinCount)
        {
            selectedIndex = 0;
        }
        UpdateSkin(selectedIndex);
        Save();
    }

    public void BackOption()
    {
        selectedIndex--;
        if (selectedIndex < 0)
        {
            selectedIndex = skinDatabase.SkinCount - 1;
        }
        UpdateSkin(selectedIndex);
        Save();
    }

    private void UpdateSkin(int selectedOption)
    {
        Skin skin = skinDatabase.GetSkin(selectedOption);
        artworkSprite.sprite = skin.skinSprite;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("selectedSkin", selectedIndex);
    }

    private void Load()
    {
        selectedIndex = PlayerPrefs.GetInt("selectedSkin");
    }

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
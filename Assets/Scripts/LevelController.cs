using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private string nextLevelName;
   
    private Monster[] _monsters;

    private void OnEnable()
    {
        _monsters = FindObjectsOfType<Monster>();
    }

    private void Update()
    {
        if (MonstersAreAllDead())
            GoToNextLevel();
    }
    
    private bool MonstersAreAllDead()
    {
        foreach (var monster in _monsters)
        {
            if (monster.gameObject.activeSelf)
                return false;
        }

        return true;
    }
    
    private void GoToNextLevel()
    {
        Debug.Log("Go to Level " + nextLevelName);
    }
}

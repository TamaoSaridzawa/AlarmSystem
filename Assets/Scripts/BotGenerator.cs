using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotGenerator : MonoBehaviour
{
    [SerializeField] private BotEnemy _bot;
    [SerializeField] private Transform _path;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        StartCoroutine(CreateBots());
    }

    private IEnumerator CreateBots()
    {
        bool isJob = true;

        while (isJob)
        {
            for (int i = 0; i < _points.Length; i++)
            {
                GameObject newBot = Instantiate(_bot.gameObject, _points[i].transform.position, Quaternion.identity);
               
                yield return new WaitForSeconds(2f);
            }
        }
    }
}

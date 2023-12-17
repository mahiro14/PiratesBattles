// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ObjectPool
// {
//     GameState _gameState;
//     GameEvent _gameEvent;
//     private Dictionary<int, List<GameObject>> pool = new Dictionary<int, List<GameObject>>();

//     public ObjectPool(GameState gameState, GameEvent gameEvent)
//     {
//         _gameState = gameState;
//         _gameEvent = gameEvent;
//         _gameEvent.onRemoveHoge += OnRemoveHoge;
//     }

//     private void OnRemoveHoge(HogeComponent hogeComp)
//     {
//         hogeComp.gameObject.SetActive(false);
//         _gameState.hoges.Remove(hogeComp);
//     }

//     public GameObject OnShowText(GameObject hogePrefab, GameObject target)
//     {
//         int hash = hogePrefab.GetHashCode();
//         if (pool.ContainsKey(hash))
//         {
//             List<GameObject> targetPool = pool[hash];
//             int count = targetPool.Count;
//             for(int j=0 ; j<count ; j++)
//             {
//                 if (targetPool[j].activeSelf == false)
//                 {
//                     targetPool[j].SetActive(true);
//                     targetPool[j].transform.position = target.transform.position;
//                     return targetPool[j];
//                 }
//             }
//             GameObject hoge = GameObject.Instantiate(targetPool[0], target.transform.position, Quaternion.identity, _gameState.parentHoge);
//             targetPool.Add(hoge);
//             hoge.SetActive(true);
//             return hoge;
//         }

//         GameObject hoge2 = GameObject.Instantiate(textPrefab, target.transform.position, Quaternion.identity, _gameState.parentHoge);
//         List<GameObject> poolList = new List<GameObject>();
//         poolList.Add(hoge2);
//         pool.Add(hash, poolList);
//         hoge2.SetActive(true);
//         return hoge2;
//     }
// }
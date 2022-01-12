using UnityEngine;
using UnityEngine.UI;

public class Btn_KillEnemy : MonoBehaviour
{
    public void OnButtonPressed() 
    {
        var enemys = Enemys_Manager.instance.GetInGameEnemys();
        var enemy = enemys[0];
        Enemys_Manager.instance.Remove(enemy);
        Destroy(enemy);
    } 
}

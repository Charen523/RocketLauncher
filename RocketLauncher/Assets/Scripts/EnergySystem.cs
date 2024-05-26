using System;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    public event Action<float> OnEnergyChanged;
    public event Action NoFuel;

    public float MaxFuel { get; private set; } = 10f;
    public float Fuel { get; private set; } = 10f;
    
    public bool UseEnergy(float amount)
    {
        if (Fuel < amount)
        {
            Fuel = 0; //만약 연료가 2 이하인데 부스트 쓰면 0으로 만들어버리기.
            OnEnergyChanged?.Invoke(Fuel / MaxFuel); 
            NoFuel?.Invoke(); //연료없다 이벤트: 로켓 움직임 막기용.
            return false; //남은 연료 < 사용량
        }

        Fuel -= amount;
        OnEnergyChanged?.Invoke(Fuel / MaxFuel);
        return true;
    }
}
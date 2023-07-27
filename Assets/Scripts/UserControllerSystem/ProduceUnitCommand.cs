using UnityEngine;
public class ProduceUnitCommand : IProduceUnitCommand
{
    public GameObject UnitPrefab => _unitPrefab;
    [InjectAsset("ChomperVariant")] private GameObject _unitPrefab;

    public ProduceUnitCommand(GameObject unitPrefab)
    {
        _unitPrefab = unitPrefab;
    }

    public ProduceUnitCommand()
    {
        
    }

}
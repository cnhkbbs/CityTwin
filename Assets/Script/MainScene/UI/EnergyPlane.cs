
using DataManagerModule;
using TMPro;
public class EnergyPlane : DataPlaneBase
{
    public TextMeshProUGUI enteUse;
    public TextMeshProUGUI resiUse;
    public TextMeshProUGUI produce;
    public TextMeshProUGUI use;

    public override void FlashDataText()
    {
        EnergyData data = DataManager.Instance.GetDataByName<EnergyData>("EnergyData");
        enteUse.text = data.enterprise.ToString();
        resiUse.text = data.resident.ToString();
        produce.text = data.produce.ToString();
        use.text = data.used.ToString();
    }
}

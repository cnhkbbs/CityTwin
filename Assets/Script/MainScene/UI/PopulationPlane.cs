
using DataManagerModule;
using TMPro;

public class PopulationPlane : DataPlaneBase
{
    public TextMeshProUGUI popuSize;
    public TextMeshProUGUI floatPopu;
    public TextMeshProUGUI migrantPopu;
    public TextMeshProUGUI highTechPopu;
    public TextMeshProUGUI childPopu;

    public override void FlashDataText()
    {
        PopulationData data = DataManager.Instance.GetDataByName<PopulationData>("PopulationData");
        popuSize.text = data.populationSize.ToString();
        floatPopu.text = data.floatingPopulation.ToString();
        migrantPopu.text = data.migrantWorkers.ToString();
        highTechPopu.text = data.highlyEduPopulation.ToString();
        childPopu.text = data.child.ToString();
    }
}

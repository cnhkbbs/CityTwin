using DataManagerModule;
using TMPro;

public class EnvironmentPlane : DataPlaneBase
{
    public TextMeshProUGUI grade;
    public TextMeshProUGUI avg;
    public TextMeshProUGUI park;
    public TextMeshProUGUI gov;
    public TextMeshProUGUI school;

    public override void FlashDataText()
    {
        EnviromentData data = DataManager.Instance.GetDataByName<EnviromentData>("EnviromentData");
        float avgScore = (data.parkScore + data.govScore + data.schoolScore);
        grade.text = GetGrade(avgScore);
        avg.text = avgScore.ToString();
        park.text = data.parkScore.ToString();
        gov.text = data.govScore.ToString();
        school.text = data.schoolScore.ToString();
    }


    private string GetGrade(float avgScore)
    {
        if(avgScore> 95)
        {
            return "ÓÅ";
        }else if (avgScore > 90)
        {
            return "Á¼";
        }
        else if (avgScore > 80)
        {
            return "Ò»°ã";
        }
        else
        {
            return "²î";
        }
    }
}

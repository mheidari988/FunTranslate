using FunTranslate.Domain.Entities;
using System.Text;

namespace FunTranslate.Application.UnitTests;
public static class MockData
{
    public static List<FunTranslation> GetFunTranslatesMockData()
    {
        var minion1Guid = Guid.Parse("{C0F1B8FA-C4D3-4140-B55C-552ED1B95F2D}");
        var minion2Guid = Guid.Parse("{9ACD1374-955A-4E31-A83F-2E28F904C0DD}");
        var yoda1Guid = Guid.Parse("{68A3EC86-40C4-4515-8F74-994E1FCE5855}");
        var yoda2Guid = Guid.Parse("{56CB7849-EAF8-42E4-A5DE-ADFF3DD08A29}");

        return new List<FunTranslation>
        {
            new FunTranslation{ Id = minion1Guid, Text = "hello", Translated = "bello", Translation = "minion" },
            new FunTranslation{ Id = minion2Guid, Text = "food", Translated = "banana", Translation = "minion" },
            new FunTranslation{ Id = yoda1Guid, Text = "hello", Translated = "force be with you", Translation = "yoda" },
            new FunTranslation{ Id = yoda2Guid, Text = "lets do it", Translated = "do it, lets", Translation = "yoda" },
        };
    }

    public static string LoremIpsum(int characterCount)
    {
        var strBuilder = new StringBuilder();

        for (int i = 0; i < characterCount; i++)
        {
            strBuilder.Append('X');
        }

        return strBuilder.ToString();
    }
}

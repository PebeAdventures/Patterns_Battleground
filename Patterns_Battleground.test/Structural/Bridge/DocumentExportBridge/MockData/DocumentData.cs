using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Battleground.test.Structural.Bridge.DocumentExportBridge.MockData
{
    public class DocumentData
    {
        // Raw invoice content 
        public const string InvoiceContent = """
        Invoice:
        - Item A: $10
        - Item B: $20
        Total: $30
        """;

        // Raw resume content 
        public const string ResumeContent = """
        Resume:
        Name: Jane Doe
        Skills: C#, .NET, Azure
        Experience: 5 years
        """;
    }
}

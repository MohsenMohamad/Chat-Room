using System;
using System.Collections.Generic;
using System.Text;

namespace Communication_Layer.CommunicationLayer
{
    [Serializable]
    public class IMessage
    {
        Guid Id { get; }
        string UserName { get; }
        DateTime Date { get; }
        string MessageContent { get; }
        string GroupID { get; }
        //public string ToString();
    }
}

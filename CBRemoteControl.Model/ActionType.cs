
namespace CBRemoteControl.Model
{
    /// <summary>
    /// 动作指令
    /// </summary>
    public enum ActionType : int
    {
        SayHello = 0000000010,
        RemoteSayHeelo = 0000000011,
        MonitorSayHeelo = 0000000011,
        ServerSayHello = 0000000013,

        SayBye = 0000010000,
        RemoteSayBye = 0000010001,
        MonitorSayBye = 0000010002,
        ServerSayBye = 0000010003,

        Reject = 1000000000,

        GetRemote = 0000000100,
        GetRemoteList = 0000000101,
        GetRemoteInfo = 0000000102,

        TransPic = 0000001000,
    }
}

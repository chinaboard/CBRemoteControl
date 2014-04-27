
namespace CBRemoteControl.Model
{
    /// <summary>
    /// 动作指令
    /// </summary>
    public enum ActionType : byte
    {
        SayHello = 0x10,
        RemoteSayHeelo = 0x11,
        MonitorSayHeelo = 0x12,
        ServerSayHell0 = 0x13,

        Accept = 0xAA,
        Reject = 0xFF,

        GetRemote = 0x20,
        GetRemoteList = 0x21,
        GetRemoteInfo = 0x22,
    }
}

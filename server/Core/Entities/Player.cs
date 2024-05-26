using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Async.Elements.Entities;
using Server.Core.Inferfaces;

namespace Server.Core.Entities
{
    public class Player : AsyncPlayer, IPlayer {

        public uint Db_Id { get; set; }
        public string DisplayName { get; set; }
        public bool IsLoggedIn { get { return Db_Id != 0; } }

    public Player(ICore core, IntPtr nativePointer, uint id) : base(core, nativePointer, id) {
        }

        public new IPlayer ToAsync(IAsyncContext asyncContext) => this;
    }
}

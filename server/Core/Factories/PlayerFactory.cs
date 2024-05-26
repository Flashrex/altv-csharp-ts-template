using AltV.Net;
using Server.Core.Entities;

namespace Server.Core.Factories
{
    public class PlayerFactory : IEntityFactory<AltV.Net.Elements.Entities.IPlayer> {
        public AltV.Net.Elements.Entities.IPlayer Create(ICore core, IntPtr entityPointer, uint id) {
            return new Player(core, entityPointer, id);
        }
    }
}

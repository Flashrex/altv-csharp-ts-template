using AltV.Net;
using Server.Core.Entities;

namespace Server.Core.Factories
{
    public class VehicleFactory : IEntityFactory<AltV.Net.Elements.Entities.IVehicle> {
        public AltV.Net.Elements.Entities.IVehicle Create(ICore core, IntPtr entityPointer, uint id) {
            return new Vehicle(core, entityPointer, id);
        }
    }
}

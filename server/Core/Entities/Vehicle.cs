using AltV.Net.Async.Elements.Entities;
using AltV.Net.Async;
using AltV.Net;
using Server.Core.Inferfaces;

namespace Server.Core.Entities
{
    public class Vehicle : AsyncVehicle, IVehicle {
        public Vehicle(ICore core, IntPtr nativePointer, uint id) : base(core, nativePointer, id) {
        }

        public new IVehicle ToAsync(IAsyncContext asyncContext) => this;
    }
}

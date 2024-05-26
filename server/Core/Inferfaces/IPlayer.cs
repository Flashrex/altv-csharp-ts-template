using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Inferfaces {
    public interface IPlayer {

        public uint Db_Id { get; set; }
        public string DisplayName { get; set; }
        public bool IsLoggedIn { get; }
    }
}

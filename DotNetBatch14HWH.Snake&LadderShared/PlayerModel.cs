using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.SnakeLadderShared
{
    [Table("Players")]
    public class PlayerModel
    {
        [Key]
        public int? PlayerID { get; set; }
        public string? PlayerName { get; set; }
        public int? CurrentPosition { get; set; }
        public int Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.SnakeLadderShared
{
    [Table("Games")]
    public class GameModel
    {
        [Key]
        public int? GameID { get; set; }
        public string? GameStatus { get; set; }
        public int CurrentPlayerID { get; set; }

    }
}

using DotNetBatch14HWH.SnakeAndLadderGame.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.SnakeAndLadderGame.Database;

public class AppDbCotext : DbContext
{
    public readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;
    public AppDbCotext()
    {
        _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "LAPTOP-JLC9N4P3\\SQL2022E",
            UserID = "sa",
            Password = "p@ssw0rd",
            InitialCatalog = "DotNetBatch14_UpdateSnakeLadder",
            TrustServerCertificate = true
        };
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_sqlConnectionStringBuilder.ConnectionString);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    public DbSet<PlayerModel> Players { get; set; }
    public DbSet<GameBoardModel> GameBoards { get; set; }
    public DbSet<GameModel> Games { get; set; }
    public DbSet<GameMoveModel> GameMoves { get; set; }
}

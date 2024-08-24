using Microsoft.EntityFrameworkCore;

namespace aulaEntityFramework.Models
{
    /* 
        A classe de contexto de banco de dados ou DbContext 
        é respnsável por mapear as classes que serão atreladas às tabelas do db.
    */
    public class MyDbContext : DbContext
    {
        public MyDbContext(
            DbContextOptions options
            ) : base(options)
        {
        }

        /*
            Nesta sessão especificamos as classes do Model que serão
            espelhadas em tabelas do DB
         */

        public DbSet<Person> Persons { get; set; }
    }
}

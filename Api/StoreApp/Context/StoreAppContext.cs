using Microsoft.EntityFrameworkCore;
using StoreApp.Entities;

namespace StoreApp.Context
{
    public class StoreAppContext :DbContext
    {
        public StoreAppContext(){ }

        public virtual DbSet<Produto> Produtos { get; set; }
    }
}
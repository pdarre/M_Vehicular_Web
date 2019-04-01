namespace M_Vehicular_Web.Data
{
    using Models;

    public class TallerRepository : GenericRepository<Taller>, ITallerRepository
    {
        public TallerRepository(DataContext context) : base(context)
        {
        }
    }
}

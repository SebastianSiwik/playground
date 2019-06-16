using BicycleService.Data.Sql.DAO;
using System.Collections.Generic;

namespace BicycleService.Api.ViewModels
{
    public class BicycleListViewModel
    {
        public List<BicycleViewModel> Bicycles { get; set; }
    }
}

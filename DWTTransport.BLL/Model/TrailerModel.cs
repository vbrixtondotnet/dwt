using DWTTransport.BLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWTTransport.BLL.Model
{
    public class TrailerModel
    {
        public TrailerModel() { }
        public TrailerModel(tblTrailer trailer)
        {
            this.Id = trailer.Id;
            this.Name = trailer.Name;
            this.TrailerName = trailer.TrailerName;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string TrailerName { get; set; }
    }
}

using DWTTransport.BLL.Common;
using DWTTransport.BLL.DAL;
using DWTTransport.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWTTransport.BLL.Services.Interfaces
{
    public interface IJourneyService
    {
        JourneyModel GetJourney(int id);
        List<JourneyModel> GetJourneys();

        bool SaveJourney(JourneyModel journey);
    }
}

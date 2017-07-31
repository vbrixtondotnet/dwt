using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWTTransport.BLL.Common;
using DWTTransport.BLL.DAL;
using DWTTransport.BLL.Model;
using DWTTransport.BLL.Services.Interfaces;

namespace DWTTransport.BLL.Services
{
    public class JourneyService : IJourneyService
    {
        private DWTEntities db;
        
        public JourneyService()
        {
            db = new DWTEntities();
        }

        public JourneyModel GetJourney(int id)
        {
            var journey = db.tblJourneys.FirstOrDefault(j => j.ID == id);
            return new JourneyModel(journey);
        }

        public List<JourneyModel> GetJourneys()
        {
            List<JourneyModel> retval = new List<JourneyModel>();
            var journeys = db.tblJourneys.ToList();
            journeys.ForEach(j => retval.Add(new JourneyModel(j)));
            return retval;
            //return db.tblJourneys.ToList();
        }

        public bool SaveJourney(JourneyModel journey)
        {
            if (journey != null)
            {
                tblJourney dbJourney = journey.ID == 0 ? new tblJourney() : db.tblJourneys.FirstOrDefault(j => j.ID == journey.ID);

                dbJourney.Journey = journey.Journey;
                dbJourney.CustomerId = journey.CustomerId;
                dbJourney.Base = journey.Base;
                
                if(dbJourney.ID == 0)
                {
                    db.tblJourneys.Add(dbJourney);
                }

                db.SaveChanges();
            }
            return false;
        }
    }
}

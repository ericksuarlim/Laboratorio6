using Athletics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Athletics.Service
{
    public interface IAthleteService
    {

        AthleteModel GetAthlete(int id);
        IEnumerable<AthleteModel> GetAthletes();
        AthleteModel CreateAthlete(AthleteModel newAthlete);
        bool DeleteAthlete(int id);
        bool UpdateAthlete(int id, AthleteModel athlete);

    }
}

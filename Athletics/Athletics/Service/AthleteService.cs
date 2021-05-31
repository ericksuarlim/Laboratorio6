using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Athletics.Exceptions;
using Athletics.Model;


namespace Athletics.Service
{
    public class AthleteService : IAthleteService
    {
        private List<AthleteModel> athletes = new List<AthleteModel>();


        public AthleteService()
        {
            athletes.Add(new AthleteModel()
            {
                Id = 1,
                Name = "Usain Bolt",
                Discipline = "100m Race",
                Genere = "Male",
                Age = 37,
                Country ="Jamaica",
                AthleteImage = @"C:\Users\USUARIO\Desktop\TecWeb\Proyecto JS\FrontEnd\img\bolt.jpg"

            }
            );

            athletes.Add(new AthleteModel()
            {
                Id = 2,
                Name = "Aries Merrit",
                Discipline = "110 Hurdles",
                Genere = "Male",
                Age = 30,
                Country = "USA",
                AthleteImage = @"C:\Users\USUARIO\Desktop\TecWeb\Proyecto JS\FrontEnd\img\merrit.jpg"

            }
            );

            athletes.Add(new AthleteModel()
            {
                Id = 3,
                Name = "Juan M. Echevarria",
                Discipline = "Long Jump",
                Genere = "Male",
                Age = 23,
                Country = "Cuba",
                AthleteImage = @"C:\Users\USUARIO\Desktop\TecWeb\Proyecto JS\FrontEnd\img\juanmi.jpg"


            }
            );

            athletes.Add(new AthleteModel()
            {
                Id = 4,
                Name = "GianMarco Tamberi",
                Discipline = "Hight Jump",
                Genere = "Male",
                Age = 29,
                Country = "Italy",
                AthleteImage = @"C:\Users\USUARIO\Desktop\TecWeb\Proyecto JS\FrontEnd\img\gianmarco.jpg"

            }
            );

            athletes.Add(new AthleteModel()
            {
                Id = 5,
                Name = "Daria Klishina",
                Discipline = "Long Jump",
                Genere = "Female",
                Age = 26,
                Country = "Rusia",
                AthleteImage = @"C:\Users\USUARIO\Desktop\TecWeb\Proyecto JS\FrontEnd\img\klishina.jpg"

            }
           );

            athletes.Add(new AthleteModel()
            {
                Id = 6,
                Name = "Alysha Newman",
                Discipline = "Polut Vault",
                Genere = "Male",
                Age = 30,
                Country = "Canada",
                AthleteImage = @"C:\Users\USUARIO\Desktop\TecWeb\Proyecto JS\FrontEnd\img\alysha.jpg"

            }
            );

        }

        public AthleteModel CreateAthlete(AthleteModel newAthlete)
        {
            var newId = athletes.OrderByDescending(r => r.Id).First().Id + 1;
            newAthlete.Id = newId;
            athletes.Add(newAthlete);
            return newAthlete;
        }

        public bool DeleteAthlete(int id)
        {
            var athletedelete = athletes.FirstOrDefault(r => r.Id == id);
            if(athletedelete==null)
            {
                 throw new NotFoundException($"The Ahlete {id} no exist");
            }
            {
                athletes.Remove(athletedelete);
                return true;
            }
        }

        public AthleteModel GetAthlete(int id)
        {
            var athlete = athletes.FirstOrDefault(r => r.Id == id);
            if(athlete==null)
            {
                throw new NotFoundException($"No se encontro el atleta buscado");
            }
            else
            {
                return athlete;
            }
        }

        public IEnumerable<AthleteModel> GetAthletes()
        {
            return athletes;
        }

        public bool UpdateAthlete(int id, AthleteModel athlete)
        {
            var athletechange = GetAthlete(id);
            athletechange.Name = athlete.Name ?? athletechange.Name;
            athletechange.Discipline = athlete.Discipline ?? athletechange.Discipline;
            athletechange.Genere = athlete.Genere ?? athletechange.Genere;
            athletechange.Age =  athletechange.Age;
            athletechange.Country = athlete.Country ?? athletechange.Country;

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Mime;

namespace Athletics.Model
{
    public class AthleteModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discipline { get; set; }
        public string Genere { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string AthleteImage { get; set; }


    }
}

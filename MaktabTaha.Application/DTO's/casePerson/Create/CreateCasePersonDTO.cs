using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.DTO_s.casePerson.Create
{
    public class CreateCasePersonDTO
    {
        public int PersonId { get; set; }
        public int RelationId { get; set; }
        public int IsDependent { get; set; }    
    }
}

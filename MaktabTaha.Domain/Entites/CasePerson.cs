using MaktabTaha.Domain.Common;
using MaktabTaha.Domain.Entites.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaktabTaha.Domain.Entites
{
    public class CasePerson : BaseEntity<int>
    {
        public int CaseId { get; set; }
        [JsonIgnore]
        public Case Case { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int RelationId { get; set; }
        public Relation Relation { get; set; }
        
        //بچه از یک سنی به بعد از تحت تکفل بودن، درمی‌آید ولی هنوز اعضای پرونده هست
        public int IsDependent { get; set; }
    }
}

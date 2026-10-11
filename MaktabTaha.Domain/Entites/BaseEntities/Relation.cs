using MaktabTaha.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Domain.Entites.BaseEntities
{
    public class Relation : BaseEntity<int>
    {
        public string RelationName { get; set; }
        public List<CasePerson> CasePersons { get; set; } = new List<CasePerson>();
    }
}

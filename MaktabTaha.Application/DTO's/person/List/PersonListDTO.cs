using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.DTO_s.person.List
{
    public class PersonListDTO
    {
        public int Id { get; set; }
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string FatherName { get; set; }
        public int GenderId { get; set; }
        public string GenderTitle { get; set; }
        public DateTime RecordDate { get; set; }
    }
}

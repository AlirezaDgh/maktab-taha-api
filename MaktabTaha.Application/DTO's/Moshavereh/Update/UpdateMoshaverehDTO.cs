    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace MaktabTaha.Application.DTO_s.Moshavereh.Update
    {
        public class UpdateMoshaverehDTO
        {
            public int Id { get; set; }
            public DateTime MoshaverehDate { get; set; }
            public string CaseNumber { get; set; }
            public string ClientRequestDescription { get; set; }
            public string MoshaverCode { get; set; }
            public string MoshaverIdea { get; set; }
            public string MoshaverExplaination { get; set; }
        }
    }

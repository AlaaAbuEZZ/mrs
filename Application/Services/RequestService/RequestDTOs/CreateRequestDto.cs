using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.RequestService.RequestDTOs
{
    public class CreateRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } // 👈 بدل CategoryId
        public string Location { get; set; }
    }
}

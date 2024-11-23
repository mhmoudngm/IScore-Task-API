using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Author.List
{
    public class GetAllAuthorsQueryResult
    {
        public List<AuthorDto> Collection { get; set; }
    }
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

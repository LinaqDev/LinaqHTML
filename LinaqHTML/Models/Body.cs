using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinaqHTML.Models
{
    public class Body : BaseTagElement
    {
        protected override string StartTag => "<body>";  
        protected override string EndTag => "</body>";  
    }
}

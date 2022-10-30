using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Contracts.Infrastructure.Interfaces
{
   public interface IPostService
   {
       public  Task<bool> CheckPostalCodeLen(int postalCode);

   }
}

namespace DataAccessLayer.DataClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    ///<summary>
    /// Author Scott Karney
    /// Company: Onshore Outsourcing
    /// Description: 
    /// </summary>
    public class UserDO
    {
      public int UserID { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Username { get; set; }
      public string Password { get; set; }
      public int RoleID { get; set; }

    }    
}

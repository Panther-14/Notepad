using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionBlogNotas.Singleton
{
    public class CurrentUser
    {
        private static CurrentUser? instance;

        public int IdUser { get; set; }
        public string? Token { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime RegisterDate { get; set; }
        public int Status { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? LstAccesToken { get; set; }
        public DateTime LastAccessDate { get; set; }
        public string? TempPassword { get; set; }
        public DateTime ActivationDate { get; set; }

        private CurrentUser()
        {
        }

        public static CurrentUser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CurrentUser();
                }

                return instance;
            }
        }

        public void KillInstance()
        {
            if (instance != null)
            {
                instance = null;
            }
        }
    }
}

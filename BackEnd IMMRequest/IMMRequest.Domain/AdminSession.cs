using System;

namespace IMMRequest.Domain
{
    public class AdminSession
    {
         public int Id { get; set; }
        public int Token { get; set; }
        public Administrador admin  { get; set; }
        public AdminSession() { }
    }
}
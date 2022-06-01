using System;

namespace IMMRequest.Domain
{
    public class Administrador
    {
        public Administrador()
        {
        }

        public Administrador(string nombre, string email, string contrasena)
        {
            Nombre = nombre;
            Email = email;
            Contrasena = contrasena;
        }

        public int Id{get ; set; }
        public String Nombre{get ; set; }

        public String Email{get ; set; }

        public String Contrasena{get ; set; }

        public void CambiarContrasena(String nuevoPassword){
            this.Contrasena=nuevoPassword;
        }

        public Boolean validarEmail(String email){
            if(email.Contains("@")&& email.Contains(".")){
                String[] lista = email.Split('@');
                if(lista[0]!=null&& lista[1].Contains(".")){
                    if(lista[1]!=null){
                        String[] divisionStringPunto = lista[1].Split('.');
                        if(divisionStringPunto[0]!=null & divisionStringPunto[0]!=null ){
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public Boolean esValido(){
            return validarEmail(this.Email)&&Nombre!=""&&Contrasena!="";
        }

        public void Update(Administrador admin){
            this.Nombre= admin.Nombre;
            this.Email= admin.Email;
            this.Contrasena = admin.Contrasena;
        }

        public override string ToString(){
            return this.Nombre + " " + this.Email;
        }
    }
}

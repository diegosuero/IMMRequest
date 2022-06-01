using System;
using System.Collections.Generic;

namespace IMMRequest.Domain
{
    public class Solicitud
    {

        public Solicitud()
        {
            Estado = "Creada";
            Descripcion="";
            CamposAdicionales = new List<CampoAdicional>();
            this.fechaIngreso=DateTime.Now;
        }

        public int Id{get ; set; }
        public String nombre{get ; set; }
        public String mail{get ; set; }
        public String telefono{get ; set; }
        public String Detalle{get ; set; }

        public String Descripcion{get ; set; }
        public Area Area{get ; set; }
        public Tema Tema {get ; set; }

        public DateTime fechaIngreso{get ; set; }

        public TipoDeTema Tipo {get ; set; }
        public List<CampoAdicional> CamposAdicionales{get ; set; }

        public String Estado {get ; set; }

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
            throw new ArgumentException("Email Invalido");
        }

        public void CambiarEstado(String estado){
            List<String> estados = new List<String>(){"Creada","En revisión","Aceptada","Denegada","Finalizada"};
            if(estados.Contains(estado)){
                this.Estado=estado;
                return;
            }
            throw new ArgumentException("Estado Invalido");
        }
    }
}

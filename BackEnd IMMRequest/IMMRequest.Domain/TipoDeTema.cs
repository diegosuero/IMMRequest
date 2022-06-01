using System;
using System.Collections.Generic;

namespace IMMRequest.Domain
{
    public class TipoDeTema
    {
        public TipoDeTema()
        {
            Campos = new List<CampoAdicional>();
        }

        public int ID{get ; set; }
        public String nombre{get ; set; }
        public List<CampoAdicional> Campos {get ; set; }

        public Boolean Activo{get ; set; }

        public void AgregarCampos(List<CampoAdicional> campos){
            for (int i = 0; i < campos.Count; i++){
                if (Campos.Find(x=> x.Nombre==campos[i].Nombre)==null)
                {
                    Campos.Add(campos[i]);
                }else{
                    throw new ArgumentException("Ya existe un campo con ese nombre");
                }
            }
        }

    }
}

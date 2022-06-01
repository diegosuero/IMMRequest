using System;
using System.Collections.Generic;
using IMMRequest.BusinessLogic.Interface;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using System.Linq;

namespace IMMRequest.BusinessLogic
{
    public class SolicitudLogic : ILogic<Solicitud>
    {
        private IRepository<Solicitud> repository;

        private ILogic<Area> logicArea;
        private ILogic<Tema> logicTema;
        private ILogic<TipoDeTema> logicTipo;
        private ILogic<CampoAicionalTexto> logicCampoTexto;
        private ILogic<CampoAdicionalFecha> logicCampoFecha;
        private ILogic<CampoAdicionalEntero> logicCampoEntero;


        public SolicitudLogic(IRepository<Solicitud> repository, ILogic<Area> logica,ILogic<Tema> logicTema,ILogic<TipoDeTema> logicTipo,ILogic<CampoAicionalTexto> logicCampoTexto,ILogic<CampoAdicionalFecha> logicCampoFecha,ILogic<CampoAdicionalEntero> logicCampoEntero)
        {
            this.logicTema =logicTema;
            this.logicTipo =logicTipo;
            this.logicCampoTexto = logicCampoTexto;
            this.repository = repository;
            this.logicArea=logica;
            this.logicCampoTexto=logicCampoTexto;
            this.logicCampoFecha=logicCampoFecha;
            this.logicCampoEntero=logicCampoEntero;
        }

        public Solicitud Create(Solicitud entity)
        {
            Solicitud solicitud = new Solicitud(){
                nombre=entity.nombre,
                telefono=entity.telefono,
                Detalle=entity.Detalle
            };
            if (solicitud.nombre!=""&&solicitud.Detalle!=""){
                if(entity.validarEmail(entity.mail)){
                    solicitud.mail=entity.mail;
                    if(entity.Area!=null){
                        Area area = logicArea.GetByString(entity.Area.Nombre);
                        solicitud.Area=area;
                        Tema tema = TemaCorrespondeAArea(area,entity.Tema);
                        solicitud.Tema=tema;
                        TipoDeTema tipo = TipoCorrespondeATema(tema,entity.Tipo);
                        solicitud.Tipo=tipo;
                        /*
                        if(tipo.Campos.Count>0){
                            List<CampoAdicional> campos = CamposCorrespondenATipo(entity.CamposAdicionales,tipo);
                            List<CampoAdicional> camposEntity = entity.CamposAdicionales;
                            solicitud.CamposAdicionales=setearValores(campos,camposEntity);
                        }
                        */
                        repository.Add(solicitud);
                        repository.Save();
                        return solicitud;
                    }             
                }
            }else{
                throw new ArgumentException("Nombre y/o Detalle no pueden ser vacios");
            }
            throw new ArgumentException("Solicitud invalida");
        }

        public Tema TemaCorrespondeAArea(Area a,Tema t){
            List<Tema> listaTemas= a.Temas;
            Tema tema;
            for(int i =0 ; i< listaTemas.Count; i++){
                    if(listaTemas[i].Nombre==t.Nombre){
                        tema=listaTemas[i];
                        return logicTema.Get(tema.Id);
                    }
                }
            throw new ArgumentException("Tema Invalido");
        }

        public TipoDeTema TipoCorrespondeATema(Tema t, TipoDeTema tipo){
            List<TipoDeTema> listaTipos= t.Tipos.Where(x=> x.Activo == true).ToList();
            TipoDeTema tipoTema;
            for(int i =0 ; i< listaTipos.Count; i++){
                    if(listaTipos[i].nombre==tipo.nombre){
                        tipoTema=listaTipos[i];
                        if (tipoTema.Activo)
                        {
                           return logicTipo.Get(tipoTema.ID);  
                        }
                    }
                }
            throw new ArgumentException("Tipo Invalido");
        }

        public List<CampoAdicional> CamposCorrespondenATipo(List<CampoAdicional> campos, TipoDeTema tipo){
            List<CampoAdicional> listaCampos= tipo.Campos;
            if(campos.Count>listaCampos.Count||campos.Count<listaCampos.Count){
                throw new ArgumentException("Campos Invalidos");
            }
            for(int i =0 ; i< listaCampos.Count; i++){
                    if(campos.Where(x=> x.Nombre==listaCampos[i].Nombre)==null){
                        throw new ArgumentException("Campos Invalidos");
                    }
                }
            return campos;
        }

        public List<CampoAdicional> setearValores(List<CampoAdicional> campos, List<CampoAdicional> camposEntity){
            List<CampoAdicional> ret =new List<CampoAdicional>();
            for (int i = 0; i < campos.Count; i++){
                            for (int j = 0; j < camposEntity.Count; j++){
                                CampoAdicional c =camposEntity[j]; 
                                if(c.Nombre==campos[i].Nombre){
                                    if(c.GetType().Equals("CampoAdicionalEntero")){ 
                                        CampoAdicionalEntero campoEnteroReal =(CampoAdicionalEntero)campos[i];
                                        CampoAdicionalEntero campoEnteroentity =(CampoAdicionalEntero)c;
                                        CampoAdicionalEntero campoEntero = new CampoAdicionalEntero(){
                                            cotaInferior=campoEnteroReal.cotaInferior,
                                             cotaSuperior=campoEnteroReal.cotaSuperior,
                                            Nombre=campoEnteroReal.Nombre
                                        };
                                        campoEntero.setearValor(campoEnteroentity.valores);
                                        logicCampoEntero.Create(campoEntero);
                                        ret.Add(campoEntero);
                                        
                                        
                                    }else if(c.GetType().Equals("CampoAdicionalFecha")){

                                        CampoAdicionalFecha campoFechaReal =(CampoAdicionalFecha)campos[i];
                                        CampoAdicionalFecha campoFechaentity =(CampoAdicionalFecha)c;
                                        CampoAdicionalFecha campoFecha = new CampoAdicionalFecha(){
                                            cotaInferior=campoFechaReal.cotaInferior,
                                            cotaSuperior=campoFechaReal.cotaSuperior,
                                            Nombre=campoFechaReal.Nombre
                                        };
                                        campoFecha.setearValor(campoFechaentity.valores);
                                        ret.Add(campoFecha);
                                        logicCampoFecha.Create(campoFecha);
                                    }else if(c.GetType().Equals("CampoAicionalTexto")){
                                        CampoAicionalTexto campoTextoReal =(CampoAicionalTexto)campos[i];
                                        CampoAicionalTexto campoTextoentity =(CampoAicionalTexto)c;
                                        CampoAicionalTexto campoTexto = new CampoAicionalTexto(){
                                            valores=logicCampoTexto.Get(campoTextoReal.Id).valores,
                                            Nombre=campoTextoReal.Nombre
                                        };
                                        campoTexto.setearValor(campoTextoentity.valores);
                                        ret.Add(campoTexto);
                                        logicCampoTexto.Create(campoTexto);
                                    }
                                }
                            }
                        }
            return ret;
        }

        public Solicitud Get(int id)
        {
            try{
                return repository.Get(id);
            }catch(Exception ){
                throw new ArgumentException("No existe ese id");
            }
        }

        public IEnumerable<Solicitud> GetAll()
        {
            return repository.GetAll();
        }

        public void Remove(int id)
        {
            Solicitud s = repository.Get(id);
            repository.Remove(s);
            repository.Save();
        }

        public Solicitud Update(int id, Solicitud entity)
        {
            Solicitud s = repository.Get(id);
            s.CambiarEstado(entity.Estado);
            s.Descripcion=entity.Descripcion;
            repository.Update(entity);
            return entity;
        }

        public Solicitud GetByString(String stringg)
        {
            try{
                return repository.GetByString(stringg);
            }catch(Exception ){
                throw new ArgumentException("No existe ese id");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using IMMRequest.BusinessLogic.Interface;
using IMMRequest.Domain;
using Importador;

namespace IMMRequest.BusinessLogic
{
    public class ImportadorLogic
    {
        private ILogic<Area> areaLogic;
        private ILogic<Tema> temaLogic;
        public ImportadorLogic(ILogic<Area> areaLogic, ILogic<Tema> temaLogic)
        {
            this.areaLogic=areaLogic;
            this.temaLogic=temaLogic;
        }

        public IEnumerable<string> getImportadores(){
            try{
                List<String> ret = new List<string>();
                // Cargamos el assembly en memoria
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory()+"/Importadores");
                foreach (var file in files){
                    var dllFile = new FileInfo(file);
                    Assembly myAssembly = Assembly.LoadFile(dllFile.FullName);
                    IEnumerable<Type> implementations = GetTypesInAssembly<Importador.Importador>(myAssembly);  
                    foreach (var implementation in implementations){
                        ret.Add("Una implementacion");
                        Importador.Importador importador = (Importador.Importador)Activator.CreateInstance(implementation);

                        ret.Add(importador.getNombre());
                    }
                }
                return ret;
            }catch(Exception e){
                throw new ArgumentException(e.Message);
            }
        }

        private static IEnumerable<Type> GetTypesInAssembly<Interface>(Assembly assembly)
        {
            List<Type> types = new List<Type>();
            foreach (var type in assembly.GetTypes())
            {
                if (typeof(Interface).IsAssignableFrom(type))
                    types.Add(type);
                    
            }
            
            return types;
        }

        public void Importar(string path, string nombreImportador, string aImportar){
            try{
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory()+"/Importadores");
                foreach (var file in files){    
                    var dllFile = new FileInfo(file);
                    Assembly myAssembly = Assembly.LoadFile(dllFile.FullName);

                    IEnumerable<Type> implementations = GetTypesInAssembly<Importador.Importador>(myAssembly);
                    foreach (var implementation in implementations)
                    {
                        Importador.Importador importador = (Importador.Importador)Activator.CreateInstance(implementation);
                        if(importador.getNombre().Equals(nombreImportador)){
                            if (aImportar.Equals("Areas")){
                                List<Area> areaList = importador.importarAreas(path);
                                foreach (var area in areaList){
                                    areaLogic.Create(area);
                                }
                            }if (aImportar.Equals("Temas")){
                                List<Area> areaList = importador.importarTemas(path);
                                foreach (var area in areaList){
                                    Area areaReal = areaLogic.GetByString(area.Nombre);
                                    foreach (var tema in area.Temas){
                                        areaReal.agregartema(tema);
                                        this.areaLogic.Update(areaReal.Id,areaReal);
                                    }
                                }                        
                            }if (aImportar.Equals("Tipos")){
                                List<Area> areaList = importador.importarTipos(path);
                                foreach (var area in areaList){
                                    Area areaReal = areaLogic.GetByString(area.Nombre);
                                    foreach (var tema in area.Temas){
                                        Tema temaReal = areaReal.Temas.Find(x => x.Nombre==tema.Nombre);
                                        foreach (var tipo in tema.Tipos){
                                            temaReal.AgregarTipo(tipo);
                                            temaLogic.Update(temaReal.Id,temaReal);
                                        }
                                    }
                                    this.areaLogic.Update(areaReal.Id,areaReal);
                                }                        
                            }
                        }    
                    }
                }
            }catch(Exception e){
                throw new ArgumentException("Hubo un problema Importando el Archivo");
            }
        }
    }
}
using System.Collections.Generic;
using IMMRequest.Domain;

namespace Importador
{
    public interface Importador
    {
        List<Area> importarAreas(string path);
        List<Area> importarTipos(string path);

        List<Area> importarTemas(string path);

        string getNombre();

    }
}
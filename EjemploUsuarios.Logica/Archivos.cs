using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EjemploUsuarios.Logica
{
    public static class Archivos
    {
        public static void GuardarEnArchivoJson(Usuario data)
        {
            var listado = LeerDesdeArchivoJson();

            if (data.Id != 0)
            {
                listado.RemoveAll(x => x.Id == data.Id);
            }

            listado.Add(data);

            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.json");
            string json = JsonConvert.SerializeObject(listado, Formatting.Indented);
            File.WriteAllText(rutaArchivo, json);
        }

        public static List<Usuario> LeerDesdeArchivoJson()
        {
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.json");

            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);
                return JsonConvert.DeserializeObject<List<Usuario>>(json);
            }
            else
            {
                return new List<Usuario>();
            }
        }
    }
}

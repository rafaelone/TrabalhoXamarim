using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XF.LocalDB.Model
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
    }

    public class Usuariorepository
    {
        public Usuariorepository()
        {
        }

        private static readonly Usuariorepository instance = new Usuariorepository();
        public static Usuariorepository Instance
        {
            get
            {
                return instance;
            }
        }

        public static bool IsAutenticado(Usuario paramUsuario)
        {
            XElement xmlUsuario = XElement.Parse(App.UsuarioVM.Stream);
            var usuarios = new List<Usuario>();
            foreach (var item in xmlUsuario.Elements("usuario"))
            {
                Usuario usuario = new Usuario()
                {
                    Nome = item.Element("username").Value,
                    Senha = item.Element("senha").Value,
                };
                usuarios.Add(usuario);
            }

            return usuarios.Any(user => user.Nome == paramUsuario.Nome &&
            user.Senha == paramUsuario.Senha);
        }
    }

}

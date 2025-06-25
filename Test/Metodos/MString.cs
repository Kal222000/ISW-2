using System;
using System.Text.RegularExpressions;
using Test.DTOs;

namespace Test.Metodos
{
    public static class MString
    {
        public static bool String(string str)
        {
            if (string.IsNullOrEmpty(str)) { return false; }
            if (str.Contains(" ")) { return false; }
            if(str.StartsWith(" ")) { return false; }
            return true;
        }

        public static bool ValidarContrasena(string contrasena)
        {
            if (contrasena.Length < 8) { return false; }
            if (String(contrasena) == false) { return false; }

            bool Mayuscula = false;

            bool Numero = false;

            foreach (char c in contrasena)
            {
                if (char.IsUpper(c)) { Mayuscula = true; }

                if (char.IsDigit(c)) { Numero = true; }
            }

            return Mayuscula && Numero;
        }

        public static bool Validar(NuevoUsuarioDTO usuario)
        {
            if (String(usuario.Nombre) == false) { return false; }
            if (String(usuario.ApellidoMaterno) == false) { return false; }
            if (String(usuario.ApellidoPaterno) == false) { return false; }
            return true;
        }

        public static bool Titulo(string str)
        {
            if (string.IsNullOrEmpty(str)) { return false; }
            if (str.StartsWith(" ")) { return false; }
            return true;
        }
    }
}
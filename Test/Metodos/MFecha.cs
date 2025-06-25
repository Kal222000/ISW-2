using System;
using System.Text.RegularExpressions;

namespace Test.Metodos
{
    public static class MFecha
    {
        public static bool MayorDeEdad(DateTime fechaNacimiento)
        {
            var hoy = DateTime.Today;

            int edad = hoy.Year - fechaNacimiento.Year;

            if (fechaNacimiento.Date > hoy.AddYears(-edad))
            {
                edad--;
            }

            if (edad >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
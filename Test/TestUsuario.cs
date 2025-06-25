using System;
using Test.DTOs;
using Test.Metodos;
namespace Test;

public class TestUsuario
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ValidarContrasena1()
    {
        string contrasena = "";
        bool resultado = MString.ValidarContrasena(contrasena);
        if (resultado)
        {
            Assert.Fail("La contrasena ha pasado el test a pesar de ser nulla.");
        }
    }

    [Test]
    public void ValidarContrasena2()
    {
        string contrasena = " H";
        bool resultado = MString.ValidarContrasena(contrasena);
        if (resultado)
        {
            Assert.Fail("La contrasena ha pasado el test a pesar de que su pirmer caracter es un espacio.");
        }
    }

    [Test]
    public void ValidarContrasena3()
    {
        string contrasena = "   ";
        bool resultado = MString.ValidarContrasena(contrasena);
        if (resultado)
        {
            Assert.Fail("La contrasena ha pasado el test a pesar de ser una cadena de espacios");
        }
    }

    [Test]
    public void ValidarContrasena4()
    {
        string contrasena = "HaloWars";
        bool resultado = MString.ValidarContrasena(contrasena);
        if (resultado)
        {
            Assert.Fail("La contrasena ha pasado el test a pesar de que no cuenta con un numero.");
        }
    }

    [Test]
    public void ValidarContrasena5()
    {
        string contrasena = "hal0wars";
        bool resultado = MString.ValidarContrasena(contrasena);
        if (resultado)
        {
            Assert.Fail("La contrasena ha pasado el test a pesar de que no cuenta con una letra en mayuscula.");
        }
    }

    [Test]
    public void ValidarContrasena6()
    {
        string contrasena = "Nova123";
        bool resultado = MString.ValidarContrasena(contrasena);
        if (resultado)
        {
            Assert.Fail("La contrasena ha pasado el test a pesar de que no cuenta con la longitud minima.");
        }
    }

    [Test]
    public void ValidarContrasenaCorrecta()
    {
        string contrasena = "Hola1234";
        bool resultado = MString.ValidarContrasena(contrasena);
        Assert.Pass("La contraseña debería ser válida.");
    }

    [Test]
    public void ValidarUsuario1()
    {
        var usuario = new NuevoUsuarioDTO
        {
            Nombre = null,
            ApellidoPaterno = null,
            ApellidoMaterno = null
        };
        bool resultado = MString.Validar(usuario);
        if (resultado)
        {
            Assert.Fail("El DTO ha superado las pruebas a pesar de que cuenta con un elemento nulo");
        }
    }

    [Test]
    public void ValidarUsuario2()
    {
        var usuario = new NuevoUsuarioDTO
        {
            Nombre = " Marcus",
            ApellidoPaterno = "  ",
            ApellidoMaterno = "La ra"
        };
        bool resultado = MString.Validar(usuario);
        if (resultado)
        {
            Assert.Fail("El DTO ha superado las pruebas a pesar de que cuenta con espacios en los campos");
        }
    }

    [Test]
    public void ValidarCorrecto()
    {
        var usuario = new NuevoUsuarioDTO
        {
            Nombre = "Israel",
            ApellidoPaterno = "Gutierrez",
            ApellidoMaterno = "Lara"
        };
        bool resultado = MString.Validar(usuario);
        if (!resultado)
        {
            Assert.Fail("A pesar de que es valido el usuario, no ha superado la prueba");
        }
    }

    [Test]
    public void ValidarCarnet1()
    {
        int CARNET = 0;
        bool resultado = MInt.Carnet(CARNET);
        if (resultado)
        {
            Assert.Fail("Ha superado la prueba a pesar de ser <= 0");
        }
    }

    [Test]
    public void ValidarCarnet2()
    {
        int CARNET = 2;
        bool resultado = MInt.Carnet(CARNET);
        if (resultado)
        {
            Assert.Pass("Ha superado la prueba.");
        }
    }

    [Test]
    public void Edad1()
    {
        DateTime fechaNacimiento = new DateTime(2000, 6, 25);
        bool resultado = MFecha.MayorDeEdad(fechaNacimiento);
        if (!resultado)
        {
            Assert.Fail("Ha fallado la prueba a pesar de ser mayor de edad.");
        }
    }

    [Test]
    public void Edad2()
    {
        DateTime fechaNacimiento = new DateTime(2010, 6, 25);
        bool resultado = MFecha.MayorDeEdad(fechaNacimiento);
        if (resultado)
        {
            Assert.Fail("Ha superado la prueba a pesar de ser menor de Edad.");
        }
    }
}

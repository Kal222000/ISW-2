using System;
using Test.DTOs;
using Test.Metodos;
namespace Test;

public class TestLibro
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ValidarTitulo1()
    {
        string titulo = null;
        bool result = MString.Titulo(titulo);
        if (result)
        {
            Assert.Fail("Ha superado la prueba a pesar de ser un null.");
        }
    }

    [Test]
    public void ValidarTitulo2()
    {
        string titulo = " null";
        bool result = MString.Titulo(titulo);
        if (result)
        {
            Assert.Fail("Ha superado la prueba a pesar de que el primer caracter en la cadena es un espacio.");
        }
    }

    [Test]
    public void ValidarTitulo3()
    {
        string titulo = "La Vida";
        bool result = MString.Titulo(titulo);
        if (!result)
        {
            Assert.Fail("A pesar de ser una cadena valida, no ha superado la prueba.");
        }
    }
}
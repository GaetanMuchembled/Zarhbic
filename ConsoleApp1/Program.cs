using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

Stack<int> Nombres = new Stack<int>();

string saisie = string.Empty;

string[] saisiearrangee;

int res = 0;

void Saisie()
{
    Console.WriteLine("Saisir une opération (composée d'uniquement des chiffres et des opérandes + - / *");
    saisie = Console.ReadLine();
}

void ArrangerLaSaisie()
{
    saisiearrangee = saisie.Split(' ');
}

int NombreEntiers = 0;
int NombreOperateurs = 0;
bool intrus = false;
bool PremiersEntiers = false;

void VerifNombre()
{
    foreach (string element in saisiearrangee)
    {
        if (EstUnEntier(element))
        {
            NombreEntiers++;
        }
        else
        {
            if (element == "+" || element == "-" || element == "*" || element == "/")
            {
                NombreOperateurs++;
            }
            else
            {
                intrus = true;
            }
        }
    }
}

void VerifPremiers()
{
    if (EstUnEntier(saisiearrangee[0]) && EstUnEntier(saisiearrangee[1]))
    {
        PremiersEntiers = true;
    }
}

bool VerifSaisie()
{
    bool CalculRealisable = false;

    VerifNombre();
    VerifPremiers();

    if (intrus == false && PremiersEntiers)
    {
        if(NombreEntiers - 1 == NombreOperateurs)
        {
            CalculRealisable = true;
        }
    }
    return CalculRealisable;
}

bool EstUnEntier(string atester)
{
    return int.TryParse(atester, out _);
}

int operation(int x, int y, char operateur)
{
    switch (operateur)
    {
        case '+':
            return x + y;
            break;
        case '-':
            return x - y;
            break;
        case '/':
            return x / y;
            break;
        case '*':
            return x * y;
            break;
        default: return 0;
    }
}

void Calcul()
{
    foreach (string element in saisiearrangee)
    {
        int index = 0;
        if (EstUnEntier(element))
        {
            Nombres.Push(Convert.ToInt32(element));
        }
        else
        {
            int y = (Nombres.Peek());
            Nombres.Pop();
            int x = (Nombres.Peek());
            Nombres.Pop();

            res = operation(x, y, Convert.ToChar(element));

            Nombres.Push(res);
        }

    }
}

void AffichageResultat()
{
    Console.WriteLine("\nZarhbic effectue son savant calcul...");
    Console.WriteLine($"Le résultat est : {res}");
}

void Zarhbic()
{
    Saisie();
    ArrangerLaSaisie();

    if(VerifSaisie())
    {
        Calcul();
        AffichageResultat();
    }
    else
    {
        Console.WriteLine("Calcul impossible ; mauvaise saisie");
    }
    
}

Zarhbic();
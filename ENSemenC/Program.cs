// Créer des terrains et des plantes pour tester (penser à la météo et la saison associées)
using System.Diagnostics;

Meteo meteo = Meteo.Normal;
Saison saison = Saison.Printemps;

Terrain.meteo = meteo;
Terrain.saison = saison;

Terrain terr1 = new Herbeux();
Terrain terr2 = new Rocheux();
Terrain terr3 = new Dune();
Terrain terr4 = new Jungle();

// Vérifier que la MAJ de la luminosité, la température et de l'humidité marchent bien
/*

double baseHumidite = 0.5;
terr1.HumidificationSol(baseHumidite);
terr1.AdaptationSol();
Console.WriteLine(terr1.humidite);
Debug.Assert(terr1.humidite == baseHumidite - (1 - terr1.retention) * 0.01);

terr2.HumidificationSol(baseHumidite);
terr2.AdaptationSol();
Console.WriteLine(terr2.humidite);
Debug.Assert(terr2.humidite == baseHumidite - (1 - terr2.retention) * 0.01);

terr3.HumidificationSol(baseHumidite);
terr3.AdaptationSol();
Console.WriteLine(terr3.humidite);
Debug.Assert(terr3.humidite == baseHumidite - (1 - terr3.retention) * 0.01);

terr4.HumidificationSol(baseHumidite);
terr4.AdaptationSol();
Console.WriteLine(terr4.humidite);
Debug.Assert(terr4.humidite == baseHumidite - (1 - terr4.retention) * 0.01);

*/

// Variations de l'humidité très petites 0.5 --> 0.495/0.491/0.494/0.4975
// Peut-être mettre 0.1 au lieu de 0.01 dans méthode

// for (int i = 0; i < 20; i++)
// {
//     terr1.GererLumiere();
//     Console.WriteLine(Terrain.luminosite);
//     Debug.Assert(Terrain.luminosite < 0.75 + 0.1 && Terrain.luminosite > 0.75 - 0.1);
// }

for (int i = 0; i < 20; i++)
{
    terr1.GererTemperature();
    Console.WriteLine(terr1.temperature);
    Debug.Assert(terr1.temperature < 18.0 + 0.1 && terr1.temperature > 18.0 - 0.1);
}
for (int i = 0; i < 20; i++)
{
    terr2.GererTemperature();
    Console.WriteLine(terr2.temperature);
    Debug.Assert(terr2.temperature < 18.0 + 0.1 && terr2.temperature > 18.0 - 0.1);
}
for (int i = 0; i < 20; i++)
{
    terr3.GererTemperature();
    Console.WriteLine(terr3.temperature);
    Debug.Assert(terr3.temperature < 22.0 + 0.1 && terr3.temperature > 22.0 - 0.1);
}
for (int i = 0; i < 20; i++)
{
    terr4.GererTemperature();
    Console.WriteLine(terr4.temperature);
    Debug.Assert(terr4.temperature < 19.0 + 0.1 && terr4.temperature > 19.0 - 0.1);
}


// Créer des plantes

// Associer les 2

// Vérifier que les fonctions pour chercher luminosité et humidité marchent bien

// Vérifier que la croissance de la plante fonctionne (long à faire je pense)
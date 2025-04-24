public abstract class Plante {
    public string nom {get; set;}
    public string nature {get; set;}
    public Saison saisonPreferee {get; set;}
    public Terrain terrain {get; set;}
    public int espacement {get; set;}
    public int place {get; set;} //dont elle a besoin pour grandir, faire un tableau pour voir combien en longueur et en largeur elle occupe de place
    public double besoinsEau {get; set;} //à mettre en pourcentage, faire liste avec valeur min et max
    public double besoinsLuminosite {get; set;} //pareil que eau
    public int vitesseDeCroissance {get; set;} //défini par la plante, ses conditions de vie influent dessus;
    //calcul stade de croissance à laquelle est la plante, elle //par exemple 1-2-3-4 (voir 5 quand les fruits reviennent)
    public int esperanceDeVie {get; set;} //âge de la plante évolue comme la croissance, stade maximal
    public int age {get; set;} //qui augmente avec le temps qui passe
    public int croissanceMin {get; set;} //stade de croissance minimale de la plante pour qu'elle produise
    public bool vivante {get;set;}
    public Plante (string nom, string nature, Saison saisonPreferee, Terrain terrain, int espacement, int place, double besoinsEau, double besoinsLuminosite, int vitesseDeCroissance, int esperanceDeVie, int croissanceMin)
    {
        this.nom=nom;
        this.nature=nature;
        this.saisonPreferee=saisonPreferee;
        this.terrain=terrain;
        this.espacement=espacement;
        this.place=place;
        this.besoinsEau=besoinsEau;
        this.besoinsLuminosite=besoinsLuminosite;
        this.vitesseDeCroissance=vitesseDeCroissance;
        this.esperanceDeVie=esperanceDeVie;
        age=0;
        this.croissanceMin=croissanceMin;
        vivante=true;
    }
    public override string ToString()
    {
        return $"La {nom} est une plante de nature {nature}, sa saison préférée est {saisonPreferee}, ";
    }


}

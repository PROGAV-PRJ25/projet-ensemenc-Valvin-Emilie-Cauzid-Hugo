public abstract class Plante {
    public string nom {get; set;}
    public string nature {get; set;}
    public string saisonPreferee {get; set;}
    public Terrain terrain {get; set;}
    public int espacement {get; set;}
    public int place {get; set;}
    public double besoinsEau {get; set;} //à mettre en pourcentage
    public double besoinsLuminosite {get; set;}
    public int vitesseDeCroissance {get; set;} //défini par la plante, ses conditions de vie influent dessus;
    public int esperanceDeVie {get; set;} //âge de la plante évolue comme la croissance, stade maximal
    //int stadeDeCroissance {get; set;} //stade de croissance à laquelle est la plante, elle //par exemple 1-2-3-4 (voir 5 quand les fruits reviennent)
    public int croissanceMin {get; set;} //stade de croissance minimum de la plante pour qu'elle produise
    public Plante (string nom, string nature, string saisonPreferee, Terrain terrain, int espacement, int place, double besoinsEau, double besoinsLuminosite, int vitesseDeCroissance, int esperanceDeVie, int croissanceMin)
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
        this.croissanceMin=croissanceMin;
    }
    public override string ToString()
    {
        return $"La {nom} est une plante de nature {nature}, sa saison préférée est {saisonPreferee}, ";
    }


}

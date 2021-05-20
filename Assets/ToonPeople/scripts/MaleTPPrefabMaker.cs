using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class MaleTPPrefabMaker : MonoBehaviour
{
    public bool allOptions;
    int hair;
    int chest;
    int legs;
    int feet;
    int tie;
    int jacket;
    int skintone;
    public bool tieactive;
    public bool tieactivecolor;
    public bool glassesactive;
    public bool jacketactive;
    public bool hatactive;
    public bool beardactive;
    public bool haircoloractive;
    GameObject GOhead;
    GameObject GOheadsimple;
    GameObject GObeard;
    GameObject GObeardsimple;
    GameObject[] GOfeet;
    GameObject[] GOhair;
    GameObject[] GOchest;
    GameObject[] GOlegs;
    GameObject GOglasses;
    GameObject[] GOjackets;
    GameObject[] GOties;
    Object[] MATskins;
    Object[] MAThairs; Object[] MAThairA; Object[] MAThairB; Object[] MAThairC; Object[] MAThairD;
    Object[] MAThairE; Object[] MAThairF; Object[] MAThairG; 
    Object[] MATglasses;
    Object[] MATtshirt;
    Object[] MATshirtA;
    Object[] MATshirtB;
    Object[] MATeyes;
    Object[] MATjacket;
    Object[] MATsweater;
    Object[] MATlegs;
    Object[] MATfeetA;
    Object[] MATfeetB;
    Object[] MAThatA;
    Object[] MAThatB;
    Object[] MAThatC;
    Object[] MATbowtie;
    Object[] MATtie;
    Object[] MATbeard;
    Vector4 beard;
    Material trans;
    Material MATteeth;
    Material MATnoteeth;
    int eyeindex;
    int skinindex;
    int teethindex;
    string model;
    public bool elder;

    void Start()
    {
        allOptions = false;
    }

    public void Getready()

    {
        GOhead = (GetComponent<Transform>().GetChild(2).gameObject);
        Indentifymodel();
        GOheadsimple = (GetComponent<Transform>().GetChild(3).gameObject);

        GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
        GetComponent<Transform>().GetChild(3).gameObject.SetActive(false);
        GOfeet = new GameObject[2];
        GOhair = new GameObject[10];
        GOchest = new GameObject[7];
        GOlegs = new GameObject[2];
        GOjackets = new GameObject[2];
        GOties = new GameObject[3];
        MAThairs = new Object[41];
        beardactive = true;
        beard = new Vector4 (1, 1, 1, 1);
        MAThairA = new Object[3];
        MAThairB = new Object[3];
        MAThairC = new Object[3];
        MAThairD = new Object[3];
        MAThairE = new Object[3];
        MAThairF = new Object[3];
        MAThairG = new Object[3];
        MATbeard = new Object[3];


        for (int forAUX = 0; forAUX < 2; forAUX++) GOfeet[forAUX] = (GetComponent<Transform>().GetChild(forAUX + 6).gameObject);
        for (int forAUX = 0; forAUX < 10; forAUX++) GOhair[forAUX] = (GetComponent<Transform>().GetChild(forAUX + 8).gameObject); 
        for (int forAUX = 0; forAUX < 4; forAUX++) GOchest[forAUX] = (GetComponent<Transform>().GetChild(forAUX + 20).gameObject);
        for (int forAUX = 0; forAUX < 3; forAUX++) GOchest[forAUX + 4] = (GetComponent<Transform>().GetChild(forAUX + 28).gameObject);
        for (int forAUX = 0; forAUX < 2; forAUX++) GOlegs[forAUX] = (GetComponent<Transform>().GetChild(forAUX + 18).gameObject);
        for (int forAUX = 0; forAUX < 2; forAUX++) GOjackets[forAUX] = (GetComponent<Transform>().GetChild(forAUX + 24).gameObject);
        for (int forAUX = 0; forAUX < 2; forAUX++) GOties[forAUX + 1] = (GetComponent<Transform>().GetChild(forAUX + 26).gameObject);
        GOties[0] = (GetComponent<Transform>().GetChild(5).gameObject); 
        GObeard = (GetComponent<Transform>().GetChild(0).gameObject);
        GObeardsimple = (GetComponent<Transform>().GetChild(1).gameObject);
        GOglasses = transform.Find("ROOT/TP/TP Pelvis/TP Spine/TP Spine1/TP Spine2/TP Neck/TP Head/Glasses").gameObject as GameObject;

        //load  materials
        MATskins = Resources.LoadAll("materials/MALE/skin/" + model, typeof(Material));
        MATglasses = Resources.LoadAll("materials/COMMON/glasses", typeof(Material));
        MATtshirt = Resources.LoadAll("materials/MALE/tshirt", typeof(Material));
        MATshirtA = Resources.LoadAll("materials/MALE/shirtA formal", typeof(Material));
        MATshirtB = Resources.LoadAll("materials/MALE/shirtB casual", typeof(Material));
        MATeyes = Resources.LoadAll("materials/COMMON/eyes", typeof(Material));
        MATjacket = Resources.LoadAll("materials/COMMON/suits", typeof(Material));
        MATsweater = Resources.LoadAll("materials/COMMON/sweaters", typeof(Material));
        MATlegs = Resources.LoadAll("materials/COMMON/legs", typeof(Material));
        MATfeetA = Resources.LoadAll("materials/COMMON/feetA", typeof(Material));
        MATfeetB = Resources.LoadAll("materials/COMMON/feetB sport", typeof(Material));
        MAThatA = Resources.LoadAll("materials/COMMON/hatsA", typeof(Material));
        MAThatB = Resources.LoadAll("materials/COMMON/hatsB", typeof(Material));
        MAThatC = Resources.LoadAll("materials/MALE/hats", typeof(Material));
        MATbowtie = Resources.LoadAll("materials/COMMON/ties/bowtie", typeof(Material));
        MATtie = Resources.LoadAll("materials/COMMON/ties/tie", typeof(Material));
        MATbeard[0] = Resources.Load("materials/MALE/hairs and beards/beards/TPMBeard01", typeof(Material));
        MATbeard[1] = Resources.Load("materials/MALE/hairs and beards/beards/TPMBeard02", typeof(Material));
        MATbeard[2] = Resources.Load("materials/MALE/hairs and beards/beards/TPMBeard03", typeof(Material));
        MATteeth = Resources.Load("materials/COMMON/hair and teeth/TPteeth") as Material;
        MATnoteeth = Resources.Load("materials/COMMON/hair and teeth/TPgums") as Material;
        trans = Resources.Load("materials/MALE/hairs and beards/transparent")as Material;   
        MAThairs = Resources.LoadAll("materials/MALE/hairs and beards/hairs", typeof(Material));
        for (int forAUX = 0; forAUX < 3; forAUX++)
        {
            MAThairA[forAUX] = MAThairs[forAUX];
            MAThairB[forAUX] = MAThairs[forAUX + 4];
            MAThairC[forAUX] = MAThairs[forAUX + 8];
            MAThairD[forAUX] = MAThairs[forAUX + 12];
            MAThairE[forAUX] = MAThairs[forAUX + 16];
            MAThairF[forAUX] = Resources.Load("materials/COMMON/hair and teeth/TPHairF");    //afro
            MAThairG[forAUX] = MAThairs[forAUX + 20];            
        }
            Checkelder();

        if (GOfeet[0].activeSelf && GOfeet[1].activeSelf)
        {
            Randomize();
        }
        else
        {
            while (!GOhair[hair].activeSelf) hair++;            
            while (!GOchest[chest].activeSelf) chest++;
            while (!GOlegs[legs].activeSelf) legs++;
            while (!GOfeet[feet].activeSelf) feet++;
            if (GOjackets[0].activeSelf) jacket = 0; if (GOjackets[1].activeSelf) jacket = 1;
            if (!GOjackets[0].activeSelf && !GOjackets[1].activeSelf) jacket = 2;
            tie = 3;
            for (int forAUX = 0; forAUX > 3; forAUX++)
            {
                if (GOties[forAUX].activeSelf) tie = forAUX;
            }
            if (GOglasses.activeSelf) glassesactive = true;
            Checkties();
            Checkbeard();
        }
    }
    public void Indentifymodel()
    {
        Object[] tempMATA = Resources.LoadAll("materials/MALE/skin/TPMaleA", typeof(Material));
        Object[] tempMATB = Resources.LoadAll("materials/MALE/skin/TPMaleB", typeof(Material));
        Object[] tempMATC = Resources.LoadAll("materials/MALE/skin/TPMaleC", typeof(Material));
        Object[] tempMATD = Resources.LoadAll("materials/MALE/skin/TPMaleD", typeof(Material));
        string theskin = GOhead.GetComponent<Renderer>().sharedMaterials[0].name;
        for (int forAUX = 0; forAUX < tempMATA.Length; forAUX++)
        {
            if (theskin == tempMATA[forAUX].name) model = "TPMaleA";
        }
        for (int forAUX = 0; forAUX < tempMATB.Length; forAUX++)
        {
            if (theskin == tempMATB[forAUX].name) model = "TPMaleB";
        }
        for (int forAUX = 0; forAUX < tempMATC.Length; forAUX++)
        {
            if (theskin == tempMATC[forAUX].name) model = "TPMaleC";
        }
        for (int forAUX = 0; forAUX < tempMATD.Length; forAUX++)
        {
            if (theskin == tempMATD[forAUX].name) model = "TPMaleD";
        }
        skinindex = 0; eyeindex = 2; teethindex = 1;
        if (model == "TPMaleC") { eyeindex = 1; teethindex = 2; }
    }
    public void Deactivateall()
    {
        for (int forAUX = 0; forAUX < GOhair.Length; forAUX++) GOhair[forAUX].SetActive(false);
        for (int forAUX = 0; forAUX < GOchest.Length; forAUX++) GOchest[forAUX].SetActive(false);
        for (int forAUX = 0; forAUX < GOlegs.Length; forAUX++) GOlegs[forAUX].SetActive(false);
        for (int forAUX = 0; forAUX < GOfeet.Length; forAUX++) GOfeet[forAUX].SetActive(false);
        for (int forAUX = 0; forAUX < GOjackets.Length; forAUX++) GOjackets[forAUX].SetActive(false);
        for (int forAUX = 0; forAUX < GOties.Length; forAUX++) GOties[forAUX].SetActive(false);
        GOglasses.SetActive(false);
        GObeard.SetActive(false);
        glassesactive = false;
        jacketactive = false;
        tieactivecolor = false;
        tieactive = false;
        tieactivecolor = false;
        hatactive = false;
    }
    public void Activateall()
    {
        for (int forAUX = 0; forAUX < GOhair.Length; forAUX++) GOhair[forAUX].SetActive(true);
        for (int forAUX = 0; forAUX < GOchest.Length; forAUX++) GOchest[forAUX].SetActive(true);
        for (int forAUX = 0; forAUX < GOlegs.Length; forAUX++) GOlegs[forAUX].SetActive(true);
        for (int forAUX = 0; forAUX < GOfeet.Length; forAUX++) GOfeet[forAUX].SetActive(true);
        for (int forAUX = 0; forAUX < GOjackets.Length; forAUX++) GOjackets[forAUX].SetActive(true);
        for (int forAUX = 0; forAUX < GOties.Length; forAUX++) GOties[forAUX].SetActive(true);
        GOglasses.SetActive(true);
        GObeard.SetActive(true);
    }
    public void Menu()
    {
        allOptions = !allOptions;
    }
    public void Checkelder()
    {
        Material[] AUXmaterials;
        AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
        if (AUXmaterials[teethindex].name == MATteeth.name)
        {
            elder = false;
            haircoloractive = true;
            MATskins = Resources.LoadAll("materials/MALE/skin/" + model, typeof(Material));            
            int MATindex = 0;            
            AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
            while (AUXmaterials[0].name != MATskins[MATindex].name) MATindex++;
            for (int forAUX = 0; forAUX < 4; forAUX++)
            {
                MATskins[forAUX] = MATskins[forAUX + 4];
            }
            Resetskin(MATskins[MATindex] as Material);
            for (int forAUX = 0; forAUX < 3; forAUX++)
            {
                MAThairA[forAUX] = MAThairs[forAUX];
                MAThairB[forAUX] = MAThairs[forAUX + 4];
                MAThairC[forAUX] = MAThairs[forAUX + 8];
                MAThairD[forAUX] = MAThairs[forAUX + 12];
                MAThairE[forAUX] = MAThairs[forAUX + 16];
                MAThairF[forAUX] = Resources.Load("materials/COMMON/hair and teeth/TPHairF");    //afro
                MAThairG[forAUX] = MAThairs[forAUX + 20];
            }
            MATbeard[0] = Resources.Load("materials/MALE/hairs and beards/beards/TPMBeard01", typeof(Material));
            MATbeard[1] = Resources.Load("materials/MALE/hairs and beards/beards/TPMBeard02", typeof(Material));
            MATbeard[2] = Resources.Load("materials/MALE/hairs and beards/beards/TPMBeard03", typeof(Material));
        }
        else
        {
            elder = true;
            haircoloractive = false;
            MATskins = Resources.LoadAll("materials/MALE/skin/" + model, typeof(Material));
            int MATindex = 0;
            AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
            while (AUXmaterials[0].name != MATskins[MATindex].name) MATindex++;
            for (int forAUX = 0; forAUX < 4; forAUX++)
            {
                MATskins[forAUX + 4] = MATskins[forAUX];
            }
            Resetskin(MATskins[MATindex] as Material);
            for (int forAUX = 0; forAUX < 3; forAUX++)
            {
                MAThairA[forAUX] = MAThairs[3];
                MAThairB[forAUX] = MAThairs[7];
                MAThairC[forAUX] = MAThairs[11];
                MAThairD[forAUX] = MAThairs[15];
                MAThairE[forAUX] = MAThairs[19];
                MAThairF[forAUX] = Resources.Load("materials/COMMON/hair and teeth/TPHairF");    //afro
                MAThairG[forAUX] = MAThairs[23];
            }
            MATbeard[0] = Resources.Load("materials/MALE/hairs and beards/beards/TPMBeard04", typeof(Material));
            MATbeard[1] = Resources.Load("materials/MALE/hairs and beards/beards/TPMBeard04", typeof(Material));
            MATbeard[2] = Resources.Load("materials/MALE/hairs and beards/beards/TPMBeard04", typeof(Material));
        }
    }
    public void Checkties()
    {
        if (chest < 2)
        {
            tieactive = true;
            if (tie != 3)
            {
                GOties[tie].SetActive(true);
                tieactivecolor = true;
            }
            else tieactivecolor = false;
        }
        else
        {
            if (tie != 3) GOties[tie].SetActive(false);
            tieactive = false;
            tieactivecolor = false;
        }
    }
    public void Checkbeard()
    {
        if (GObeard.activeSelf)
        {
            beardactive = true;
            beard = new Vector4(1, 1, 1, 1);
            Material[] AUXmaterials;
            AUXmaterials = GObeard.GetComponent<Renderer>().sharedMaterials;
            if (AUXmaterials[0].name == trans.name) beard.x = 0;
            if (AUXmaterials[1] == trans) beard.y = 0;
            if (AUXmaterials[2] == trans) beard.z = 0;
            if (AUXmaterials[3] == trans) beard.w = 0;
        }
        else beardactive = false;
    }
    public void Checkmodel()
    {
        Checkties();
        Checkelder();
        Checkbeard();
    }



    //models
    public void Nexthat()
    {
        hatactive = true;
        if (hair < 7)
        {
            GOhair[hair].SetActive(false);
            hair = 7;
            GOhair[hair].SetActive(true);
        }
        else
        {
            GOhair[hair].SetActive(false);
            hair++;
            if (hair > GOhair.Length - 1) hair = 7;
            GOhair[hair].SetActive(true);
        }
    }
    public void Prevhat()
    {
        hatactive = true;
        if (hair < 7)
        {
            GOhair[hair].SetActive(false);
            hair = 9;
            GOhair[hair].SetActive(true);
        }
        else
        {
            GOhair[hair].SetActive(false);
            hair--;
            if (hair < 7) hair = 9;
            GOhair[hair].SetActive(true);
        }
    }
    public void Nexthair()
    {
        hatactive = false;
        GOhair[hair].SetActive(false);
        if (hair < GOhair.Length - 4) hair++;
        else hair = 0;
        GOhair[hair].SetActive(true);
    }
    public void GlassesOn()
    {
        glassesactive = !glassesactive;
        GOglasses.SetActive(glassesactive);
    }
    public void Nextchest()
    {
        GOchest[chest].SetActive(false);
        if (chest < GOchest.Length - 1) chest++;
        else chest = 0;
        GOchest[chest].SetActive(true);
        Checkties();
    }
    public void Nextlegs()
    {
        GOlegs[legs].SetActive(false);
        if (legs < GOlegs.Length - 1) legs++;
        else legs = 0;
        GOlegs[legs].SetActive(true);
    }
    public void Nextfeet()
    {
        GOfeet[feet].SetActive(false);
        if (feet < GOfeet.Length - 1) feet++;
        else feet = 0;
        GOfeet[feet].SetActive(true);
    }
    public void Nexttie()
    {
        if (tie != 3) GOties[tie].SetActive(false);
        if (tie < GOties.Length) tie++;
        else tie = 0;
        if (tie != 3) GOties[tie].SetActive(true);
        if (tie == 3) tieactivecolor = false;
        else tieactivecolor = true;
    }
    public void Nextjacket()
    {
        if (jacket == 2)
        {
            jacket = 0;
            GOjackets[jacket].SetActive(true);
            jacketactive = true;
        }
        else
        {
            if (jacket == 1)
            {
                GOjackets[jacket].SetActive(false);
                jacket = 2;
                jacketactive = false;
            }
            if (jacket == 0)
            {
                GOjackets[jacket].SetActive(false);
                jacket = 1;
                GOjackets[jacket].SetActive(true);
            }
        }
    }
    public void Prevhair()
    {
        hatactive = false;
        GOhair[hair].SetActive(false);
        if (hair > 0) hair--;
        else hair = 6;
        GOhair[hair].SetActive(true);
    }
    public void Prevchest()
    {
        GOchest[chest].SetActive(false);
        chest--;
        if (chest < 0) chest = GOchest.Length - 1;
        GOchest[chest].SetActive(true);
        Checkties();
    }
    public void Prevlegs()
    {
        GOlegs[legs].SetActive(false);
        if (legs > 0) legs--;
        else legs = GOlegs.Length - 1;
        GOlegs[legs].SetActive(true);
    }
    public void Prevfeet()
    {
        GOfeet[feet].SetActive(false);
        if (feet > 0) feet--;
        else feet = GOfeet.Length - 1;
        GOfeet[feet].SetActive(true);
    }
    public void Prevtie()
    {
        if (tie != 3) GOties[tie].SetActive(false);
        tie--;
        if (tie < 0) tie = 3;
        if (tie != 3) GOties[tie].SetActive(true);
        if (tie == 3) tieactivecolor = false;
        else tieactivecolor = true;
    }
    public void Prevjacket()
    {
        if (jacket == 0)
        {
            GOjackets[jacket].SetActive(false);
            jacket = 2;
            jacketactive = false;
        }
        else
        {
            if (jacket == 1)
            {
                GOjackets[jacket].SetActive(false);
                jacket = 0;
                GOjackets[jacket].SetActive(true);
            }
            if (jacket == 2)
            {
                jacket = 1;
                jacketactive = true;
                GOjackets[jacket].SetActive(true);
            }
        }
    }

    public void BeardOn()
    {
        beardactive = !beardactive;
        GObeard.SetActive(beardactive);
        if (beardactive)
        {
            beard = new Vector4(1, 1, 1, 1);
            Setbeard();
        }
    }
    public void Randombeard()
    {
        beard = new Vector4(1, 1, 1, 1);
        Setbeard();
        beard = new Vector4(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
        Setbeard();
    }
    public void Setbeard()
    {
        int MATindex=0;
        Material Op;
        Op = GOhair[0].GetComponent<Renderer>().sharedMaterial;
        while (Op.name != MAThairA[MATindex].name)MATindex++;
        Material[] AUXmaterials;
        AUXmaterials = GObeard.GetComponent<Renderer>().sharedMaterials;
        if (beard.x == 0) AUXmaterials[0] = trans;
        else AUXmaterials[0] = MATbeard[MATindex] as Material;
        if (beard.y == 0) AUXmaterials[1] = trans;
        else AUXmaterials[1] = MATbeard[MATindex] as Material;
        if (beard.z == 0) AUXmaterials[2] = trans;
        else AUXmaterials[2] = MATbeard[MATindex] as Material;
        if (beard.w == 0) AUXmaterials[3] = trans;
        else AUXmaterials[3] = MATbeard[MATindex] as Material;
        GObeard.GetComponent<Renderer>().sharedMaterials = AUXmaterials;
        //beardsimple
        AUXmaterials = GObeard.GetComponent<Renderer>().sharedMaterials;
        GObeardsimple.GetComponent<Renderer>().sharedMaterials = AUXmaterials;
    }
    
    //materials
    
    public void Nexthatcolor(int todo)
    {
        if (hatactive)
        {
            if (hair == 7) Setmaterials(GOhair, MAThatA, 0, todo);
            if (hair == 8) Setmaterials(GOhair, MAThatB, 0, todo);
            if (hair == 9) Setmaterials(GOhair, MAThatC, 0, todo);
        }        
    }
    public void Nextskincolor(int todo)
    {
        //head
        SetGOmaterials(GOhead, MATskins, skinindex, todo);
        //chest
        for (int forAUX = 0; forAUX < GOchest.Length; forAUX++)
        {
            SetGOmaterials(GOchest[forAUX], MATskins, 0, todo);
        }
        //legs        
        SetGOmaterials(GOlegs[1], MATskins, 0, todo);
        //headsimple
        Material[] AUXmaterials;
        AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
        GOheadsimple.GetComponent<Renderer>().sharedMaterials = AUXmaterials;
    }
    public void Nexthaircolor(int todo)
    {
        SetGOmaterial(GOhair[0], MAThairA, todo);
        SetGOmaterial(GOhair[1], MAThairB, todo);
        SetGOmaterial(GOhair[2], MAThairC, todo);
        SetGOmaterial(GOhair[3], MAThairD, todo);
        SetGOmaterial(GOhair[4], MAThairE, todo);
        SetGOmaterial(GOhair[5], MAThairF, todo);
        SetGOmaterial(GOhair[6], MAThairG, todo);
        SetGOmaterials(GOhair[7], MAThairG, 1, todo);
        SetGOmaterials(GOhair[8], MAThairG, 1, todo);
        SetGOmaterials(GOhair[9], MAThairG, 1, todo);
        Setbeard();
    }
    public void Nextglasses(int todo)
    {
        SetGOmaterial(GOglasses, MATglasses, todo);
    }
    public void Nexteyescolor(int todo)
    {
        SetGOmaterials(GOhead, MATeyes, eyeindex, todo);
        //headsimple
        Material[] AUXmaterials;
        AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
        GOheadsimple.GetComponent<Renderer>().sharedMaterials = AUXmaterials;
    }
    public void Nextchestcolor(int todo)
    {
        if (chest < 2) Setmaterials(GOchest, MATshirtA, 1, todo);
        if (chest > 1 && chest < 4)Setmaterials(GOchest, MATshirtB, 1, todo);  
        if (chest > 3) Setmaterials(GOchest, MATtshirt, 1, todo);
    }
    public void Nextjacketcolor(int todo)
    {
        if (jacket == 0) SetGOmaterial(GOjackets[0], MATjacket, todo);
        if (jacket == 1) SetGOmaterial(GOjackets[1], MATsweater, todo);
    }
    public void Nextlegscolor(int todo)
    {
        if (legs == 0 ) SetGOmaterial(GOlegs[0], MATlegs, todo);
        if (legs == 1) SetGOmaterials(GOlegs[1], MATlegs, 1, todo);  
    }
    public void Nextfeetcolor(int todo)
    {
        if (feet == 0) SetGOmaterial(GOfeet[0], MATfeetA, todo);
        if (feet == 1) SetGOmaterial(GOfeet[1], MATfeetB, todo);  
    }
    public void Nexttiecolor(int todo)
    {
        if (tie == 0) SetGOmaterial(GOties[0], MATbowtie, todo);
        if (tie == 1) SetGOmaterial(GOties[1], MATtie, todo);
        if (tie == 2) SetGOmaterial(GOties[2], MATtie, todo);
    }
    

    public void ResetModel()
    {
        ElderOff();
        beard = new Vector4(1, 1, 1, 1);
        Setbeard();
        Activateall();
        Menu();
    }
    public void Resetskin(Material skinbase)
    {
        //head
        Material[] AUXmaterials;
        AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
        AUXmaterials[skinindex] = skinbase;
        GOhead.GetComponent<Renderer>().sharedMaterials = AUXmaterials;
        //chest  
        for (int forAUX = 0; forAUX < GOchest.Length; forAUX++)
        {
            AUXmaterials = GOchest[forAUX].GetComponent<Renderer>().sharedMaterials;
            AUXmaterials[0] = skinbase;
            GOchest[forAUX].GetComponent<Renderer>().sharedMaterials = AUXmaterials;
        }
        //legs        
        AUXmaterials = GOlegs[1].GetComponent<Renderer>().sharedMaterials;
        AUXmaterials[0] = skinbase;
        GOlegs[1].GetComponent<Renderer>().sharedMaterials = AUXmaterials;        
    }
    public void Resethair()
    {
        GOhair[0].GetComponent<Renderer>().sharedMaterial = MAThairA[0] as Material;
        GOhair[1].GetComponent<Renderer>().sharedMaterial = MAThairB[0] as Material;
        GOhair[2].GetComponent<Renderer>().sharedMaterial = MAThairC[0] as Material;
        GOhair[3].GetComponent<Renderer>().sharedMaterial = MAThairD[0] as Material;
        GOhair[4].GetComponent<Renderer>().sharedMaterial = MAThairE[0] as Material;
        GOhair[6].GetComponent<Renderer>().sharedMaterial = MAThairG[0] as Material;
        Material[] AUXmaterials;
        AUXmaterials = GOhair[7].GetComponent<Renderer>().sharedMaterials;
        AUXmaterials[1] = MAThairG[0] as Material;
        GOhair[7].GetComponent<Renderer>().sharedMaterials = AUXmaterials;
        AUXmaterials = GOhair[8].GetComponent<Renderer>().sharedMaterials;
        AUXmaterials[1] = MAThairG[0] as Material;
        GOhair[8].GetComponent<Renderer>().sharedMaterials = AUXmaterials;
        AUXmaterials = GOhair[9].GetComponent<Renderer>().sharedMaterials;
        AUXmaterials[1] = MAThairG[0] as Material;
        GOhair[9].GetComponent<Renderer>().sharedMaterials = AUXmaterials;

        AUXmaterials = GObeard.GetComponent<Renderer>().sharedMaterials;
        AUXmaterials[0] = MATbeard[0] as Material;
        AUXmaterials[1] = MATbeard[0] as Material;
        AUXmaterials[2] = MATbeard[0] as Material;
        AUXmaterials[3] = MATbeard[0] as Material;
        GObeard.GetComponent<Renderer>().sharedMaterials = AUXmaterials;
    }
    public void Randomize()
    {
        Deactivateall();

        hair = Random.Range(0, 15);
        if (hair > 9) hair = Random.Range(0, 5);
        GOhair[hair].SetActive(true);
        if (hair > 5) hatactive = true;
        chest = Random.Range(0, 7); GOchest[chest].SetActive(true);
        tie = Random.Range(0, 4);
        Checkties();
        legs = Random.Range(0, 2); GOlegs[legs].SetActive(true);
        feet = Random.Range(0, 2); GOfeet[feet].SetActive(true);        
        jacket = Random.Range(0, 3);
        if (jacket < 2)
        {
            jacketactive = true;
            GOjackets[jacket].SetActive(true);           
        }
        else jacketactive = false;
        if (Random.Range(0, 6) < 4)  BeardOn(); 
        if (Random.Range(0, 5) < 3 & beardactive) Randombeard();
        if (Random.Range(0, 4) > 2)
        {
            glassesactive = true;
            GOglasses.SetActive(true);
            SetGOmaterial(GOglasses, MATglasses, 2);
        }
        else glassesactive = false;

        //materials
        for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 16)); forAUX2++) Nextskincolor(0);        
        for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 8)); forAUX2++) Nexthaircolor(0);
        if (tieactivecolor)
        {
            for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 10)); forAUX2++) Nexttiecolor(0);       
        }
        for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 26)); forAUX2++) Nextjacketcolor(0);        
        for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 34)); forAUX2++) Nextchestcolor(0);
        for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 32)); forAUX2++) Nextlegscolor(0);
        for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 26)); forAUX2++) Nextfeetcolor(0);
        for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 24)); forAUX2++) Nexthatcolor(0);
        SetGOmaterials(GOhead, MATeyes, eyeindex, 2);  
    }
    public void CreateCopy()
    {
        GameObject newcharacter = Instantiate(gameObject, transform.position, transform.rotation);
        for (int forAUX = 30; forAUX > 0; forAUX--)
        {
            if (!newcharacter.transform.GetChild(forAUX).gameObject.activeSelf) DestroyImmediate(newcharacter.transform.GetChild(forAUX).gameObject);
        }
        if (!GObeard.activeSelf) DestroyImmediate(newcharacter.transform.GetChild(0).gameObject);
        if (!GOglasses.activeSelf) DestroyImmediate(newcharacter.transform.Find("ROOT/TP/TP Pelvis/TP Spine/TP Spine1/TP Spine2/TP Neck/TP Head/Glasses").gameObject as GameObject);
        DestroyImmediate(newcharacter.GetComponent<MaleTPPrefabMaker>());
    }
    public void FIX()
    {
        GameObject newcharacter = Instantiate(gameObject, transform.position, transform.rotation);
        for (int forAUX = 30; forAUX > 0; forAUX--)
        {
            if (!newcharacter.transform.GetChild(forAUX).gameObject.activeSelf) DestroyImmediate(newcharacter.transform.GetChild(forAUX).gameObject);
        }
        if (!GObeard.activeSelf) DestroyImmediate(newcharacter.transform.GetChild(0).gameObject);
        if (!GOglasses.activeSelf) DestroyImmediate(newcharacter.transform.Find("ROOT/TP/TP Pelvis/TP Spine/TP Spine1/TP Spine2/TP Neck/TP Head/Glasses").gameObject as GameObject);
        DestroyImmediate(newcharacter.GetComponent<MaleTPPrefabMaker>());
        DestroyImmediate(gameObject);
    }

    public void ElderOn()
    {
        elder = true;
        haircoloractive = false;
        //blendshapes
        SkinnedMeshRenderer rendhead;
        rendhead = GOhead.GetComponent<SkinnedMeshRenderer>();
        rendhead.SetBlendShapeWeight(26, 100);
        SkinnedMeshRenderer rendbeard;
        rendbeard = GObeard.GetComponent<SkinnedMeshRenderer>();
        rendbeard.SetBlendShapeWeight(9, 100);
        //skin
        MATskins = Resources.LoadAll("materials/MALE/skin/" + model, typeof(Material));
        int MATindex = 0;
        Material[] AUXmaterials;
        AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
        while (AUXmaterials[0].name != MATskins[MATindex].name) MATindex++;
        for (int forAUX = 0; forAUX < 4; forAUX++)
        {
            MATskins[forAUX + 4] = MATskins[forAUX];
        }
        Resetskin(MATskins[MATindex] as Material);
        //hair
        for (int forAUX = 0; forAUX < 3; forAUX++)
        {
            MAThairA[forAUX] = MAThairs[3];
            MAThairB[forAUX] = MAThairs[7];
            MAThairC[forAUX] = MAThairs[11];
            MAThairD[forAUX] = MAThairs[15];
            MAThairE[forAUX] = MAThairs[19];
            MAThairF[forAUX] = Resources.Load("materials/COMMON/hair and teeth/TPHairF");    //afro
            MAThairG[forAUX] = MAThairs[23];
        }
        MATbeard[0] = Resources.Load("materials/MALE/hairs and beards/beards/TPMBeard04", typeof(Material));
        MATbeard[1] = Resources.Load("materials/MALE/hairs and beards/beards/TPMBeard04", typeof(Material));
        MATbeard[2] = Resources.Load("materials/MALE/hairs and beards/beards/TPMBeard04", typeof(Material));
        Resethair();
        AUXmaterials = GObeard.GetComponent<Renderer>().sharedMaterials;
        GObeardsimple.GetComponent<Renderer>().sharedMaterials = AUXmaterials;
        //teeth
        AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
        AUXmaterials[teethindex] = MATnoteeth;
        GOhead.GetComponent<Renderer>().sharedMaterials = AUXmaterials;
    }
    public void ElderOff()
     
        {
        elder = false;
        haircoloractive = true;
        //blendshapes
        SkinnedMeshRenderer rendhead;
        rendhead = GOhead.GetComponent<SkinnedMeshRenderer>();
        rendhead.SetBlendShapeWeight(26, 0);
        SkinnedMeshRenderer rendbeard;
        rendbeard = GObeard.GetComponent<SkinnedMeshRenderer>();
        rendbeard.SetBlendShapeWeight(9, 0);
        //skin
        MATskins = Resources.LoadAll("materials/MALE/skin/" + model, typeof(Material));
        int MATindex = 0;
        Material[] AUXmaterials;
        AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
        while (AUXmaterials[0].name != MATskins[MATindex].name)MATindex++;
        for (int forAUX = 0; forAUX < 4; forAUX++)
        {
                MATskins[forAUX] = MATskins[forAUX+4];
        }        
        Resetskin(MATskins[MATindex] as Material);
        //hair
        for (int forAUX = 0; forAUX < 3; forAUX++)
        {
                MAThairA[forAUX] = MAThairs[forAUX];
                MAThairB[forAUX] = MAThairs[forAUX + 4];
                MAThairC[forAUX] = MAThairs[forAUX + 8];
                MAThairD[forAUX] = MAThairs[forAUX + 12];
                MAThairE[forAUX] = MAThairs[forAUX + 16];
                MAThairF[forAUX] = Resources.Load("materials/COMMON/hair and teeth/TPHairF");    //afro
                MAThairG[forAUX] = MAThairs[forAUX + 20];                
        }  
        MATbeard[0] = Resources.Load("materials/MALE/hairs and beards/beards/TPMBeard01", typeof(Material));
        MATbeard[1] = Resources.Load("materials/MALE/hairs and beards/beards/TPMBeard02", typeof(Material));
        MATbeard[2] = Resources.Load("materials/MALE/hairs and beards/beards/TPMBeard03", typeof(Material));
        Resethair();
        AUXmaterials = GObeard.GetComponent<Renderer>().sharedMaterials;
        GObeardsimple.GetComponent<Renderer>().sharedMaterials = AUXmaterials;
        //teeth
        AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
        AUXmaterials[teethindex] = MATteeth;
        GOhead.GetComponent<Renderer>().sharedMaterials = AUXmaterials;
    }   
    
    public void Setmaterial(GameObject[] GO, Object[] MAT, int todo)
    {
        int GOindex = 0;
        int MATindex = 0;
        Material AUXmaterial;
        for (int forAUX = 0; forAUX < GO.Length; forAUX++)
        {
            if (GO[forAUX].activeSelf) GOindex = forAUX;
        }
        AUXmaterial = GO[GOindex].GetComponent<Renderer>().sharedMaterial;
        while (AUXmaterial.name != MAT[MATindex].name) MATindex++;

        if (todo == 0) //increase
        {
            MATindex++;
            if (MATindex > MAT.Length - 1) MATindex = 0;
        }
        if (todo == 1) //decrease
        {
            MATindex--;
            if (MATindex < 0) MATindex = MAT.Length - 1;
        }
        if (todo == 2) //random value
        {
            MATindex = Random.Range(0, MAT.Length);
        }
        AUXmaterial = MAT[MATindex] as Material;
        GO[GOindex].GetComponent<Renderer>().sharedMaterial = AUXmaterial;
    }
    public void Setmaterials(GameObject[] GO, Object[] MAT, int matchannel, int todo)
    {
        int GOindex = 0;
        int MATindex = 0;
        Material[] AUXmaterials;
        for (int forAUX = 0; forAUX < GO.Length; forAUX++)
        {
            if (GO[forAUX].activeSelf) GOindex = forAUX;
        }
        AUXmaterials = GO[GOindex].GetComponent<Renderer>().sharedMaterials;
        while (AUXmaterials[matchannel].name != MAT[MATindex].name)
        {
            MATindex++;
        }
        if (todo == 0) //increase
        {
            MATindex++;
            if (MATindex > MAT.Length - 1) MATindex = 0;
        }
        if (todo == 1) //decrease
        {
            MATindex--;
            if (MATindex < 0) MATindex = MAT.Length - 1;
        }
        if (todo == 2) //random value
        {
            MATindex = Random.Range(0, MAT.Length);
        }
        AUXmaterials[matchannel] = MAT[MATindex] as Material;
        GO[GOindex].GetComponent<Renderer>().sharedMaterials = AUXmaterials;
    }
    public void SetGOmaterial(GameObject GO, Object[] MAT, int todo)
    {
        int MATindex = 0;
        Material AUXmaterial;
        AUXmaterial = GO.GetComponent<Renderer>().sharedMaterial;
        while (AUXmaterial.name != MAT[MATindex].name) MATindex++;
        if (todo == 0) //increase
        {
            MATindex++;
            if (MATindex > MAT.Length - 1) MATindex = 0;
        }
        if (todo == 1) //decrease
        {
            MATindex--;
            if (MATindex < 0) MATindex = MAT.Length - 1;
        }
        if (todo == 2) //random value
        {
            MATindex = Random.Range(0, MAT.Length);
        }
        AUXmaterial = MAT[MATindex] as Material;
        GO.GetComponent<Renderer>().sharedMaterial = AUXmaterial;
    }
    public void SetGOmaterials(GameObject GO, Object[] MAT, int matchannel, int todo)
    {
        int MATindex = 0;
        Material[] AUXmaterials;
        AUXmaterials = GO.GetComponent<Renderer>().sharedMaterials;
        while (AUXmaterials[matchannel].name != MAT[MATindex].name) MATindex++;
        if (todo == 0) //increase
        {
            MATindex++;
            if (MATindex > MAT.Length - 1) MATindex = 0;
        }
        if (todo == 1) //decrease
        {
            MATindex--;
            if (MATindex < 0) MATindex = MAT.Length - 1;
        }
        if (todo == 2) //random value
        {
            MATindex = Random.Range(0, MAT.Length);
        }
        AUXmaterials[matchannel] = MAT[MATindex] as Material;
        GO.GetComponent<Renderer>().sharedMaterials = AUXmaterials;
    }

}
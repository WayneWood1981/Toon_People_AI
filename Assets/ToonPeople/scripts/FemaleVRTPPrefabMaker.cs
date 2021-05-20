﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class FemaleVRTPPrefabMaker : MonoBehaviour
{
    public bool allOptions;
    int hair;
    int chest;   
    int tie;   
    int skintone;
    public bool tieactive;
    public bool tieactivecolor;
    public bool glassesactive;
    public bool hatactive;    
    public bool haircoloractive;
    GameObject GOhead;
    GameObject[] GOhair;
    GameObject[] GOchest;
    GameObject GOglasses;
    GameObject[] GOties;
    GameObject GOhands;
    GameObject GOneck;
    Object[] MATskins;
    Object[] MAThairs; Object[] MAThairA; Object[] MAThairB; Object[] MAThairC; Object[] MAThairD;
    Object[] MAThairE; Object[] MAThairF; Object[] MAThairG;
    Object[] MATglasses;
    Object[] MATdress;
    Object[] MATtshirt;
    Object[] MATshirtA;
    Object[] MATshirtB;
    Object[] MATeyes;    
    Object[] MAThatA;
    Object[] MAThatB;
    Object[] MAThatC;
    Object[] MATbowtie;
    Object[] MATtie;
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
        GOhead = (GetComponent<Transform>().GetChild(0).gameObject);
        Indentifymodel(); 
        GOhair = new GameObject[10];
        GOchest = new GameObject[5];        
        GOties = new GameObject[3];
        MAThairs = new Object[41];
        MAThairA = new Object[3];
        MAThairB = new Object[3];
        MAThairC = new Object[3];
        MAThairD = new Object[3];
        MAThairE = new Object[3];
        MAThairF = new Object[3];
        MAThairG = new Object[3]; 

        //Load models
        GOhands = (GetComponent<Transform>().GetChild(20).gameObject);
        GOneck = (GetComponent<Transform>().GetChild(21).gameObject);
        for (int forAUX = 0; forAUX < 10; forAUX++) GOhair[forAUX] = (GetComponent<Transform>().GetChild(forAUX + 4).gameObject);
        GOchest[0] = (GetComponent<Transform>().GetChild(3).gameObject);
        for (int forAUX = 0; forAUX < 2; forAUX++) GOchest[forAUX+1] = (GetComponent<Transform>().GetChild(forAUX + 14).gameObject);
        for (int forAUX = 0; forAUX < 2; forAUX++) GOchest[forAUX + 3] = (GetComponent<Transform>().GetChild(forAUX + 18).gameObject); 
        GOties[0] = (GetComponent<Transform>().GetChild(2).gameObject); //bowtie 
        for (int forAUX = 0; forAUX < 2; forAUX++) GOties[forAUX + 1] = (GetComponent<Transform>().GetChild(forAUX + 16).gameObject);
        GOglasses = transform.Find("ROOT/TP/TP Pelvis/TP Spine/TP Spine1/TP Spine2/TP Neck/TP Head/Glasses").gameObject as GameObject;

        //load  materials
        MATdress = Resources.LoadAll("materials/FEMALE/dress", typeof(Material));
        MATskins = Resources.LoadAll("materials/FEMALE/skin/" + model, typeof(Material));
        MATglasses = Resources.LoadAll("materials/COMMON/glasses", typeof(Material));
        MATtshirt = Resources.LoadAll("materials/FEMALE/tshirt", typeof(Material));
        MATshirtA = Resources.LoadAll("materials/FEMALE/shirtA formal", typeof(Material));
        MATshirtB = Resources.LoadAll("materials/FEMALE/shirtB casual", typeof(Material));
        MATeyes = Resources.LoadAll("materials/COMMON/eyes", typeof(Material));        
        MAThatA = Resources.LoadAll("materials/COMMON/hatsA", typeof(Material));
        MAThatB = Resources.LoadAll("materials/COMMON/hatsB", typeof(Material));
        MAThatC = Resources.LoadAll("materials/FEMALE/hats", typeof(Material));
        MATbowtie = Resources.LoadAll("materials/COMMON/ties/bowtie", typeof(Material));
        MATtie = Resources.LoadAll("materials/COMMON/ties/tie", typeof(Material));
        MATteeth = Resources.Load("materials/COMMON/hair and teeth/TPteeth") as Material;
        MATnoteeth = Resources.Load("materials/COMMON/hair and teeth/TPgums") as Material;
        MAThairs = Resources.LoadAll("materials/FEMALE/hairs", typeof(Material));
        for (int forAUX = 0; forAUX < 3; forAUX++)
        {
            MAThairA[forAUX] = MAThairs[forAUX];
            MAThairB[forAUX] = MAThairs[forAUX + 4];
            MAThairC[forAUX] = MAThairs[forAUX + 8];
            MAThairD[forAUX] = MAThairs[forAUX + 12];
            MAThairE[forAUX] = MAThairs[forAUX + 16];
            MAThairF[forAUX] = Resources.Load("materials/COMMON/hair and teeth/TPHairF");  
            MAThairG[forAUX] = MAThairs[forAUX + 20];
        }

        Checkelder();

        if (GOhair[0].activeSelf && GOhair[1].activeSelf && GOhair[2].activeSelf)
        {
            Randomize();
        }
        else
        {
            while (!GOhair[hair].activeSelf) hair++;
            while (!GOchest[chest].activeSelf) chest++;            
            tie = 3; if (GOties[0].activeSelf) tie = 0; if (GOties[1].activeSelf) tie = 1; if (GOties[2].activeSelf) tie = 2;
            if (!GOties[0].activeSelf && !GOties[1].activeSelf && !GOties[2].activeSelf) { tieactive = false; tieactivecolor = false; }
            if (GOglasses.activeSelf) glassesactive = true;
            Checkties();
        }
    }
    public void Indentifymodel()
    {
        Object[] tempMATA = Resources.LoadAll("materials/FEMALE/skin/TPFemaleA", typeof(Material));
        Object[] tempMATB = Resources.LoadAll("materials/FEMALE/skin/TPFemaleB", typeof(Material));
        Object[] tempMATC = Resources.LoadAll("materials/FEMALE/skin/TPFemaleC", typeof(Material));
        Object[] tempMATD = Resources.LoadAll("materials/FEMALE/skin/TPFemaleD", typeof(Material));
        string theskin = GOhead.GetComponent<Renderer>().sharedMaterials[0].name;
        for (int forAUX = 0; forAUX < tempMATA.Length; forAUX++)
        {
            if (theskin == tempMATA[forAUX].name) model = "TPFemaleA";
        }
        for (int forAUX = 0; forAUX < tempMATB.Length; forAUX++)
        {
            if (theskin == tempMATB[forAUX].name) model = "TPFemaleB";
        }
        for (int forAUX = 0; forAUX < tempMATC.Length; forAUX++)
        {
            if (theskin == tempMATC[forAUX].name) model = "TPFemaleC";
        }
        for (int forAUX = 0; forAUX < tempMATD.Length; forAUX++)
        {
            if (theskin == tempMATD[forAUX].name) model = "TPFemaleD";
        }
        if (model == "TPFemaleA") { eyeindex = 1; skinindex = 0; teethindex = 2; }
        if (model == "TPFemaleB") { eyeindex = 1; skinindex = 0; teethindex = 2; }
        if (model == "TPFemaleC") { eyeindex = 1; skinindex = 0; teethindex = 2; }
        if (model == "TPFemaleD") { eyeindex = 2; skinindex = 0; teethindex = 1; }
    }
    public void Deactivateall()
    {
        for (int forAUX = 0; forAUX < GOhair.Length; forAUX++) GOhair[forAUX].SetActive(false);
        for (int forAUX = 0; forAUX < GOchest.Length; forAUX++) GOchest[forAUX].SetActive(false);
        for (int forAUX = 0; forAUX < GOties.Length; forAUX++) GOties[forAUX].SetActive(false);
        GOglasses.SetActive(false);
        glassesactive = false;
        tieactivecolor = false;
        tieactive = false;
        tieactivecolor = false;
        hatactive = false;
    }
    public void Activateall()
    {
        for (int forAUX = 0; forAUX < GOhair.Length; forAUX++) GOhair[forAUX].SetActive(true);
        for (int forAUX = 0; forAUX < GOchest.Length; forAUX++) GOchest[forAUX].SetActive(true);
        for (int forAUX = 0; forAUX < GOties.Length; forAUX++) GOties[forAUX].SetActive(true);
        GOglasses.SetActive(true);
    }
    public void Menu()
    {
        allOptions = !allOptions;
    }
    public void Checkties()
    {
        if (chest == 1)
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
    public void Checkelder()
    {
        Material[] AUXmaterials;
        AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
        if (AUXmaterials[teethindex].name == MATteeth.name)
        {
            elder = false;
            haircoloractive = true;
            MATskins = Resources.LoadAll("materials/FEMALE/skin/" + model, typeof(Material));
            int MATindex = 0;
            AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
            while (AUXmaterials[0].name != MATskins[MATindex].name) MATindex++;
            for (int forAUX = 0; forAUX < 4; forAUX++) MATskins[forAUX] = MATskins[forAUX + 4];
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
        }
        else
        {
            elder = true;
            haircoloractive = false;
            MATskins = Resources.LoadAll("materials/FEMALE/skin/" + model, typeof(Material));
            int MATindex = 0;
            AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
            while (AUXmaterials[0].name != MATskins[MATindex].name) MATindex++;
            for (int forAUX = 0; forAUX < 4; forAUX++)
            {
                MATskins[forAUX + 4] = MATskins[forAUX];
                MATskins[forAUX + 8] = MATskins[forAUX];
                MATskins[forAUX + 12] = MATskins[forAUX];
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
        }
    }
    public void Checkmodel()
    {
        Checkties();
        Checkelder();
    }
    
    //models
    public void Nexthat()
    {
        if (hair < 7)
        {
            if (hair >= 0) GOhair[hair].SetActive(false);
            hair = 7;
            GOhair[hair].SetActive(true);
            hatactive = true;
        }
        else
        {
            GOhair[hair].SetActive(false);
            if (hair < GOhair.Length - 1)
            {
                hair++;
                hatactive = true;
            }
            else
            {
                hair = 2;
                hatactive = false;
            }
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
    public void Prevhat()
    {
        if (hair < 7)
        {
            GOhair[hair].SetActive(false);
            hair = 9;
            GOhair[hair].SetActive(true);
            hatactive = true;
        }
        else
        {
            GOhair[hair].SetActive(false);
            if (hair > GOhair.Length - 4)
            {
                hair--;
                hatactive = true;
            }
            else
            {
                hair = 2;
                hatactive = false;
            }
            GOhair[hair].SetActive(true);
        }
    }
    public void Prevhair()
    {
        hatactive = false;
        GOhair[hair].SetActive(false);
        if (hair > GOhair.Length - 4) hair--;
        else hair = 6;
        GOhair[hair].SetActive(true);
    }
    public void Prevchest()
    {
        GOchest[chest].SetActive(false);
        chest--;
        if (chest < 0) chest = GOchest.Length - 1;
        GOchest[chest].SetActive(true);
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
        SetGOmaterials(GOchest[0], MATskins, 1, todo);
        SetGOmaterials(GOchest[2], MATskins, 1, todo);
        SetGOmaterial(GOhands, MATskins, todo);
        SetGOmaterial(GOneck, MATskins, todo);
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
        SetGOmaterials(GOhair[7], MAThairC, 1, todo);
        SetGOmaterials(GOhair[8], MAThairC, 1, todo);
        SetGOmaterials(GOhair[9], MAThairC, 1, todo);
    }
    public void Nextglasses(int todo)
    {
        SetGOmaterial(GOglasses, MATglasses, todo);
    }
    public void Nexteyescolor(int todo)
    {
        SetGOmaterials(GOhead, MATeyes, eyeindex, todo);
    }
    public void Nextchestcolor(int todo)
    {
        if (chest == 0) SetGOmaterials(GOchest[0], MATdress, 0, todo);
        if (chest == 1) SetGOmaterial(GOchest[1], MATshirtA, todo);
        if (chest == 2) Setmaterials(GOchest, MATshirtB, 0, todo);
        if (chest > 2) Setmaterial(GOchest, MATtshirt, todo);
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
        Activateall();
        Menu();
    }
    public void Resetskin(Material skinbase)
    {
        //head
        Material[] AUXmaterials;
        AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
        AUXmaterials[skinindex] = skinbase as Material;
        GOhead.GetComponent<Renderer>().sharedMaterials = AUXmaterials;
        //chest  
        AUXmaterials = GOchest[0].GetComponent<Renderer>().sharedMaterials;
        AUXmaterials[1] = skinbase as Material;
        GOchest[0].GetComponent<Renderer>().sharedMaterials = AUXmaterials;
        AUXmaterials = GOchest[2].GetComponent<Renderer>().sharedMaterials;
        AUXmaterials[1] = skinbase as Material;
        GOchest[2].GetComponent<Renderer>().sharedMaterials = AUXmaterials;
        //necks hands
        GOhands.GetComponent<Renderer>().sharedMaterial = skinbase;
        GOneck.GetComponent<Renderer>().sharedMaterial = skinbase;
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
        AUXmaterials[1] = MAThairC[0] as Material;
        GOhair[7].GetComponent<Renderer>().sharedMaterials = AUXmaterials;
        AUXmaterials = GOhair[8].GetComponent<Renderer>().sharedMaterials;
        AUXmaterials[1] = MAThairC[0] as Material;
        GOhair[8].GetComponent<Renderer>().sharedMaterials = AUXmaterials;
        AUXmaterials = GOhair[9].GetComponent<Renderer>().sharedMaterials;
        AUXmaterials[1] = MAThairC[0] as Material;
        GOhair[9].GetComponent<Renderer>().sharedMaterials = AUXmaterials;
    }
    public void Randomize()
    {
        Deactivateall();

        hair = Random.Range(0, 15);
        if (hair > 9) hair = Random.Range(0, 5);
        GOhair[hair].SetActive(true);
        if (hair > 5) hatactive = true;
        chest = Random.Range(0, GOchest.Length); GOchest[chest].SetActive(true);
        tie = Random.Range(0, 4);
        Checkties();        
        if (Random.Range(0, 4) > 2)
        {
            glassesactive = true;
            GOglasses.SetActive(true);
            SetGOmaterial(GOglasses, MATglasses, 2);
        }
        else glassesactive = false;
        //materials
        SetGOmaterials(GOhead, MATeyes, eyeindex, 2);
        if (tieactivecolor) for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 10)); forAUX2++) Nexttiecolor(0);
        for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 8)); forAUX2++) Nexthaircolor(0);
        for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 32)); forAUX2++) Nextskincolor(0);
        for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 24)); forAUX2++) Nexthatcolor(0);
        for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 34)); forAUX2++) Nextchestcolor(0);
    }
    public void CreateCopy()
    {
        GameObject newcharacter = Instantiate(gameObject, transform.position, transform.rotation);
        for (int forAUX = 33; forAUX > 0; forAUX--)
        {
            if (!newcharacter.transform.GetChild(forAUX).gameObject.activeSelf) DestroyImmediate(newcharacter.transform.GetChild(forAUX).gameObject);
        }
        if (!GOglasses.activeSelf) DestroyImmediate(newcharacter.transform.Find("ROOT/TP/TP Pelvis/TP Spine/TP Spine1/TP Spine2/TP Neck/TP Head/Glasses").gameObject as GameObject);
        DestroyImmediate(newcharacter.GetComponent<FemaleVRTPPrefabMaker>());
    }
    public void FIX()
    {
        GameObject newcharacter = Instantiate(gameObject, transform.position, transform.rotation);
        for (int forAUX = 33; forAUX > 0; forAUX--)
        {
            if (!newcharacter.transform.GetChild(forAUX).gameObject.activeSelf) DestroyImmediate(newcharacter.transform.GetChild(forAUX).gameObject);
        }
        if (!GOglasses.activeSelf) DestroyImmediate(newcharacter.transform.Find("ROOT/TP/TP Pelvis/TP Spine/TP Spine1/TP Spine2/TP Neck/TP Head/Glasses").gameObject as GameObject);
        DestroyImmediate(newcharacter.GetComponent<FemaleVRTPPrefabMaker>());
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
        //skins
        MATskins = Resources.LoadAll("materials/FEMALE/skin/" + model, typeof(Material));
        int MATindex = 0;
        Material[] AUXmaterials;
        AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
        while (AUXmaterials[0].name != MATskins[MATindex].name) MATindex++;
        for (int forAUX = 0; forAUX < 4; forAUX++)
        {
            MATskins[forAUX + 4] = MATskins[forAUX];
            MATskins[forAUX + 8] = MATskins[forAUX];
            MATskins[forAUX + 12] = MATskins[forAUX];
        }
        Resetskin(MATskins[MATindex] as Material);
        //hai
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
        Resethair();
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
        //skin
        MATskins = Resources.LoadAll("materials/FEMALE/skin/" + model, typeof(Material));
        int MATindex = 0;
        Material[] AUXmaterials;
        AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
        while (AUXmaterials[0].name != MATskins[MATindex].name) MATindex++;
        for (int forAUX = 0; forAUX < 4; forAUX++)
        {
            MATskins[forAUX] = MATskins[forAUX + 4];
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
        Resethair();
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
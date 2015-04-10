using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using GeneticAlgorithms;
using UnityObjectFinders;
public class GeneShapeMap : IGeneShapeMap {

    public GameObject headPrefab;
    public GameObject appendagePrefab;

    private Instantiator instantiator;

    public GeneShapeMap()
    {
        Prefabs prefabs = MonoBehaviorFinder.Find<Prefabs>("Prefabs");
        this.headPrefab = prefabs.HeadPrefab;
        this.appendagePrefab = prefabs.AppendagePrefab;

        instantiator = new Instantiator();
    }

	public GameObject GetModelFromGenes(IGenome genome, GameObject baseModel)
    {
        SingleIntegerGenome sig = (SingleIntegerGenome)genome;
        int[] geneValues = sig.getGeneIntegerValues();
        int perceptionGene = geneValues[(int)TraitIndex.PerceptionRadius];
        int speedGene = geneValues[(int)TraitIndex.Speed];


        if(perceptionGene > 3)
        {
            //create head GameObject
            GameObject head = instantiator.Instantiate(headPrefab, baseModel.transform.position);
        
            //attach head
            baseModel = this.attachHead(head, baseModel, perceptionGene);
        }

        if(speedGene > 6)
        {
            GameObject appendage1 = instantiator.Instantiate(appendagePrefab, baseModel.transform.position);
            GameObject appendage2 = instantiator.Instantiate(appendagePrefab, baseModel.transform.position);

            baseModel = this.attachAppendages(appendage1, appendage2, baseModel);



        }



        return baseModel;

    }


    private GameObject attachHead(GameObject head, GameObject baseModel, int perceptionGene)
    {

        head.transform.SetParent(baseModel.transform);
        float headHeight = baseModel.transform.localScale.y / 2.5f;
        headHeight -= 1;
        head.transform.localPosition = new Vector3(0, headHeight, 0);
        Vector3 scale = head.transform.localScale;
        float s = 1.25f * (1+((float)perceptionGene/10));
        scale = new Vector3(scale.x*s, scale.y*s, scale.z*s);
        head.transform.localScale = scale;
        return baseModel;
    }

    private GameObject attachAppendages(GameObject appendage1, GameObject appendage2, GameObject baseModel)
    {
        appendage1.transform.SetParent(baseModel.transform);
        appendage2.transform.SetParent(baseModel.transform);

        appendage1.transform.localPosition = new Vector3(0.25f, 0f, -0.45f);
        appendage2.transform.localPosition = new Vector3(-0.25f, 0f, -0.45f);

        appendage1.transform.Rotate(90, 0, 0);
        appendage2.transform.Rotate(90, 0, 0);

        return baseModel;
    }
}

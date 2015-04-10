using UnityEngine;
using System.Collections;
using GeneticAlgorithms;
using AssemblyCSharp;
public interface IGeneShapeMap {

    GameObject GetModelFromGenes(IGenome genome, GameObject baseModel);

}

using UnityEngine;
using System.Collections;

public interface ITimer  {

	bool tick(float deltaTime);
    float CurrentTime{get;}

}

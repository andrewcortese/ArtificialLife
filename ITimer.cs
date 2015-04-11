using UnityEngine;
using System.Collections;

public interface ITimer  {

	bool Tick(float deltaTime);
    float CurrentTime{get;}

}

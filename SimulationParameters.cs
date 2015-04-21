using UnityEngine;
using System.Collections;

public static class SimulationParameters {

	private static int startingPopulationSize = 120;
	private static int startingResourcePopulationSize = 100;

	public static int StartingPopulationSize {
		get {
			return startingPopulationSize;
		}
		set {
			startingPopulationSize = value;
		}
	}


	public static int StartingResourcePopulationSize {
		get {
			return startingResourcePopulationSize;
		}
		set {
			startingResourcePopulationSize = value;
		}
	}
}
